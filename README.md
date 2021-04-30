# SmartMart
- The current online shopping system does not provide the actual shopping experience to the users where they just scroll through the webpage and select an item they need to purchase which becomes monotonous too soon. We propose a 3D shopping system where the user can navigate through the shopping mart and interact with the items as they would in real life. The proposed system has various aspects interfaced with it.
![ss3](https://user-images.githubusercontent.com/42913386/116750185-b4441180-aa1f-11eb-852b-9e155c64b3e1.PNG)
- The front end is the actual environment where the user interacts and explores the shopping mart. 
- MySQL database is used to store the inventory, the customer details and the billing information.
-  Shopping is made more efficient and seamless with the integration of the recommendation system where various products get recommended taking into account the users’ purchase history. 

## System Requirements
- Processor: Core i3 or equivalent
-	RAM: 4GB
-	Graphics: Intel Onboard HD Graphics	
-	Hard Disk: 250GB
-	Windows 7 (64 bit)


## Executing the application
- Extract the NUP.7z file and place the extracted folder in the htdocs of the xampp folder. This contains the php files for database, python files and the model for the recommendation.
-	Extract the SmartMart.7z file and place it in the desired location. This is the unity game project.
-	Open xampp control panel and start the Apache and MySQL to set up a local server.
-	Using Ubuntu bash go to the directory where the Recommendation.py file is present and run the file using the command python run Recommendation.py command. This will enable the user-item recommendation.
-	Similarly, to start item-item and popularity model go to the respective directory where Recommendation1.py and Recommendation2.py files are present using different ubuntu bash terminals and run the files using python run Recommendation1.py and python run Recommendation2.py.
-	Now that the backend is setup launch the unity game engine and run the project.
-	To check the real-time updating of the database go to http://localhost/phpmyadmin/ on your web browser and click on the table that needs to be checked under the vrsupermarket database.
-	The products that are being recommended can also be seen on the ubuntu terminal.
-	Now you can move around the SmartMart and purchase the product you want!  
-	Now you can move around the SmartMart and purchase the product you want!  

## Snapshots from the application

![ss4](https://user-images.githubusercontent.com/42913386/116750204-ba39f280-aa1f-11eb-9808-40a65c2d97ca.PNG)
![ss5](https://user-images.githubusercontent.com/42913386/116750217-bc03b600-aa1f-11eb-814c-d18049ed9b33.PNG)!
