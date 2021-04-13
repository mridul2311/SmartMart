<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "vrsupermarket_normal";


if(isset($_POST['cid'])&& !empty($_POST['cid']))
{
		$selectedProductID = $_POST['cid'];
		// Create connection
		$conn = new mysqli($servername, $username, $password, $dbname);

		// Check connection
		if ($conn->connect_error) 
		{
		    die("Connection failed: " . $conn->connect_error);
		} 

		//echo "Connected successfully";

		$sql_select = "SELECT First_Name, Last_Name FROM customer WHERE Customer_ID = '$selectedProductID'";
		$result = $conn->query($sql_select);
	
		if ($result->num_rows > 0) 
		{
		     $row=mysqli_fetch_row($result);
			 echo $row[0]." ".$row[1];
			 //echo $row['Stock'].",".$row['Rate'].",";
		} 
		else 
		{
			echo "No results<br>";
		}
		$conn->close();
}
else
{
	echo "No selection<br>";
}

?>