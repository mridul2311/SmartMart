#!/usr/bin/env python
# coding: utf-8

# In[1]:


import socket
import json
import turicreate as tc
import pandas as pd


# In[2]:
 

model = tc.load_model('./pop_model')

user_id = 'customerId'
item_id = 'productId'
target = 'purchase_count'
# In[3]:
def create_output(model, users_to_recommend, n_rec,customer_id):
    recomendation = model.recommend(users=users_to_recommend, k=n_rec)
    df_rec = recomendation.to_dataframe()
    df_rec['recommendedProducts'] = df_rec.groupby(['customerId'])['productId'] \
        .transform(lambda x: '|'.join(x.astype(str)))
    df_output = df_rec[['customerId', 'recommendedProducts']].drop_duplicates() \
        .sort_values('customerId').set_index('customerId')
    if customer_id not in df_output.index:
        print('Customer not found.')
        return customer_id
    str1 = df_output.loc[customer_id].to_string()[23:]
    str1=str1.replace('|',',')
    return str1
# def create_item_output(model, productId, n_rec):
#     similar_items = model.get_similar_items([productId], k=n_rec)
#     df = similar_items.to_dataframe()
#     op = df['similar'].tolist()
#     return op


# In[4]:


s = socket.socket()          
print("Socket successfully created")


# In[5]:


port = 12346
s.bind(('', port))         
print("socket binded to %s" %(port))


# In[6]:


s.listen(5)      
print("socket is listening")


# In[7]:


n_rec = 10
 
   
c, addr = s.accept()      
print('Got connection from', addr)
_bytes = c.recv(1024)
print("Bytes",_bytes)
my_json = _bytes.decode('utf8').replace("'", '"')
print("My_json",my_json)
print('- ' * 20)
    
data = json.loads(my_json)
print("data", data)

productId1 = data["pid"]

# transactions = pd.read_csv('trx_data.csv')

# users_to_recommend = list(transactions["customerId"])  
users_to_recommend=[]
for i in range (2000):
 users_to_recommend.append(i)
recList1 = create_output(model, users_to_recommend, n_rec,productId1)
recList=recList1.split(",")
reco=[]
print(recList[:10])


recList=recList[:10]
for i in range (0, len(recList)):
    if(int(recList[i])<240):
     reco.append(recList[i])

print(reco)
recList = list(set(reco))

string = ','.join([str(x) for x in reco])
print("String",string)
    
c.send(string.encode('utf8')) 

c.close() 

