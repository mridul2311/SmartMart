<?php
//Variables for the connection
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "vrsupermarket_normal";

//Variable from the user	
	$First_Name = $_POST["fnamePost"]; //"Lucas Test AC";
	$Last_Name = $_POST["lnamePost"];//"test email";
	$Phone_No = $_POST["pnoPost"];//"123456";
	$Password = $_POST["passPost"];
	//Make Connection
	$conn = new mysqli($servername, $username, $password, $dbname);
	//Check Connection
	if(!$conn){
		die("Connection Failed. ". mysqli_connect_error());
	}
	
	$sql = "INSERT INTO customer (First_Name, Last_Name, Phone_No,Password)
			VALUES ('".$First_Name."','".$Last_Name."','".$Phone_No."','".$Password."')";
	$result = mysqli_query($conn ,$sql);
	
	if(!result) echo "there was an error";
	else echo "Everything ok.";

?>