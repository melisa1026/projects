<?php
session_start();
$thisPage = basename($_SERVER["PHP_SELF"]);
include "header_P7.php";

if (array_key_exists("update", $_POST) && validate()) {
    setValues();
}
function setValues()
{
    $_POST["image"] = "images\\" . $_POST["image"];
    $added = array(array($_POST["image"], $_POST["product"], $_POST["price"], $_POST["weight"], 0, $_POST["quantity"], $_POST["size"], $_POST["type"], $_POST["nutritional_source"]));
    array_splice($_SESSION["products"][$_SESSION['num1']], $_SESSION['num2'], 1,  $added);  //fix this
    header("Location: P7.php");
    exit();
}

if (isset($_POST["cancel1"])) {
    header("Location: P7.php");
    exit();
}
function validate()
{
    if (empty($_POST["image"]) || empty($_POST["product"]) || empty($_POST["quantity"]) || empty($_POST["size"]) || empty($_POST["type"]) || empty($_POST["nutritional_source"]) || empty($_POST["price"] || empty($_POST["weight"]))) {
        echo "<script>alert('Not all boxes filled.');</script>";
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
            <label for="inputName3" class="col-sm-2 control-label">
                <br />
                <h3>Edit Product</h3>
            </label>
        </div>
        <div class="form-group">
            <label for="inputName3" class="col-sm-2 control-label">
                <h5>Select Image<span style="font-size:15px"> (png or jpg)</span>:</h5>
            </label>
            <div class="col-sm-10">
                <input name="image" type="file" class="form-control" accept="image/png, image/jpeg" id="inputName3" value="<?php echo $_SESSION['products'][$_SESSION['num1']][$_SESSION['num2']][0] ?>" />
            </div>
        </div>
        <div class="form-group">
            <label for="inputName3" class="col-sm-2 control-label">
                <h5>Product:</h5>
            </label>
            <div class="col-sm-10">
                <input name="product" type="name" class="form-control" id="inputName3" value="<?php echo $_SESSION['products'][$_SESSION['num1']][$_SESSION['num2']][1] ?>" />
            </div>
        </div>

        <div class="form-group">
            <label for="inputDescription3" class="col-sm-2 control-label">
                <h5>Description:</h5>
            </label>

            <div class="form-group">
                <div class="col-sm-10">
                    <label for="title">Quantity:</label>
                    <input name="quantity" type="description" class="form-control" value="<?php echo $_SESSION['products'][$_SESSION['num1']][$_SESSION['num2']][5] ?>" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-10">
                    <label for="title">Size:</label>
                    <input name="size" type="description" class="form-control" value="<?php echo $_SESSION['products'][$_SESSION['num1']][$_SESSION['num2']][6] ?>" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-10 ">
                    <label for="title ">Type:</label>
                    <input name="type" type="description" class="form-control" value="<?php echo $_SESSION['products'][$_SESSION['num1']][$_SESSION['num2']][7] ?>" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-10 ">
                    <label for="title ">Nutritional Source:</label>
                    <input name="nutritional_source" type="description" class="form-control" value="<?php echo $_SESSION['products'][$_SESSION['num1']][$_SESSION['num2']][8] ?>" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <label for="inputQuantity3" class="col-sm-2 control-label">
                <h5>Price:</h5>
            </label>
            <div class="col-sm-10">
                <input name="price" type="text" class="form-control" id="inputPrice3" value="<?php echo $_SESSION['products'][$_SESSION['num1']][$_SESSION['num2']][2] ?>" />
            </div>
            <br />
            <label for="inputQuantity3" class="col-sm-2 control-label">
                <h5>Weight per $:</h5>
            </label>
            <div class="col-sm-10">
                <input name="weight" type="text" class="form-control" id="inputPrice3" value="<?php echo $_SESSION['products'][$_SESSION['num1']][$_SESSION['num2']][3] ?>" />
            </div>
        </div>
        <div>
            <br />
            <button type="submit" value="Enter" name="cancel1" class="btn btn-secondary btn-lg btn-block" style="width:100px">Cancel</button>
            <br />
            <button type="submit" value="Enter" name="update" class="btn btn-secondary btn-lg btn-block" style="width:100px">Update</button>

        </div>
    </form>
</body>

</html>
