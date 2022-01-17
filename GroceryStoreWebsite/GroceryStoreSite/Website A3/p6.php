<!DOCTYPE html>

<html lang = "en">
<head> 
<meta charset="utf-8"/>

<meta name="viewport" content="width=device-width, initial-scale=0"> 

<title>Sign Up</title> 

<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <link rel="stylesheet" type="text/css" href="css/P5P6_signupStyle.css">

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
  <div class="signup-form">
      <form action="<?php echo ($_SERVER["PHP_SELF"]);?>" 
      method="post" name="form" id = "myForm">
        <h1>Sign Up</h1>

        <label><b>
        First Name:
        <input class="form-control" type="text" name="firstName" id = "firstName"/> 
        <br /><br />	 
        </b></label>

        <label><b>
        Last Name:
        <input class="form-control" type="text" name="lastName" id = "lastName"/> 
        <br /><br />	
        </b></label>

        <label><b>
        Email: 
        <input class="form-control" type="email" name="email" id = "email"/> 
        <br /><br />
        </b></label>

        <label><b>
        Postal Code (optional): 
        <input class="form-control" type="text" name="pstCode" id = "pstCode"/>
        <br /><br />
        </b></label>

        <label><b>
        Password: 
        <input class="form-control" type="password" name="init_password" id = "init_password"/> 
        <br /><br />
        </b></label>

        <label><b>
        Confirm Password: 
        <input class="form-control" type="password" name="sec_password" id = "sec_password"/>
        <br /><br />
        </b></label>

        <input class="btn btn-secondary btn-lg btn-block" type="reset" value="Reset" id="reset"/>
        <input class="btn btn-secondary btn-lg btn-block" type="submit" value="Submit" name="submitButton" /><br /><br /><br /><br /><br /><br /><br /><br />
        
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
        </form> 

</div>

