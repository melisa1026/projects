<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <link rel="stylesheet" type="text/css" href="css/P9_P10.css" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script type="text/javascript" src="P9P10.js"></script>
    <title><?php $thisPage ?></title>
</head>

<body>
    <nav class="navbar navbar-expand-md" id="top_bar">
        <a class="navbar-brand"></a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
            <span class="navbar-toggler-icon"> &#9660</span>
        </button>

        <div class="collapse navbar-collapse justify-content-end" id="collapsibleNavbar">
            <ul class="navbar-nav">
                <a class="nav-link" href="P1.php">Homepage</a>
                </li>
               <li class="nav-item">
                    <a class="nav-link" href="P7.php">Product list</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="P9.php">User list</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" href="P11.php">Order list</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="logout_P7.php">End Session</a>
                </li>
            </ul>
        </div>
    </nav>

    <div class="header">
        <h1>Concordia Supermarket</h1>
        <p>Best place to find all your needs</p>
    </div>

    <?php if (basename($_SERVER['PHP_SELF']) === "P9.php") { ?>

        <nav class="navbar navbar-expand-md">
            <a class="navbar-brand" href="">Categories</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                <span class="navbar-toggler-icon"> &#9660</span>
            </button>

            <div class="collapse navbar-collapse" id="collapsibleNavbar">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="P2.php?aisle_id=1">Vegetable and fruits</a>
                    </li>       
                    
                    <li class="nav-item">
                        <a class="nav-link" href="P2.php?aisle_id=2">Dairy and Eggs</a>
                    </li> 

                    <li class="nav-item">
                        <a class="nav-link" href="P2.php?aisle_id=3">Pantry</a>
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
        <br />
    <?php  } ?>
