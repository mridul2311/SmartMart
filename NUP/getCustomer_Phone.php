<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "vrsupermarket_normal";

if(isset($_POST['phone'])&& !empty($_POST['phone']))
{
		// Create connection
		$conn = new mysqli($servername, $username, $password, $dbname);
		// Check connection
		if ($conn->connect_error) 
		{
		    die("Connection failed: " . $conn->connect_error);
		} 

		$phone = $_POST['phone'];
		$getcid = "SELECT Customer_ID,First_Name,Last_Name, Password FROM Customer WHERE Phone_no = '$phone';";
		$result = $conn->query($getcid);

		if ($result->num_rows>0) 
		{
		     $rows = mysqli_fetch_row($result);
		     $cid = $rows[0];
		     $firstname = $rows[1];
		     $lastname = $rows[2];
             $hashed_password = $rows[3];
             if(isset($_POST['pwd'])&& !empty($_POST['pwd'])){
                if(password_verify($_POST['pwd'], $hashed_password)){
                    echo "$cid,$firstname $lastname";
                }
                else{
                    echo "!!Error: Invalid Password!. Try again";
                }   
             }
		     
		} 
		else 
		{
			echo "!!Error: Phone_no not found";
		}
	
}
?>