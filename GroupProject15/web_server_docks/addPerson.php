<!DOCTYPE html>
<html>
<head>
	<title>MySQL Query</title>
</head>
<body>

<?php

$server = "localhost";
$user = "root";
$password = "";
$database = "test";

$connect = mysqli_connect($server, $user, $password, $database);

if ($connect->connect_error) {
	die("Database connection failed: " . $dbconnect->connect_error);
}

$name = $_POST['empName'];
$email = $_POST['empEmail'];
$number = $_POST['empNumber'];
$postcode = $_POST['empPostcode'];

$useQuery = "INSERT INTO cases (name, email, number, postcode) VALUES ('$name', '$email', '$number', '$postcode')";

$result = mysqli_query($connect, $useQuery);

if(!$result){
	die("Could not successfully run query ($useQuery) from $database : ".
	 mysqli_error($connect));
}else{
	print(" <h1>ADD A NEW CASE</h1> ");
	print(" <p>The following record was added to the cases table:</p>");
	print("<table border='0'>
			<tr><td>NAME</td><td>$name</td></tr>
			<tr><td>EMAIL</td><td>$email</td></tr>
			<tr><td>PHONE NUMBER</td><td>$number</td></tr>
			<tr><td>POSTCODE</td><td>$postcode</td></tr>
			</table>");
}

mysqli_close($connect);

 ?>

</body>
</html>>