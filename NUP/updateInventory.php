<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "vrsupermarket_normal";
$conn = new mysqli($servername, $username, $password, $dbname);


if(isset($_POST['pid'])&& !empty($_POST['pid']))
{
		$selectedProductID = $_POST['pid'];
		// Create connection
		//$conn = new mysqli($servername, $username, $password, $dbname);

		// Check connection
		if ($conn->connect_error) 
		{
		    die("Connection failed: " . $conn->connect_error);
		} 

		//echo "Connected successfully";

		$sql_select = "SELECT PID, Stock FROM inventory WHERE PID = '".$selectedProductID."' AND Stock > 0";
		$result = $conn->query($sql_select);
	
		if ($result->num_rows > 0) 
		{
		     $quant = $result->fetch_assoc()["Stock"];
			 $newquant = $quant - 1;
			 $sql_update = "UPDATE inventory SET Stock = ".$newquant." WHERE PID = '".$selectedProductID."'";
			 $conn->query($sql_update);
			 //echo "Done updating database";
			 echo 0;
		} 
		else 
		{
		    echo 1;
			//echo "No results<br>";

		}
		$conn->close();
}
else
{
	//echo "No selection<br>";
}

?>