<script>
  function formValidation()
  {
  //retrieve names
  var firstName = document.getElementById("firstName").value;
    var lastName = document.getElementById("lastName").value;
    var pattern1 = /^[a-zA-Z]+(?:-[a-zA-Z]+)*$/;

    //retrieve email
    var email = document.getElementById("email").value;
    var pattern2 = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    
    //retrieve postal code
    var pstCode = document.getElementById("pstCode").value;
    var pattern3 = /^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$/;

    // retrieve the passwords entered
    var init = document.getElementById("init_password");
    var sec = document.getElementById("sec_password");

    //variables for validation
    var checkFirstName = "";
    var checkLastName= "";
    var checkEmail= "";
    var checkPostalCode= "";

    //variables to check if empty
    var isEmptyFirstName = "";
    var isEmptyLastName= "";
    var isEmptyEmail= "";
    var isEmptyPostalCode= "";
    var isEmptyInit_Password= "";
    var isEmptySec_Password="";

    //validate first name
    if (!(firstName.match(pattern1)))
    {
        document.getElementById("firstName").style.borderColor = "red";
        checkFirstName = " First Name ";
        
    } 
    else
    {
        document.getElementById("firstName").style.borderColor = "green";
    }

    //Is first name empty
    if(firstName == "")
    {
        document.getElementById("firstName").style.borderColor = "red";
        isEmptyFirstName = " First Name ";  
    }

    //validate last name
    if (!(lastName.match(pattern1)))
    {
        document.getElementById("lastName").style.borderColor = "red";
        checkLastName = " Last Name ";
        
    }  
    else
    {
      document.getElementById("lastName").style.borderColor = "green";
    }
    
    //Is last name empty
    if(lastName == "")
    {
        document.getElementById("lastName").style.borderColor = "red";
        isEmptyLastName = " Last Name ";  
    }

    //validate email
    if (!(email.match(pattern2)))
    {
        document.getElementById("email").style.borderColor = "red";
        checkEmail = " Email ";
        
    } else
    {
      document.getElementById("email").style.borderColor = "green";
    }

      //Is email empty
      if(email == "")
      {
        document.getElementById("email").style.borderColor = "red"
        isEmptyEmail = " Email ";  
      }
    

    //validate postal code
    if (!(pstCode.match(pattern3)))
    {
        document.getElementById("pstCode").style.borderColor = "red";
        checkPostalCode = " Postal Code ";
        
    } else
    {
      document.getElementById("pstCode").style.borderColor = "green";
    }

      //Is postal code empty
      if(pstCode == "")
      {
        document.getElementById("pstCode").style.borderColor = "red";
        isEmptyPostalCode = " Postal Code ";  
      }

    //if the two passwords are not the same
    if (init.value != sec.value) 
    {
      document.getElementById("init_password").style.borderColor = "red";
      document.getElementById("sec_password").style.borderColor = "red";
      alert("The two passwords are not the same.\n" + "Please re-enter.");
      
    }else if ((init.value == sec.value)&& init.value != ""&&sec.value != "") {
      document.getElementById("init_password").style.borderColor = "green";
      document.getElementById("sec_password").style.borderColor = "green";
      
    }

      //Is first passcode empty
      if(init.value == "")
      {
        document.getElementById("init_password").style.borderColor = "red";
        isEmptyInit_Password = " Password Field ";  
      }

      //Is second passcode empty
      if(sec.value == "")
      {
        document.getElementById("sec_password").style.borderColor = "red";
        isEmptySec_Password = " Confirm Password Field ";  
      }

      if (checkFirstName != ""|| checkLastName != ""|| checkEmail != ""|| (checkPostalCode != ""|| isEmptyFirstName != ""||
      isEmptyLastName != ""|| isEmptyEmail != ""|| isEmptyPostalCode != ""||isEmptyInit_Password != ""||isEmptySec_Password !="" ))
      {
        alert("Invalid inputs: " + checkFirstName + checkLastName + checkEmail + checkPostalCode+"\nEmpty Fields: "
        + isEmptyFirstName + isEmptyLastName+ isEmptyEmail+isEmptyPostalCode+isEmptyInit_Password+isEmptySec_Password);
        <?php $invalid = true;?>
        return false;
      } else {
        if (!(init.value != sec.value) && !(init.value == "")){
          confirm("valid submission");
          <?php $invalid = false;?>
        }  

      }

      <?php
            if(!empty($_POST["firstName"]) && !empty($_POST["lastName"]) && !empty($_POST["email"]) && !empty($_POST["pstCode"]) && !empty($_POST["init_password"]) && !empty($_POST["sec_password"]) && $invalid != true){
            $found = false;
            $email = $_POST["email"];
            $password = $_POST["sec_password"];
  
            $file = fopen("Sign_Up_Information.txt", "r");
  
            if($file)
            {
              while(($line = fgets($file)))
              {
                $array = explode(":", $line);
  
                if($array[0] == $email){
                    $found=true;
                    fclose($file);
                }
  
              }

              
            }else  
            {
              $firstFile = true;
              $file = fopen("Sign_Up_Information.txt", "a");
  
              fputs($file, "$_POST[email]:");
              fputs($file, "$_POST[sec_password]\n");
              fclose($file);
            }

            if ($found)
            {
              header("Location: accountExists.php");
 
            }else if (!$found && !$firstFile){
              $file = fopen("Sign_Up_Information.txt", "a");
  
              fputs($file, "$_POST[email]:");
              fputs($file, "$_POST[sec_password]\n");
              fclose($file);

              //Welcome to the site
              header("Location: accountCreated.php");
 
            }else if (!$found && $firstFile){

              //Welcome to the site
              header("Location: accountCreated.php");

            }else{
              header("Location: errorPage.php");
            }
          }
           ?>

  }

  //reset boarder colors
  function resetInputs()
  {
    
    document.getElementById('firstName').style.borderColor = "";
    document.getElementById('lastName').style.borderColor = "";
    document.getElementById('email').style.borderColor = "";
    document.getElementById('pstCode').style.borderColor = "";
    document.getElementById('init_password').style.borderColor = "";
    document.getElementById('sec_password').style.borderColor = "";

  } 
  document.getElementById("myForm").onsubmit = formValidation;
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
