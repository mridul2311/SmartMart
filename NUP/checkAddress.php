<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "vrsupermarket_normal";

if(isset($_POST['phone'])&& !empty($_POST['phone']))
{
		$phone = $_POST['phone'];
		$conn = new mysqli($servername, $username, $password, $dbname);
		// Check connection
		if ($conn->connect_error) 
		{
			die("Connection failed: " . $conn->connect_error);
		} 
		$sql_select = "SELECT Address_ID,Number, Street, Locality, cities.PIN, States.City, State FROM Addresses, cities, States WHERE PINCode=PIN AND cities.City=States.City AND Customer_ID=(SELECT Customer_ID from customer WHERE Phone_No = '".$phone."');";
		$result = $conn->query($sql_select);
		if ($result->num_rows > 0) 
		{
			while($row = $result->fetch_assoc()){
				 echo $row['Address_ID'].",".$row['Number'].",".$row['Street'].",".$row['Locality'].",".$row['City'].",".$row['PIN'].",".$row['State']."~";
			}
		} 
		else 
		{
			echo "!!Error: User not found";

		}
		$conn->close();
}
else
{
	echo "No selection<br>";
}

?>