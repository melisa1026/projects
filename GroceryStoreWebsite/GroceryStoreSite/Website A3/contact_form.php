<?php
    include ("header.php");
?>

<html>
<body>
<link rel="stylesheet" type="text/css" href="css/contact_us.css">

<?php
if(!empty($_POST["UserName"]) ){
    

    $found = false;
    $UserName = $_POST["UserName"];
    //$email = $_POST["email"];
    $file = fopen("Sign_Up_Information.txt", "r");
}
if($file)
{
    while(($line = fgets($file)))
    {
       
        $array = explode(":", $line);
        
        if($array[0] == $UserName){
            echo $UserName;
            $found=true;
            fclose($file);
        
        }

        if($found)
        {
            echo '<script>alert("Your request has been submitted!\nHere is your order summary: \n- 1 Milk  $6.86\n- 1 Cheese  $5.49\n- 2 Spaghetti   $2.39 x2\n Total: $17.13 +tx\n We will get back to you soon!")</script>';
        }else {
            echo "File is not found...Please Sign Up";
            header("Location:P6.php ");
            }
            
    }
}     
    ?>
<br />
<br />
</body>
</html>
