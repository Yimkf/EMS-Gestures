import numpy as np
import pandas as pd
from torch.utils.data import DataLoader
import torch
import torch.nn as nn
from torch import optim
import matplotlib.pyplot as plt
from torch.utils.data import Dataset
from torch.utils.data import DataLoader
from torch.utils.data.sampler import SubsetRandomSampler
from sklearn.model_selection import train_test_split
import os
from Model import Net

BATCH_SIZE=64
num_epoch=30
patience = 30
early_stop_counter = 0
train_loss = []
val_loss = []
train_lossshow = []

label_set = {'spiderman':0, 'gun':1, 'flower':2, 'scissors':3, 'accordion':4, 'open':5, 'stapler':6,'lever':7}

def load_data(file_name):
    root = r'D:\EMS-Gestures\Gesture recognition\gesture_dataset'
    path = root + "\\" + file_name
    rawdata = pd.read_excel(path, header=None)
    array = np.array(rawdata).reshape(-1, 21, 3)
    label = np.zeros((array.shape[0],1))+label_set[file_name.split('_')[-1].split('.')[0]]
    return array, label


#tagging
class TIMITDataset(Dataset):
    def __init__(self, X, y=None):
        self.data = torch.from_numpy(X).float().permute((0,2,1))
        if y is not None:
            y = y.astype(np.int)
            self.label = torch.LongTensor(y)
        else:
            self.label = None

    def __getitem__(self, idx):
        if self.label is not None:
            return self.data[idx], self.label[idx]
        else:
            return self.data[idx]

    def __len__(self):
        return len(self.data)

#load data
array_all, label_all =[], []
for key in label_set.keys():
    gesture, label = load_data(f'gesture_data_{key}.xlsx')
    array_all.append(gesture)
    label_all.append(label)

array_all = np.concatenate(array_all, axis=0)
label_all = np.concatenate(label_all, axis=0)
x_train, x_test, y_train, y_test = train_test_split(array_all, label_all, test_size=0.2)
print(x_train.shape)
print(x_test.shape)


# put data into dataloader
train_set = TIMITDataset(x_train, y_train)
train_loader = DataLoader(train_set, batch_size=BATCH_SIZE,
                          )  # only shuffle the training data

test_set = TIMITDataset(x_test, y_test)
test_loader = DataLoader(test_set, batch_size=BATCH_SIZE, shuffle=False)


best_acc = 0.0
num_correct = 0
train_total = 0
avg_train_loss = []
avg_val_loss = []
model=Net()
criterion = nn.CrossEntropyLoss()
optimizer = torch.optim.SGD(model.parameters(), lr=0.1, weight_decay=0.01, momentum=0.9)


for epoch in range(num_epoch):
    #training
    model.train()
    for i,data in enumerate(train_loader):
        inputs,labels=data
        outputs=model(inputs)
        loss = criterion(outputs, labels[:,0])
        optimizer.zero_grad()  
        loss.backward()
        optimizer.step()
        train_loss.append(loss.item())

    train_loss_mean = sum(train_loss) / len(train_loss)
    train_loss = []
    train_lossshow.append(train_loss_mean)
    if epoch == 0:
        best_val_loss = float('inf')

    #validation
    predict = []
    current_num = 0
    total = 0
    acc = 0
    model.eval()  # set the model to evaluation mod

    with torch.no_grad():
        for i, data in enumerate(test_loader):
            inputs, label = data
            outputs = model(inputs)
            _, test_pred = torch.max(outputs, 1) 
            current_num += torch.eq(test_pred, label[:,0]).sum()
            total += label.size(0)
        acc = current_num / total

    print('Epoch [{}/{}], train_loss: {:.4f}, acc: {:.4f}'
            .format(epoch + 1, num_epoch, train_loss_mean, acc))
    
    print('saving epoch%d model' % (epoch + 1))
    state = {
                    'model': model.state_dict(),
                    'epoch': epoch + 1
                }
    torch.save(state, './checkpoint.pt')
    

