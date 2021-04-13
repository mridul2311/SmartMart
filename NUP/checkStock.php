<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "vrsupermarket_normal";


if(isset($_POST['pid'])&& !empty($_POST['pid']))
{
		$selectedProductID = $_POST['pid'];
		// Create connection
		$conn = new mysqli($servername, $username, $password, $dbname);

		// Check connection
		if ($conn->connect_error) 
		{
		    die("Connection failed: " . $conn->connect_error);
		} 

		//echo "Connected successfully";

		$sql_select = "SELECT PID, Rate, Name, CGST+SGST as Tax, Stock,Discount  FROM inventory,tax WHERE PID = '".$selectedProductID."' and Tax_Category=Category_ID";
		$result = $conn->query($sql_select);
	
		if ($result->num_rows > 0) 
		{
		     $row=mysqli_fetch_row($result);
			 echo $row[0].",".$row[1].",".$row[2].",".$row[3].",".$row[4].",".$row[5];
			 //echo $row['Stock'].",".$row['Rate'].",";
		} 
		else 
		{
			echo "No results";
		}
		$conn->close();
}
else
{
	echo "No selection";
}

?>