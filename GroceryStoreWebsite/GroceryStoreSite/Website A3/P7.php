<?php
session_start();
include("header_P7.php");
$product_array = $_SESSION["products"];
$_SESSION["categories"] = array("Vegetables and Fruits", "Dairy and Eggs", "Pantry", "Beverages", "Meat and Poultry", "Snacks");
$categories = $_SESSION["categories"];



//Add
for ($i = 0; $i < count($_SESSION["products"]); $i++) {
    if (isset($_POST["add" . $i])) {
        $_SESSION["add"] = $i;
        header("Location: P8Add.php");
        exit();
    }
}

//Edit
for ($i = 0; $i < count($_SESSION["products"]); $i++) {
    for ($j = 0; $j < count($_SESSION["products"][$i]); $j++) {
        if (isset($_POST["edit" . $i . $j])) {
            $_SESSION["edit"] = $i.$j;
            $_SESSION["num1"] = $i;
            $_SESSION["num2"] = $j;
            header("Location: P8Edit.php");
            exit();
        }
    }
}

//Delete
for ($i = 0; $i < count($_SESSION["products"]); $i++) {
    for ($j = 0; $j < count($_SESSION["products"][$i]); $j++) {
        if (isset($_POST["delete" . $i . $j])) {
            array_splice($_SESSION["products"][$i], array_search($_SESSION["products"][$i][$j], $_SESSION["products"]), 1);
        }
    }
}

file_put_contents("products.txt", json_encode($product_array));

echo "<br/><br/>";
$products = $_SESSION["products"];
for ($i = 0; $i < count($_SESSION["products"]); $i++) {
    $_SESSION["count"] = $i;
    echo "<h4 id=category" . $i . ">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp$categories[$i]</h4>";
    echo "<table border='2' id = 'table" . ($_SESSION['count']+1) . "'>
            <tr>
                <th>Image</th>
                <th>Product</th>
                <th>Description</th>
                <th>Price</th>
                    <form method = 'POST'> 
                        <th><input name = 'add" . $_SESSION['count'] . "' type='submit' value='Add' class='btn btn-secondary btn-lg btn-block' style='width:125px' id='add'></th>
                    </form>
            </tr>";

    for ($j = 0; $j < count($_SESSION["products"][$i]); $j++) {
        $_SESSION["num1"] = $i;
        $_SESSION["num2"] = $j;
        echo "<tr name = " . $_SESSION["num1"] . $_SESSION["num2"] . ">";
        echo "<td><img src=" . $_SESSION["products"][$i][$j][0] . " width='100' height='100'></td>
                    <td>" . $_SESSION["products"][$i][$j][1] . "</td>
                    <td>
                    <br/>
                    <ul>
                        <li>Quantity:
                            " . $_SESSION["products"][$i][$j][5] . "</li><li>Size:
                            " . $_SESSION["products"][$i][$j][6] . "</li><li>Type:
                            " . $_SESSION["products"][$i][$j][7] . "</li><li>Nutritional Source:
                            " . $_SESSION["products"][$i][$j][8] . "
                        </li>
                    <ul>
                </td>
                <td>" . $_SESSION["products"][$i][$j][2] . "/" . $_SESSION["products"][$i][$j][3] . "</td>
                <td>
                    <form method = 'POST'>
                      <input type='submit' name='edit" .  $_SESSION["num1"].  $_SESSION["num2"] . "' value='Edit' class='btn btn-secondary btn-lg btn-block' style='width:100px' id='edit-delete'>
                    </form>
                <br/>
                    <form method = 'POST'>
                         <input type = 'submit' name = 'delete" . $i . $j . "' value='Delete' class='btn btn-secondary btn-lg btn-block' style='width:100px' id='edit-delete'>
                    </form>
            </td>";

        echo "</tr>";
    }
    echo "</table><br/><br/>";
    $_SESSION["i"]++;
}

?>


</body>

</html>
