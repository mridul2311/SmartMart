<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "vrsupermarket_normal";

$loginUser = $_POST["loginFName"];
$loginUser2 = $_POST["loginLName"];
$loginPass = $_POST["loginPass"];
// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT Password FROM customer WHERE First_Name = '" . $loginUser . "' AND Last_Name='" . $loginUser2 ."'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    if($row["Password"] == $loginPass){
    	echo "Login Success.";
    }
    else{echo "Login failed.";}
  }
} else {
  echo "Username doesn't exist";
}
$conn->close();
?>