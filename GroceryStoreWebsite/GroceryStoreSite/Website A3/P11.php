<?php

    session_start();

        //Fruits and Vegetables (0)
        $product_array = array ( 
            array(
                array ( "images\\banana.png", "Banana", "0.33"), 
                array ( "images\\apple.png", "Apple", "0.86"),
                array ( "images\\tomato.png", "Tomato", "1.76"), 
                array ( "images\\lettuce.png", "Lettuce", "2.99"),
                array ( "images\\carrot.png", "Carrot", "1.99"),
                array ( "images\\onion.png", "Onion", "4.39")
            ),

            //Diary and Eggs (1)
            array ( 
                array ( "images\\eggs.jpg", "Eggs", "3.49"),
                array ( "images\\milk.png", "Milk", "6.86"), 
                array ( "images\\cheese.png", "Cheese", "5.49"),  
                array ( "images\\butter.png", "Butter", "4.69"),    
                array ( "images\\yogurt.png", "Yogurt", "6.99"),
                array ( "images\\cream_cheese.jpg", "Cream Cheese", "5.49")
            ), 

            //Pantry (2)
            array ( 
                array ( "images\\ketchup.png", "Ketchup", "3.99"),
                array ( "images\\salt.png", "Salt", "6.49"),
                array ( "images\\sugar.jpg", "Sugar", "3.49"),
                array ( "images\\olive oil.png", "Olive Oil", "12.99"),
                array ( "images\\spaghetti.jpg", "Spaghetti", "2.39"),
                array ( "images\\mayonnaise.jpg", "Mayonnaise", "6.49")
            ),

            //Beverages (3)
            array ( 
                array ( "images\\water.png", "Water", "4.49"),
                array ( "images\\juice.png", "Juice", "2.79"),
                array ( "images\\coca-cola.png", "Soft Drink (Coca Cola)", "1.89"),
                array ( "images\\coffee.jpg", "Coffee", "6.99"),
                array ( "images\\tea.png", "Tea", "3.49"),
                array ( "images\\almond_milk.jpg", "Almond Milk", "3.70")
            ),

            //Meat and Poultry (4)
            array ( 
                array ( "images\\ground_beef.png", "Ground Beef", "1.54"),
                array ( "images\\chicken.png", "Chicken", "12.54"),
                array ( "images\\steak.jpg", "Steak", "8.88"),
                array ( "images\\sausage.png", "Wieners", "5.99"),
                array ( "images\\turkey.jpg", "Turkey", "61.83"),
                array ( "images\\duck.jpg", "Duck", "19.28")
            ),

            //Snacks (5)
            array ( 
                array ( "images\\popcorn.png", "Popcorn", "6.59"),
                array ( "images\\chips.png", "Lays Chips", "1.89"),
                array ( "images\\chocolate.png", "Chocolate", "3.39"),
                array ( "images\\cookies.jpg", "Cookies", "3.99"),
                array ( "images\\nuts.jpg", "Nuts", "12.99"), 
                array ( "images\\jello.jpg", "Jell-o", "3.29")
            )
        );

        $_SESSION['product_array'] = $product_array; // i only need to use this as a session for other<form action = "P11.html">
    // 5 orders that are there when the website is first opened, paired with their quantities
    $order_array = array();
    
    $order_file = fopen('orders.txt', 'r') or die("Unable to open file:(");
    
    $count = 0;
    while(!feof($order_file))
    {
        
        $temp_string = fgets($order_file);
        $order_array[$count] = preg_split ("/\,/", $temp_string); // split each line of the file into an order array
        // spots 0 of this array: order number
        // spots 1,3,5...: product names
        // spots 2,4,6...: amount of each product being ordered
        // go through this array and replace all the product names with the product array
        for($order_index = 0; $order_index < count($order_array[$count]); $order_index++) // loop through all values in each order
        {
            if(($order_index%2)==1) // only enter loop for the names
            {
                for($category_index = 0; $category_index < count($product_array); $category_index++)
                {
                    for($product_index = 0; $product_index < count($product_array[$category_index]); $product_index++)
                    {
                        // echo (strcasecmp($product_array[$category_index][$product_index][1], $order_array[$count][$order_index])) . " --- ";
                        // echo $order_array[$count][$order_index] . " vs. " . $product_array[$category_index][$product_index][1] . "<br/>";
                        if(strcasecmp((string)$product_array[$category_index][$product_index][1], (string)$order_array[$count][$order_index]) == 0) // check if current product matches the product name from order list
                        {
                            $order_array[$count][$order_index] = $product_array[$category_index][$product_index];
                        }
                    }
                }
            }
        }

        $count++;
    }
    fclose($order_file);

    $_SESSION["orders"] = $order_array;

    $_SESSION["current_table"];

?>

