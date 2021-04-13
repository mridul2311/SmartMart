<?php
require_once "config.php";
if(isset($_POST['pid'])&& !empty($_POST['pid']))
{
	$pid = $_POST['pid'];
	$sql = "SELECT Shelf FROM inventory WHERE PID=$pid";
	$result = $conn->query($sql);
	
	if ($result->num_rows > 0) 
	{
	     $row=mysqli_fetch_row($result);
		 echo $row[0];
	}
	else
		echo "!!Error: Item not found";
}

?>