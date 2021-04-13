#!/usr/bin/env python
# coding: utf-8

# In[1]:


import socket
import json
import turicreate as tc
import pandas as pd


# In[2]:


model = tc.load_model('./model_file')


# In[3]:


def create_item_output(model, productId, n_rec):
    similar_items = model.get_similar_items([productId], k=n_rec)
    df = similar_items.to_dataframe()
    op = df['similar'].tolist()
    return op


# In[4]:


s = socket.socket()          
print("Socket successfully created")


# In[5]:


port = 12347
s.bind(('', port))         
print("socket binded to %s" %(port))


# In[6]:


s.listen(5)      
print("socket is listening")


# In[7]:


n_rec = 5
while True: 
   
    c, addr = s.accept()      
    print('Got connection from', addr)
    _bytes = c.recv(1024)
    print("Bytes",_bytes)
    my_json = _bytes.decode('utf8').replace("'", '"')
    print("My_json",my_json)
    print('- ' * 20)
    
    data = json.loads(my_json)
    print("data", data)
    productId = data["pid"]
    recList = create_item_output(model, productId, n_rec)

    reco=[]
    
    for i in range (0, len(recList)):
     if(recList[i]<37):
      reco.append(recList[i])

    recList = list(set(reco))

    string = ','.join([str(x) for x in reco])
    print("String",string)
    
    c.send(string.encode('utf8')) 

    c.close() 