<!DOCTYPE html>
<html lang = "en">

    <head>

        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
        <link rel="stylesheet" href="css/P11Style.css">

        <!-- bootstrap for nav bar toggle -->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

        <title>P11</title>

        
        <nav class="navbar navbar-expand-md" id="top_bar">
            <a class="navbar-brand"></a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                <span class="navbar-toggler-icon"> &#9660</span>
            </button>

            <div class="collapse navbar-collapse justify-content-end" id="collapsibleNavbar">
                <ul class="navbar-nav">
                    <li>
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
            <a href=p1.php>
                <h1>Concordia Supermarket</h1>
            </a>
            <p>Best place to find all your needs</p>
        </div>

    </head>

    <body>

        <nav class="navbar navbar-expand-md">

            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                <span class="navbar-toggler-icon"></span>
            </button>
            
            <div class="collapse navbar-collapse" id="collapsibleNavbar">
                <ul id = "deleteNavItem" class="navbar-nav">

                <?php foreach($_SESSION["orders"] as $value)
                    echo "<li class='nav-item'>
                            <a class='nav-link' href=#Order_" . $value[0] . ">" . $value[0] . "</a>  
                         </li>";
                ?>

                </ul>
            </div>
        </nav> 
        
    <!-- footer -->
    <div class="bottom_row" >
            <button class="collapsible" id="info_button">Info</button>
            <div class="content">
                <br>
                <h3>Welcome to Concordia Supermarket! </h3>
                <p>Click on any aisle to be brought to a page of products. Add these products to your cart and get an estimation on how much they'll cost!</p>
        
                <a href="contact_us.html">Contact Us</a>
            </div>
        </div>

        <script>
            var bt = document.getElementById("info_button");

            bt.addEventListener("click", function() 
            {
                this.classList.toggle("active");

                var content = this.nextElementSibling;
                if (content.style.maxHeight)
                {
                    content.style.maxHeight = null;
                } 
                else 
                {
                    content.style.maxHeight = content.scrollHeight + "px";
                } 
            });
        </script>

        <!--- add order button --->
        <form action="P12AddOrder.php">
            <button class='btn btn-secondary btn-lg btn-block'>Add Order</button>
        </form>

        <!--- tables --->
        <?php

           for($orderCount = 0; $orderCount < count($_SESSION['orders']); $orderCount++)
           {
                for($productCount = 0; $productCount < count($_SESSION['orders'][$orderCount]); $productCount++)
                {
                    if(isset($_POST["deleteItemButton" . $orderCount . $productCount]))
                    {
                        unset($_SESSION['orders'][$orderCount][$productCount]); // remove product and amount of the product
                        unset($_SESSION['orders'][$orderCount][$productCount+1]);
                    }
                } 
                
                $_SESSION['orders'][$orderCount] = array_values($_SESSION['orders'][$orderCount]); // reassign table indexes
            }
           
            $order_file = fopen('orders.txt', 'w') or die("Unable to open file:(");


            $string_order = array();
            // rewrite to the file
            for($orderNum = 0; $orderNum < count($_SESSION['orders']); $orderNum++)
            {
                for($spot = 0; $spot < count($_SESSION['orders'][$orderNum]); $spot++)
                {
                    if($spot == 0) // order number
                        $string_order[$orderNum] = $_SESSION['orders'][$orderNum][$spot];
                    elseif($spot%2 == 0) // number of the product
                        $string_order[$orderNum] = ($string_order[$orderNum] . "," .  $_SESSION['orders'][$orderNum][$spot]); 
                    elseif($spot%2 == 1) // product name
                        $string_order[$orderNum] = ($string_order[$orderNum] . "," .  $_SESSION['orders'][$orderNum][$spot][1]);
                }
            }

            foreach($string_order as $value)
            {
                fwrite($order_file, $value);
            }
            fclose($order_file);


           for($tableCount = 0; $tableCount < count($_SESSION['orders']); $tableCount++)
            {
                // remove a table when delete is clicked
                if(isset($_POST["deleteTableButton" . $tableCount]))
                {

                    $str_order = array();
                    unset($_SESSION['orders'][$tableCount]); // remove table

                    
                    $_SESSION['orders'] = array_values($_SESSION['orders']); // reassign table indexes

                    $order_file = fopen('orders.txt', 'w') or die("Unable to open file:(");

                    for($orderNum = 0; $orderNum < count($_SESSION['orders']); $orderNum++)
                    {
                        for($spot = 0; $spot < count($_SESSION['orders'][$orderNum]); $spot++)
                        {
                            if($spot == 0) // order number
                                $str_order[$orderNum] = $_SESSION['orders'][$orderNum][$spot];
                            elseif($spot%2 == 0) // number of the product
                                $str_order[$orderNum] = ($str_order[$orderNum] . "," .  $_SESSION['orders'][$orderNum][$spot]); 
                            elseif($spot%2 == 1) // product name
                                $str_order[$orderNum] = ($str_order[$orderNum] . "," .  $_SESSION['orders'][$orderNum][$spot][1]);
                        }
                    }
                    foreach($str_order as $value)
                    {
                        fwrite($order_file, $value);
                    }
                    fclose($order_file);

                    // redirect back to this page so the post is gone but the session stays
                    header("Location: P11.php"); 
                    exit();

                }
            }

            // take post from edit item and change session array of the orders. Allows know which item is being edited
            // then redirect to P12EditItem to let the user edit it
            for($i = 0; $i<count($_SESSION['orders']); $i++)
            {
                for($j = 0; $j < count($_SESSION['orders'][$i]); $j++)
                {
                    if(isset($_POST["editItem" . $i . $j]))
                    {
                        $_SESSION['tableItemToEdit'] = $i;
                        $_SESSION['rowItemToEdit'] = $j;
                        header("Location: P12EditItem.php");
                    }
                }
            }

            // add item to a table. Find index then redirect page
            for($i = 0; $i<count($_SESSION['orders']); $i++)
            {

                if(isset($_POST['addItem' . $i]))
                {
                    $_SESSION['tableToAddItem'] = $i;
                    header("Location: P12AddItem.php");
                }

            }


            $_SESSION["order_cost"] = array();
            $_SESSION["i"] = 0; // count the tables
            foreach($_SESSION["orders"] as $currentOrder)
            {
                $_SESSION["current_table"] = $_SESSION['i'];
                // !!!!!!!!!!!!! fact check that id
                echo "<table id = 'table" . $_SESSION['i'] . "'>
                        <a id=Order_" . $currentOrder[0] . "> <caption><br/>" . $currentOrder[0] . "</caption> </a>
                        <tr>
                            <th>Product</th>
                            <th>Image</th>
                            <th>Unit Price</th>
                            <th>Quantity</th>
                            <th>Subtotal</th>
                            <form method = 'POST'>
                                <th><input name = 'addItem" . $_SESSION['i'] . "' type='submit' value='Add' class='btn btn-secondary btn-lg btn-block'></th>
                            </form>
                        </tr>";

                $_SESSION["order_cost"][$_SESSION['i']] = 0;

                $counter = 1; // start at 1 because element 0 of the order arrays are the order names
                while(count($currentOrder) > $counter) // loop through all the products of the order that the loop is currently on
                                                       // positions 1,3,5,7... of each order array correspond to product arrays
                                                       // position 0 is the order number
                                                       // positions 2,4,6,8... are the amoun of each product being ordered
                {
                    // !!!!!!!!!!!!! make sure this is how to output two value in a row
                    echo "<tr id = " . $currentOrder[$counter][1] . $_SESSION['i'] . ">  
                            <td>" . $currentOrder[$counter][1] . "</td>
                            <td><img src=" . $currentOrder[$counter][0] . " alt='" . $currentOrder[$counter][1] . " image' width='100' height='100'></td>
                            <td>$" . number_format($currentOrder[$counter][2], 2) . "</td>
                            <td>" . $currentOrder[$counter + 1] . "</td>
                            <td>$" .  number_format($currentOrder[$counter][2]*$currentOrder[$counter + 1], 2) . "</td>
                            <td>
                                <form method = 'POST'>
                                    <input name = 'editItem" . $_SESSION['i'] . $counter . "' type='submit' value='Edit' class='btn btn-secondary btn-lg btn-block'>
                                </form>
                                <form method = 'POST'>
                                    <input type = 'submit' name = 'deleteItemButton" . $_SESSION['i'] . $counter . "' style='font-size:24px;' value='Delete' class='btn btn-secondary btn-lg btn-block'>
                                </form>
                            </td>
                        </tr>";
                        $_SESSION["order_cost"][$_SESSION['i']] = ($_SESSION["order_cost"][$_SESSION['i']] + ($currentOrder[$counter][2]*$currentOrder[$counter + 1]));
                        $counter = $counter + 2;
                }

                
                
                echo "<tr>
                        <td><b>Cart Summary:</b></td>
                        <td colspan = '4'>Subtotal: $" . number_format($_SESSION["order_cost"][$_SESSION['i']], 2) . "<br/>Tax: $" . number_format(($_SESSION["order_cost"][$_SESSION['i']]*0.15), 2) ."<br/>Total: $" . number_format(($_SESSION["order_cost"][$_SESSION['i']]*1.15), 2) ."</td>";

                echo "<td>
                        <form method = 'POST'>
                            <input name = 'deleteTableButton" . $_SESSION['i'] . "' type = 'submit'  style='font-size:24px;' value='Delete' class='btn btn-secondary btn-lg btn-block'>
                        </form>
                    </td>
                </tr>";
                
                // onclick = \"deleteTable('table" . $_SESSION['i'] . "', '" . $_SESSION['i'] . "')\"

                echo "</table>";


                $_SESSION['i']++;
            }

        ?>

        <br/> <br/> <br/> <br/>

    </body>
</html>
