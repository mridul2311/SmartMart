<?php
	$servername = "localhost";
	$username =  "root";
	$password = "";
	$dbName = "vrsupermarket_normal";
	

	$loginUser = $_POST["loginFName"];
	$loginUser2 = $_POST["loginLName"];
	//Make Connection
	$conn = new mysqli($servername, $username, $password, $dbName);
	//Check Connection
	if(!$conn){
		die("Connection Failed. ". mysqli_connect_error());
	}
	
	$sql = "SELECT * FROM customer WHERE First_Name = '" . $loginUser . "' AND Last_Name='" . $loginUser2 ."'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc())
   {
    echo "".$row['Customer_ID']. "|".$row['Phone_No'] ;
  }
} 

$conn->close();

?>