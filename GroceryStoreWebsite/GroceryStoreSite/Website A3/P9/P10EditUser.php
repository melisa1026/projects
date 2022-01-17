<?php
session_start();
$thisPage = basename($_SERVER["PHP_SELF"]);
include "header_P9.php";


if (array_key_exists("update", $_POST) && check()) {
    settingValue();
}





function settingValue()
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

if (isset($_POST["cancel"])) {
    header("Location: P7.php");
    exit();
}

function check()
{
    if (empty($_POST["name"]) || empty($_POST["email"]) ) {
        echo "You have missed some boxes.";
        return false;
    } else {
        return true;
    }
}

?>

</head>

<body>
    <form class="form-horizontal" name="Form" method="POST">
        <div class="form-group">
            <label for="inputUser1" class="col-sm-4 control-label">
                <br />
                <h3>Edit User</h3>
            </label>
        </div>
        <div class="form-group">
           
            <div class="col-sm-10">
                <h4> name of user</h4>
                <input name="name" type="text" class="form-control"  id="inputUser1" >
            </div>
        </div>

        <div class="form-group">
            
            <div class="col-sm-10">
            <h4> email of user</h4>
                <input name="email" type="text" class="form-control" id="inputUser1" >
            </div>
        </div>

        <div>
            <br />
            <button type="submit" value="Enter" name="cancell" class="btn btn-secondary btn-lg btn-block" style="width:100px">Cancel</button>
            <br />
            <button type="submit" value="Enter" name="submit" class="btn btn-secondary btn-lg btn-block" style="width:100px">Submit</button>

        </div>
    </form>
</body>

</html> 