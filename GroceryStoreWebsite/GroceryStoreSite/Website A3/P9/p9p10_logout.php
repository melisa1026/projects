<?php
session_start();
error_reporting(E_ALL);
ini_set('display_errors', TRUE);
$backup = $_SESSION["backup"];
$file = fopen("users.txt", "w+")  or die("eror");
file_put_contents("users.txt", $backup);
fclose($file);
session_destroy();
echo 'You are now logged out. :/';
