<?php
require_once "config.php";
if(isset($_POST['name'])&& !empty($_POST['name']))
{
	$name = $_POST['name'];
	$sql = "SELECT Section FROM inventory I,belongs_to B WHERE I.Shelf=B.Shelf AND Name LIKE '%$name%'";
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