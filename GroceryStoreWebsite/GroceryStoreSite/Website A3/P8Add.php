<?php
session_start();
global $i;
$thisPage = basename($_SERVER["PHP_SELF"]);
include "header_P7.php";

if (array_key_exists("submit", $_POST) && validate()) {
    setValues();
}
function setValues()
{
    $_POST["image"] = "images\\" . $_POST["image"];
    $added = array(array($_POST["image"], $_POST["product"], $_POST["price"], $_POST["weight"], 0, $_POST["quantity"], $_POST["size"], $_POST["type"], $_POST["nutritional_source"]));
    array_splice($_SESSION["products"][$_SESSION["add"]], count($_SESSION["products"][$_SESSION["add"]]), 0,  $added);  //fix this
    header("Location: P7.php");
    exit();
}

if (isset($_POST["cancel"])) {
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

<body>
    <form class="form-horizontal" name="Form" method="POST">
        <div class="form-group">
            <label for="inputName3" class="col-sm-2 control-label">
                <br />
                <h3>Add Product</h3>
            </label>
        </div>
        <div class="form-group">
            <label for="inputName3" class="col-sm-2 control-label">
                <h5>Select Image<span style="font-size:15px"> (png or jpg)</span>:</h5>
            </label>
            <div class="col-sm-10">
                <input name="image" type="file" class="form-control" accept="image/png, image/jpeg" id="inputName3" placeholder="jpeg and png only" />
            </div>
        </div>
        <div class="form-group">
            <label for="inputName3" class="col-sm-2 control-label">
                <h5>Product:</h5>
            </label>
            <div class="col-sm-10">
                <input name="product" type="text" class="form-control" id="inputName3" placeholder="ex: Banana" />
            </div>
        </div>

        <div class="form-group">
            <label for="inputDescription3" class="col-sm-2 control-label">
                <h5>Description:</h5>
            </label>

            <div class="form-group">
                <div class="col-sm-10">
                    <label for="title">Quantity:</label>
                    <input name="quantity" type="text" class="form-control" placeholder="ex: 46 (per box)" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-10">
                    <label for="title">Size:</label>
                    <input name="size" type="text" class="form-control" placeholder="ex: 8cm" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-10 ">
                    <label for="title ">Type:</label>
                    <input name="type" type="text" class="form-control" placeholder="ex: Beverage" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-10 ">
                    <label for="title ">Nutritional Source:</label>
                    <input name="nutritional_source" type="text" class="form-control" placeholder="ex: Potassium, Fiber" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <label for="inputQuantity3" class="col-sm-2 control-label">
                <h5>Price:</h5>
            </label>
            <div class="col-sm-10">
                <input name="price" type="text" class="form-control" id="inputPrice3" placeholder="ex: $0.33" />
            </div>
            <br />
            <label for="inputQuantity3" class="col-sm-2 control-label">
                <h5>Weight per $:</h5>
            </label>
            <div class="col-sm-10">
                <input name="weight" type="text" class="form-control" id="inputPrice3" placeholder="ex: 190g" />
            </div>
        </div>

        <div>
            <br />
            <button type="submit" name="cancel" value="Cancel" class="btn btn-secondary btn-lg btn-block" style="width:100px">Cancel</button>
            <br />
            <button type="submit" onclick="" name="submit" value="Enter" class="btn btn-secondary btn-lg btn-block" style="width:100px">Save</button>
        </div>
    </form>
</body>

</html>
