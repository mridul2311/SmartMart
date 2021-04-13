 <?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "vrsupermarket_normal";

if(isset($_POST['pid'])&& !empty($_POST['pid']))
{
		$selectedProductID = $_POST['pid'];

		$conn = new mysqli($servername, $username, $password, $dbname);

		if ($conn->connect_error) 
		{
		    die("Connection failed: " . $conn->connect_error);
		} 

		$sql_select = "SELECT * FROM inventory WHERE PID = '".$selectedProductID."'";
		$result = $conn->query($sql_select);
	
		if(mysqli_num_rows($result) > 0){
		//show data for each row
		while($row = mysqli_fetch_assoc($result)){
			echo $row['PID'] . "|".$row['Name']. "|".$row['Rate'];
		}
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