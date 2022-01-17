<?php
session_start();
if(!isset($_POST["sumbitButton"]))
{

?>
<html lang = "en">
<head>
<meta charset = "utf-8" />

<meta name="viewport" content="width=device-width, initial-scale=0">

<meta http-equiv="X-UA-Compatible" content="IE=edge" /> 

<title>Log In</title> 
  
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <link rel="stylesheet" type="text/css" href="css/P5P6_loginStyle.css">


    <nav class="navbar navbar-expand-md" id="top_bar">
        <a class="navbar-brand"></a>
        <button id ="top" class="navbar-toggler" type="button" data-toggle="collapse" data-target="#first">
            <span id="top_icon" class="navbar-toggler-icon">&#9660</span>
        </button>

        <div class="collapse navbar-collapse" id="first">
            <ul class="navbar-nav">

                <li class="nav-item">
                    <a class="nav-link" href="p5.php">Login</a>
                </li> 

                <li class="nav-item">
                    <a class="nav-link" href="p6.php">Sign Up</a>
                </li> 

            </ul>
        </div>
    </nav>

        <div class="header">
        <a class="nav-link" href="p1.php">
            <h1>Concordia Supermarket</h1>
        </a>
        <p>Best place to find all your needs</p>

    </div>

    <nav class="navbar navbar-expand-md" id="bottom_bar">
        <a class="navbar-brand" href="">Categories</a>
        <button id="bottom" class="navbar-toggler" type="button" data-toggle="collapse" data-target="#second">
            <span id="bottom_icon" class="navbar-toggler-icon"> &#9660</span>
        </button>

        <div class="collapse navbar-collapse" id="second">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="P2.php?aisle_id=1">Vegetable and fruits</a>
                </li>       
                
                <li class="nav-item">
                    <a class="nav-link" href="P2.php?aisle_id=2">Dairy and Eggs</a>
                </li> 

                <li class="nav-item">
                    <a class="nav-link" href="aP2.php?aisle_id=3">Pantry</a>
                </li> 

                <li class="nav-item">
                    <a class="nav-link" href="P2.php?aisle_id=4">Beverages</a>
                </li> 

                <li class="nav-item">
                    <a class="nav-link" href="P2.php?aisle_id=5">Meat and Poultry</a>
                </li> 

                <li class="nav-item">
                    <a class="nav-link" href="P2.php?aisle_id=6">Snacks</a>
                </li> 
            </ul>
        </div>
    </nav>

</head>

<body>
<div class="login-form">
    <form action="<?php echo ($_SERVER["PHP_SELF"]);?>" 
    method="post" name="form" id = "myForm">
         <h1>Log In</h1>
            

            <label><b>
            Email: 
            <input class="form-control" type="text" name="email" id = "email">
            <br/><br/>
            </b></label>

            <label><b>
            Password:
            <input class="form-control" type="password" name="password" id = "password">
            <br/><br/>
            </b></label>        

            <div>
            <a href="P5P6_forgotPassword.html" target="_blank">Forgot Password?</a>
            <br/>
           </div>


            <input class="btn btn-secondary btn-lg btn-block" type="reset" value="Reset" id="reset"/>
            <input class="btn btn-secondary btn-lg btn-block" type="submit" value="Submit" name="submitButton" /><br />
            <style>
            .btn
            {
              background: rgb(180, 60, 60);
              border-radius: 4px;
              border: 2px solid rgb(180, 60, 60);
              font-size: 15px;
            }
            .btn:hover {
              background: #c2bebe;
              color: #fff;
              border: 2px solid #c2bebe;
            }
            </style>

            <div>
                <p>Don't have an account?
                    <a href="p6.php" target="_blank"> Create an account.</a>
                </p>
            </div>
            <br /><br /><br /><br /><br /><br />
            


    </form>
    
</div>

<script>
//validate login form
function formValidation () {
  //retrieve email
  var email = document.getElementById("email").value;
  var pattern = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

  //retrieve password
  var pass = document.getElementById("password").value;

  //variables
  var checkEmail = ""

  //variables to check if empty
  var isEmptyEmail= "";
  var isEmptyPassword= "";

    //validate email
    if (!(email.match(pattern)) && (email != 'admin'))
    {
        document.getElementById("email").style.borderColor = "red";
        checkEmail = " Email ";
        
    } else if ((email.match(pattern)) || (email == 'admin'))
    {
      document.getElementById("email").style.borderColor = "green";
    }

    //Is email empty
    if(email == "")
    {
        document.getElementById("email").style.borderColor = "red"
        isEmptyEmail = " Email ";  
    }

    //validate password
    if (pass == "") 
    {
        document.getElementById("password").style.borderColor = "red";
        isEmptyPassword= " Password ";

    }else
    {
    document.getElementById("password").style.borderColor = "green";
    }

    //check and display inputs that are invalid
    if (checkEmail != ""||isEmptyEmail != ""||isEmptyPassword != ""){
        alert("Invalid: "+ checkEmail + "\nEmpty Fields:"+ isEmptyEmail + isEmptyPassword);
        return false;
    //else return a prompt saying valid submission
    }else{
        if (!(pass == "") && (email.match(pattern))){
            <?php $invalid = false;?>

            <?php 

            if(!empty($_POST["email"]) && !empty($_POST["password"]&& $invalid != true))
            {

                $found = false;
                $email = $_POST["email"];
                $password = $_POST["password"];

                $file = fopen("Sign_Up_Information.txt", "r");
                if($file) 
                {
                    while(($line = fgets($file)) !== false)
                    {
                        $array = explode(":", $line);
                        if($array[0] == $email)
                        {
                            if(trim($array[1]) === $password)
                            {
                                $found=true;
                                fclose($file);
                            }
                        }
                    } 

                }else
                {?>
                    alert("No account exists...Please Sign Up");
                <?php

                }

                if(!$found && $_POST["email"]=="admin"&&$_POST["password"]=="admin")
                {
                    $_SESSION['email']="admin";
                    header("Location:admin.php");
                }

                if(!$found && !($_POST["email"]=="admin")&&!($_POST["password"]=="admin"))
                {
                header('Location: InvalidLogIn.php');
                    
                    fclose($file);
                }else if (!($_POST["email"]=="admin")&&!($_POST["password"]=="admin")){
                header('Location: LoginSuccess.php');
        
                }
                

            }

            ?>

            return true;
        }


    }
}

//reset boarder colors on "reset"
function resetInputs()
{

  document.getElementById('email').style.borderColor = "";
  document.getElementById('password').style.borderColor = "";

  
} 

// on sumbit validate login form
document.getElementById("myForm").onsubmit = formValidation;

// on reset , reset boarder colors in login form
document.getElementById("reset").onclick = resetInputs;

</script>

<div class="footer" >
      <button class="collapsible" id="info_button">Info</button>
      <div class="content">
          <br>
          <h3>Welcome to Concordia Supermarket! </h3>
          <p>Click on any aisle to be brought to a page of products. Add these products to your cart and get an estimation on how much they'll cost!</p>
      </div>

      <script>
        var bt = document.getElementById("info_button");

        bt.addEventListener("click", function() {
            this.classList.toggle("active");

            var content = this.nextElementSibling;
            if (content.style.maxHeight){
            content.style.maxHeight = null;
            } 
            else {
            content.style.maxHeight = content.scrollHeight + "px";
            } 
        });
    </script>
</div>

</body>
</html>

<?php
}?>

