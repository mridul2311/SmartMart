<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "vrsupermarket_normal";

if(isset($_POST['phone'])&& !empty($_POST['phone'])&&isset($_POST['aid'])&& !empty($_POST['aid']))
{
		// Create connection
		$conn = new mysqli($servername, $username, $password, $dbname);
		// Check connection
		if ($conn->connect_error) 
		{
		    die("Connection failed: " . $conn->connect_error);
		} 
        mysqli_autocommit($conn,FALSE);
		$aid = $_POST['aid'];
		$phone = $_POST['phone'];
		$pids = explode(",",$_POST['pids']);
		$quantity = explode(",",$_POST['quantities']);
		$prices=explode(",",$_POST['prices']);
		$total = (float)$_POST['total'];
		$cid=0;
		$billid=0;
		$getcid = "SELECT Customer_ID FROM Customer WHERE Phone_no = $phone";
		$result = $conn->query($getcid);
		if ($result->num_rows > 0) 
		{
		     $cid = mysqli_fetch_row($result)[0];
		} 
		else 
		{
			echo "!!Error: Phone_no not found";
			die();
		}
		$date = mysqli_fetch_row($conn->query("SELECT NOW();"))[0];
		$newbill = "INSERT INTO Billing VALUES( default,$cid,$total,$aid,NOW());";
		$result = $conn->query($newbill);
		if ($result) {
			$billid = mysqli_insert_id($conn);
			//echo "Bill ID: $billid";
			$orders = $conn->prepare("INSERT INTO orders VALUES (?, ?, ?, ?)");
			if($orders){
				$orders->bind_param("iiid",$billid,$pid,$quant,$price);
				$size = count($pids);
				//echo "Count: $size";
				for($i=0; $i < $size; $i++){
					$pid=$pids[$i];
					$quant=$quantity[$i];
					$price=$prices[$i];
					//echo "Pid: $pid Quantity: $quant";
					$orders->execute();	
				}
                $points = "UPDATE Customer SET Points = Points+ROUND(0.01*$total) WHERE Phone_No = $phone";
                $conn->query($points);
                mysqli_commit($conn);

			}
			else{
				echo "!!Error: Not able to bind";
			}
			$orders->close();
		} 
		else {
			echo "!!Error: Not able to INSERT Result: $result";
			//die();
		}
		echo "$billid,$total,$date,".round(0.01*$total);
		$conn->close();
}
?>