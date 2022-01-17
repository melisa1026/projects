<!DOCTYPE html>
<?php session_start();
include("header_P9.php");

$file = fopen("users.txt", "r");
$fsize = filesize("users.txt");
$page = fread($file, $fsize);
fclose($file);
$output = explode(PHP_EOL, $page);


?>

<html lang="en">

<head>
  
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/P9P10.css">

</head>

<body>
       
    <script type="text/javascript">
        function deleteUser(user)
        {
            var item = document.getElementById(user);
            item.remove();
        }
    </script>

    </br>
         
    <table id="myTable">
    </br>
    </br>
    <tr>
        <th>First/Last Name</th>
        <th>created</th>
        <th>E-mail</th>
        
        <form action="P10AddUser.html" id="add">
            <th> <button type="submit" value="Add" class="btn btn-secondary btn-lg btn-block">Add User</button></th>
        </form>
    </tr>

    <tr id="user1">
        <td>Emily thomas</td>
        <td>19/02/2021</td>
        <td>Emilythompson@hotmail.com</td>
        <td>
            <form action="P10EditUser.html">
                <button type="submit" value="Edit" class="btn btn-secondary btn-lg btn-block"  >Edit</button>
                </form>
                <br />
            
                <form>
                <button onclick = "deleteUser('user1')" style="font-size:24px;" type="button" value="Delete" class="btn btn-secondary btn-lg btn-block"><em class="fa fa-trash-o"></em></button>
            </form>

        </td>
    </tr>

    <tr id="user2">
        
        <td>Sydney London</td>
        <td>11/02/2021</td>
        <td>sydlon@hotmail.com</td>
        <td>
            <form action="P10EditUser.html">
                <button type="submit" value="Edit" class="btn btn-secondary btn-lg btn-block">Edit</button>
                </form>
                <br />
                <form>
                <button onclick = "deleteUser('user2')" style="font-size:24px;" type="button" value="Delete" class="btn btn-secondary btn-lg btn-block"><em class="fa fa-trash-o"></em></button>
            </form>

        </td>
    </tr>

    <tr id="user3">
        <td>Jordan Terry</td>
        <td>13/02/2021</td>
        <td>jterry0927@hotmail.com</td>
        <td>
            <form action="P10EditUser.html">
                <button type="submit" value="Edit" class="btn btn-secondary btn-lg btn-block">Edit</button>
                </form>
                <br />
                <form>
                <button onclick = "deleteUser('user3')" style="font-size:24px;" type="button" value="Delete" class="btn btn-secondary btn-lg btn-block"><em class="fa fa-trash-o"></em></button>
            </form>
        </td>
    </tr>

    <tr id="user4">
        <td>Sandra Samuel</td>
        <td>15/02/2021</td>
        <td>sandrasam0257@hotmail.com</td>
        <td>
            <form action="P10EditUser.html">
                <button type="submit" value="Edit" class="btn btn-secondary btn-lg btn-block">Edit</button>
                </form>
                <br />
                <form>
                <button onclick = "deleteUser('user4')" style="font-size:24px;" type="button" value="Delete" class="btn btn-secondary btn-lg btn-block"><em class="fa fa-trash-o"></em></button>
            </form>
        </td>
    </tr>

    <tr id="user5">
        <td>Brooke Sands</td>
        <td>14/02/2021</td>
        <td>BrookeS26342@hotmail.com</td>
        <td>
            <form action="P10EditUser.html">
                <button type="submit" value="Edit" class="btn btn-secondary btn-lg btn-block">Edit</button>
                </form>
                <br />
                <form>
                <button onclick = "deleteUser('user5')" style="font-size:24px;" type="button" value="Delete" class="btn btn-secondary btn-lg btn-block"><em class="fa fa-trash-o"></em></button>
            </form>
        </td>
    </tr>

    <tr id="user6">
        <td>claude ernest</td>
        <td>19/02/2021</td>
        <td>Claudeerrn53902@hotmail.com</td>
        <td>
            <form action="P10EditUser.html">
                <button type="submit" value="Edit" class="btn btn-secondary btn-lg btn-block">Edit</button>
                </form>
                <br />
                <form>
                <button onclick = "deleteUser('user6')" style="font-size:24px;" type="button" value="Delete" class="btn btn-secondary btn-lg btn-block"><em class="fa fa-trash-o"></em></button>
            </form>
        </td>
    </tr>

</table>
</body>

</html>
    
