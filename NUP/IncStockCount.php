<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "vrsupermarket_normal";

if(isset($_POST['pid'])&& !empty($_POST['pid'])&&isset($_POST['count'])&& !empty($_POST['count']))
{
		$selectedProductID = $_POST['pid'];
		$count= $_POST['count'];

		$conn = new mysqli($servername, $username, $password, $dbname);

		if ($conn->connect_error) 
		{
		    die("Connection failed: " . $conn->connect_error);
		} 

		$sql_select = "SELECT PID, Stock FROM inventory WHERE PID = '".$selectedProductID."'";
		$result = $conn->query($sql_select);
	
		if ($result->num_rows > 0) 
		{
		    $quant = $result->fetch_assoc()["Stock"];
			 $newquant = $quant + $count;
			 $sql_update = "UPDATE inventory SET Stock = ".$newquant." WHERE PID = '".$selectedProductID."'";
			 $conn->query($sql_update);
			 echo 0;
		} 
		else 
		{
		    echo 1;
		}
		$conn->close();
}
else
{
	echo "No PID found<br>";
}

?>