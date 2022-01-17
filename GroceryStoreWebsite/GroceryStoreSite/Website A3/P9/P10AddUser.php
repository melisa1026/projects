<?php

session_start();

$thisPage = basename($_SERVER["PHP_SELF"]);

include "header_P9.php";



function valueSet()
{
    if (isset($_POST["submit"]) && !empty($_POST["submit"]))
     {
        $_SESSION["name"] = $_POST["name"];
        $_SESSION["email"] = $_POST["email"];
        $_SESSION["submit"] = $_POST["submit"];
        header("Location: P9.php");
        exit();
    }

     else 
    {
        echo "There has been an error !";
    }
}

if (array_key_exists("submit", $_POST)) 
{
    valueSet();
}

if (isset($_POST["cancel"])) 
{
    header("Location: P9.php");
    exit();
}


?>

<script type="text/javascript">


    function Check() {
        var name = document.getElementsByName("name").value;
        var email = document.getElementsByName("email").value;
       
        if ((name == null || name == "") && (email == null || email == "") )
        {
            alert("You have not filled all the boxes!");

            return false;
        }
    }
</script>


</head>

<body>
    <form class="form-horizontal" name="Form" method="POST">

        <div class="form-group">


            <label for="inputUser" class="col-sm-4 control-label">
                <br />
                <h4>Add User</h3>
            </label>
        </div>


        <div class="form-group">
            <label for="inputUser" class="col-sm-4 control-label">
                <h5>Name of User</h5>
            </label>
            <div class="col-sm-8">
                <input name="name" type="text" class="form-control" id="inputUser" >
            </div>
        </div>


        <div class="form-group">
            <label for="inputUser" class="col-sm-4 control-label">
                <h5>Email of User</h5>
            </label>
            <div class="col-sm-8">
                <input name="email" type="text" class="form-control" id="inputUser" >
            </div>
        </div>

        <?php
            if((isset($_POST['name'])) && (isset($_POST['email']))){
  
                //$user_file = (fopen('users.txt', 'a')) || (die("Cannot open file"));
                if (fopen('users.txt', 'a')){
                    $user_file = (fopen('users.txt', 'a'));
                }else{
                    die("Cannot open file");
                }
                $string_user = ("\n" . $_POST['name']);
                fwrite($user_file, $string_user);
                fclose($user_file);
            }
        ?>

        <div>
            <br />
            <form action="P9.php">
            <button type="submit" onclick="" name="submit" value="Enter" class="btn btn-secondary btn-lg btn-block" style="width:100px">Submit</button>
            <br />
            <button type="submit" name="cancel" value="Cancel" class="btn btn-secondary btn-lg btn-block" style="width:100px">Cancel</button>
            <form>
        </div>


    </form>
    
</body>

</html>
