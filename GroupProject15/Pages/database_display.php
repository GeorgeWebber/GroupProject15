<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<body>
<?php
	$hostname = "localhost";
	$username = "root";
	$password = "";
	$db = "test";

$dbconnect=mysqli_connect($hostname,$username,$password,$db);

if ($dbconnect->connect_error) {
	die("Database connection failed: " . $dbconnect->connect_error);
}

?>

<table border="1" align="center"><tr>
  <td>Name</td>
  <td>Email</td>
  <td>Phone Number</td>
  <td>postcode</td>
</tr>

<?php

$query = mysqli_query($dbconnect, "SELECT * FROM cases")
   or die (mysqli_error($dbconnect));

while ($row = mysqli_fetch_array($query)) {
  echo
   "<tr>
    <td>{$row['name']}</td>
    <td>{$row['email']}</td>
    <td>{$row['number']}</td>
    <td>{$row['postcode']}</td>
   </tr>\n";

}

?>
</table>
</body>
</html>