import torch
# import torchvision
import numpy as np
import torch.nn as nn
import torch.nn.functional as F
import torch.optim as optim

class Net(nn.Module):
    def __init__(self):
        super(Net, self).__init__()

        # 1DCNNs
        self.conv1ds = nn.Sequential(
            nn.Conv1d(in_channels=3, out_channels=32, kernel_size=3),
            nn.BatchNorm1d(32),
            nn.Tanh(),

            nn.Conv1d(in_channels=32, out_channels=64, kernel_size=3),
            nn.BatchNorm1d(64),
            nn.Tanh(),

            nn.Conv1d(in_channels=64, out_channels=32, kernel_size=3),
            nn.BatchNorm1d(32),
            nn.Tanh(),
            nn.AvgPool1d(2,2),
        )

        self.fc=nn.Sequential(
            nn.Linear(32 * 7 , 8),
            nn.Softmax(dim=1)
        )

    def forward(self, x):
        x = self.conv1ds(x)
        x = x.view(-1, 32 * 7)
        y=self.fc(x)
        return y
    
