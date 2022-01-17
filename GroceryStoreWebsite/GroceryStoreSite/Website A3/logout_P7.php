<?php
session_start();
error_reporting(E_ALL);
ini_set('display_errors', TRUE);
echo "poo";
$backup = $_SESSION["backup"];
$file = fopen("products.txt", "w+")  or die("eror");
file_put_contents("products.txt", $backup);
fclose($file);
echo "poo2";
session_destroy();
echo 'You have been logged out. <a href="P7.php">Go back</a>';
