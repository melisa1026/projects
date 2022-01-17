<?php
session_start();

if($_SESSION["email"]=="admin"){
    if(!isset($_POST['logout'])){
        echo "";
?>

<html lang = "en">
<head>
<title>User Log In</title>
<meta charset="utf-8"/>

<meta name="viewport" content="width=device-width, initial-scale=0">  

<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

<link rel="stylesheet" type="text/css" href="css/P5P6_loginStyle.css">

<nav class="navbar navbar-expand-md" id="top_bar">
            <a class="navbar-brand"></a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                <span class="navbar-toggler-icon"> &#9660</span>
            </button>
    
            <div class="collapse navbar-collapse justify-content-end" id="collapsibleNavbar">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="P4.php">Grocery Cart</a>
                    </li>       

                    <li class="nav-item">
                        <a class="nav-link"  href="logout.php">Log Out</a>
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
<form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>" method="post">
        <h1>Welcome Back!</h1>
        <p>Click on the Concordia Supermarket title to got to the homepage.</p>
</form>


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

<?php
    //if(!isset($_POST['logout'])){unset($_SESSION["email"]);}

    }else{
        unset($_SESSION["email"]);
    }
}else{
    header('Location: redirectToLogin.php');
}
?>
