<?php
require_once "config.php";
if(isset($_POST['pid'])&& !empty($_POST['pid']))
{
	
	$name = $_POST['name'];
	//$cid = $_POST['cid'];
	$qpid = $_POST['pid'];


	$host    = "127.0.0.1";
	$port    = 12346;
	$message = "{
		'pid': $qpid,
		'name': '$name'
	}";
	
	//echo "Message To server :".$message;
	// create socket
	$socket = socket_create(AF_INET, SOCK_STREAM, 0) or die("Could not create socket\n");
	// connect to server
	$result = socket_connect($socket, $host, $port) or die("Could not connect to server\n");  
	// send string to server
	socket_write($socket, $message, strlen($message)) or die("Could not send data to server\n");
	// get server response
	$result = socket_read ($socket, 1024) or die("Could not read server response\n");
	//echo "Reply From Server  :".$result;
	// close socket
	socket_close($socket);
	echo "$result|";
	$pids = explode(',',$result);
	$pnames = $conn->prepare("SELECT Name FROM inventory WHERE PID = ?");
	if($pnames){
		$pnames->bind_param("i",$pid);
		$size = count($pids);
		//echo "Count: $size";
		for($i=0; $i < $size; $i++){
			$pid=$pids[$i];
			//echo "Cid: $cid ";
			$pnames->execute();	
			$pnames->bind_result($name);
			while($pnames->fetch()){
				echo "$name,";
			}
		}
	}
	else 
	{
		echo "No results<br>";
	}
	$conn->close();
}
?>