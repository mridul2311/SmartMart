<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "vrsupermarket_normal";


if(isset($_POST['cids'])&& !empty($_POST['cids']))
{
		//$selectedProductID = $_POST['cid'];
		$cids = explode(",",$_POST['cids']);
		// Create connection
		$conn = new mysqli($servername, $username, $password, $dbname);

		// Check connection
		if ($conn->connect_error) 
		{
		    die("Connection failed: " . $conn->connect_error);
		} 

		//echo "Connected successfully";

		$orders = $conn->prepare("SELECT First_Name, Last_Name FROM customer WHERE Customer_ID = ?");
		if($orders){
			$orders->bind_param("i",$cid);
			$size = count($cids);
			//echo "Count: $size";
			for($i=0; $i < $size; $i++){
				$cid=$cids[$i];
				//echo "Cid: $cid ";
				$orders->execute();	
				$orders->bind_result($fname,$lname);
				while($orders->fetch()){
					echo "$fname $lname,";
				}
			}
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