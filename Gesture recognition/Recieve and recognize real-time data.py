import socket
from openpyxl import load_workbook
from Model import Net
import torch
import numpy as np
from torch.utils.data import Dataset
from torch.utils.data import DataLoader
import struct

model=Net()
checkpoint = torch.load("./workcheckpoint.pt")
model.load_state_dict(checkpoint['model'])
model.eval()  

    
# Configure the server address and port
server_address = "127.0.0.1"  # Use "0.0.0.0" to accept connections from any IP address
server_port = 5006  # Same port number as used in the Unity script

# Create a socket object
server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# 设置套接字选项 - 端口复用
server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_KEEPALIVE, 1)

# Bind the socket to the server address and port
server_socket.bind((server_address, server_port))


# Listen for incoming connections
server_socket.listen(1)
print("Server listening on {}:{}".format(server_address, server_port))
        
 # Accept a client connection
client_socket, client_address = server_socket.accept()
print("Client connected: {}".format(client_address))

# Connect to the Unity server
unity_host = "127.0.0.1"  # Change this to the IP address of your Unity machine
unity_port = 1234
unity_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
unity_socket.connect((unity_host, unity_port))

while True:
    try:
        
        # Receive data from the client
        data = client_socket.recv(4096).decode("utf-8")

        # Process the received data
        positions = []
        if data:
            # Split the data into individual position strings
            position_strings = data.strip().split(";")

            # Parse each position string into a Vector3 or process as needed
            for position_string in position_strings:
                position_values = position_string.split(",")
                if len(position_values) == 3:
                    # Before recognition, they have to be normalized(i.e., minus their original position in the scene of Unity3D)
                    x = float(position_values[0])-0.1659978
                    y = float(position_values[1])-3.306981
                    z = float(position_values[2])-1.640583
                    positions.append((x, y, z))

        # Do further processing with the received positions
        for position in positions:
            # position=position+(1,)
            # position=position-
            print("Received position: {}".format(position))
        
        positions=np.array(positions)
        positions=positions.transpose(1,0)
        # print(positions.dtype)
        positions=torch.from_numpy(positions)
        positions=positions.reshape(1,3,21)
        positions=positions.to(torch.float32)
        outputs=model(positions)
        _, test_pred = torch.max(outputs, 1)  # get the index of the class with the highest probability
        test_pred=test_pred.item()
        print(test_pred)
        unity_socket.send(struct.pack("i", test_pred))

    except Exception as e:
        print("Socket error: {}".format(e))
