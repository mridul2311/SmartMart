<?php
	$servername = "localhost";
	$username =  "root";
	$password = "";
	$dbName = "vrsupermarket_normal";
	
	//Make Connection
	$conn = new mysqli($servername, $username, $password, $dbName);
	//Check Connection
	if(!$conn){
		die("Connection Failed. ". mysqli_connect_error());
	}
	
	$sql = "SELECT * FROM orders where Bill_ID=(SELECT MAX(Bill_ID) FROM orders)";
	$result = mysqli_query($conn ,$sql);
	
	
	if(mysqli_num_rows($result) > 0){
		//show data for each row
		echo "| Product Name | Product ID\t | Quantity\t | Price per item | Total Price |";
		echo "<br>";
		while($row = mysqli_fetch_assoc($result)){
			
			$sql3 = "SELECT Name FROM inventory where PID='".$row['Product_ID']."'";
			$result3 = mysqli_query($conn,$sql3);
			$row3 = mysqli_fetch_assoc($result3);
			echo "".$row3['Name']. "\t\t".$row['Product_ID'] . "\t\t".$row['Quantity']. "\t\t".$row['Price']. "\t\t".($row['Price'] * $row['Quantity'])."". ";";

	$sql1 = "SELECT * FROM billing where Bill_ID=(SELECT MAX(Bill_ID) FROM billing)";
	$result1 = mysqli_query($conn ,$sql1);
	}}
	
	if(mysqli_num_rows($result1) > 0){
		//show data for each row
		while($row = mysqli_fetch_assoc($result1)){
			echo " Bill id : ".$row['Bill_ID'] . " | Bill Date : ".$row['Bill_Date']." |Total amount : ".$row['TotalAmt'].";";
		}
	}
	
	
	
	


?>