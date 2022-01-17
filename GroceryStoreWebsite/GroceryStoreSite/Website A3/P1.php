<?php 
    session_start();

    if(!isset($_SESSION["products"])) {
        $products = array (
            //Fruits and Vegetables
            array ( 
                array ( "images\\banana.png", "Banana", "$0.33", "190g", 0, "6 (per bunch)", "7-8 inches", "Fruit", "Potassium, Fiber"), 
                array ( "images\\apple.png", "Apple", "$0.86", "170g", 0,"48 (per box)", "2 3⁄4 to 3 1⁄4 inches in diameter", "Fruit","Fiber, Vitamin C"),
                array ( "images\\tomato.png", "Tomato", "$1.76", "200g", 0,"Sold Individually", "50 to 70mm in diameter", "Fruit", "Vitamin A, Fiber"), 
                array ( "images\\lettuce.png", "Lettuce", "$2.99", "800g", 0,"Sold Individually", "8 inches in diameter", "Vegetable", "Vitamin A, Vitamin C"),
                array ( "images\\carrot.png", "Carrot", "$1.99", "38g", 0,"12 (per bunch)", "10 inches", "Vegetable", "Fiber, Calcium"),
                array ( "images\\onion.png", "Onion", "$4.39", "300g", 0, "Sold Individually", "4.5 inches", "Vegetable", "Fiber")
            ),

            //Diary and Eggs
            array ( 
                array ( "images\\eggs.jpg", "Eggs", "$3.49", "340g", 0,"12 (per box)", "10 inches", "Eggs", "Iron"),
                array ( "images\\milk.png", "Milk", "$6.86", "4L", 0,"2 bags", "4L", "Diary", "Protein, Calcium"), 
                array ( "images\\cheese.png", "Cheese", "$5.49", "270g", 0,"Sold Individually", "27cm", "Diary", "Fat, Calcium"),  
                array ( "images\\butter.png", "Butter", "$4.69", "454g", 0,"Sold Individually", "10cm", "Diary", "Fat"),    
                array ( "images\\yogurt.png", "Yogurt", "$6.99", "750g", 0,"Sold Individually", "8cm", "Diary", "Protein, Carbs"),
                array ( "images\\cream_cheese.jpg", "Cream Cheese", "$5.49", "250g", 0,"Sold Individually", "8cm", "Diary", "Fat, Carbs")
            ), 

            //Pantry
            array ( 
                array ( "images\\ketchup.png", "Ketchup", "$3.99", "1L", 0,"Sold Individually", "12cm", "Condiment", "Sugar, Sodium"),
                array ( "images\\salt.png", "Salt", "$6.49", "1.36kg", 0,"Sold Individually", "10cm", "Seasoning", "Sodium"),
                array ( "images\\sugar.jpg", "Sugar", "$3.49", "2kg", 0,"Sold Individually", "15cm", "Condiment", "Protein, Carbs"),
                array ( "images\\olive oil.png", "Olive Oil", "$12.99", "1L", 0,"Sold Individually", "20cm", "Condiment", "Fat"),
                array ( "images\\spaghetti.jpg", "Spaghetti", "$2.39", "500g", 0,"Sold Individually", "15cm", "Pasta", "Carbs"),
                array ( "images\\mayonnaise.jpg", "Mayonnaise", "$6.49", "600g", 0,"Sold Individually", "13cm", "Condiment", "Fat")
            ),

            //Beverages
            array ( 
                array ( "images\\water.png", "Water", "$4.49", "330ml", 0,"15 (per box)", "15cm", "Beverage", "Water"),
                array ( "images\\juice.png", "Juice", "$2.79", "2L", 0,"Sold Individually", "17cm", "Beverage", "Water, Sugar"),
                array ( "images\\coca-cola.png", "Soft Drink (Coca Cola)", "$1.89", "1.25L", 0,"Sold Individually", "12cm", "Beverage", "Sugar"),
                array ( "images\\coffee.jpg", "Coffee", "$6.99", "100g", 0,"Sold Individually", "11cm", "Beverage", "micronutrients"),
                array ( "images\\tea.png", "Tea", "$3.49", "24oz", 0,"Sold Individually", "10cm", "Beverage", "antioxidants"),
                array ( "images\\almond_milk.jpg", "Almond Milk", "$3.70", "300g", 0,"3 (per box)", "10cm", "Beverage", "Fats, Protein")
            ),

            //Meat and Poultry
            array ( 
                array ( "images\\ground_beef.png", "Ground Beef", "$1.54", "100g", 0,"Sold Individually", "8cm", "Meat", "Protein"),
                array ( "images\\chicken.png", "Chicken", "$12.54", "1.6kg", 0,"Sold Individually", "10cm", "Poultry", "Protein"),
                array ( "images\\steak.jpg", "Steak", "$8.88", "130g", 0,"Sold Individually", "9cm", "Meat", "Protein"),
                array ( "images\\sausage.png", "Wieners", "$5.99", "100g", 0,"Sold Individually", "8cm", "Meat", "Protein"),
                array ( "images\\turkey.jpg", "Turkey", "$61.83", "8kg", 0,"Sold Individually", "16cm", "Poultry", "Protein"),
                array ( "images\\duck.jpg", "Duck", "$19.28", "500g", 0,"Sold Individually", "12cm", "Poultry", "Protein")
            ),

            //Snacks
            array ( 
                array ( "images\\popcorn.png", "Popcorn", "$6.59", "340g", 0,"6 (per box)", "12cm", "Snack", "Magnesium, Phosphorus"),
                array ( "images\\chips.png", "Lays Chips", "$1.89", "50g", 0,"Sold Individually", "7cm", "Snack", "Fat, Sodium"),
                array ( "images\\chocolate.png", "Chocolate", "$3.39", "135g", 0,"Sold Individually", "12cm", "Snack", "Sugar, Protein"),
                array ( "images\\cookies.jpg", "Cookies", "$3.99", "255g", 0,"Sold Individually", "12cm", "Snack", "Sugar, Carbohydrates"),
                array ( "images\\nuts.jpg", "Nuts", "$12.99", "300g", 0,"Sold Individually", "13cm", "Snack", "Magnesium, Fiber"), 
                array ( "images\\jello.jpg", "Jell-o", "$3.29", "265g", 0,"2 (per box)", "7cm", "Snack", "Sugar")
            )
        );

        $count = 0;
        for($x = 0; $x < sizeof($products); $x++) {
            for($y = 0; $y < sizeof($products[$x]); $y++) {
                $products[$x][$y][4] = ($count+1);
                $count++;
            }
        }

        $_SESSION["products"] = $products;
    }

    $aisle_type_array = array("Vegetables and Fruits", "Diary and Eggs", "Pantry", "Beverages", "Meat and Poultry", "Snacks");
    $_SESSION["aisle_type_array"] = $aisle_type_array;

    $category_images = array("images\\fruits_and_vegetables.png", "images\\eggs_and_diary.png", "images\\pantry.png", "images\\beverages.png", "images\\meat_and_poultry.png", "images\\snacks.png");
    $_SESSION["category_images"] = $category_images;
    
    include ("header.php");
?>

<script type="text/javascript">

</script>

<body>

    <link rel="stylesheet" type="text/css" href="css/P1.css">

    <br>
        <h2 style="text-align:center;">Categories</h2>
    </br>

    <!--aisle links-->
    <div class="container">
        <table border="0" width="100%" id="category_pane">
            <col style="width:33%">
        </table>

        <script type="text/javascript">
            var aisle_type_array = <?php echo json_encode($aisle_type_array); ?>;
            var category_images = <?php echo json_encode($category_images); ?>;

            var t = document.getElementById("category_pane");
            var rows = t.rows.length;
            var tr = t.insertRow(rows);
            var i;
            var count = 0;

            for(i = 0; i < aisle_type_array.length; i++){
                if((i%3==0) && i !=0 ) {
                    tr = t.insertRow(-1);
                    count = 0;
                }

                var td = document.createElement('td'); 
                td = tr.insertCell(count);

                var im = document.createElement('div');
                var link = "P2.php?aisle_id="+(i+1);

                if(screen.width < 500) im.innerHTML = "<a href=\""+link+"\"><img src=\""+category_images[i]+"\" alt=\""+aisle_type_array[i]+"\" width=\""+(0.22*screen.width)+"\" height=\""+(0.22*screen.width)+"\"></a>";
                else im.innerHTML = "<a href=\""+link+"\"><img src=\""+category_images[i]+"\" alt=\""+aisle_type_array[i]+"\" width=\"150\" height=\"150\"></a>";
                im.className = "category_image";

                var na = document.createElement('div');

                if(screen.width < 500 && aisle_type_array[i] == "Vegetables and Fruits")  na.innerHTML = "<p style=\"font-size: 12px\">"+aisle_type_array[i]+"</p>";
                else if(screen.width < 500 && aisle_type_array[i].length > 10) na.innerHTML = "<p style=\"font-size: 20px\">"+aisle_type_array[i]+"</p>";
                else if(screen.width < 500) na.innerHTML = "<p style=\"font-size: 22px\">"+aisle_type_array[i]+"</p>";
                else if(aisle_type_array[i].length > 20) na.innerHTML = "<p style=\"font-size: 28px\">"+aisle_type_array[i]+"</p>";
                else na.innerHTML = "<p style=\"font-size: 30px\">"+aisle_type_array[i]+"</p>";
                
                im.appendChild(na);

                td.appendChild(im);
                count++;
            }
        </script>
    </div>

    <br>
        <h2 style="text-align:center;">Weekly Deals</h2>
    </br>

    <!--Weekly Deal-->
    <div class="container">
        <table border="0.5" width="100%" id="weekly_deals">
            <col style="width:33%">
            <tr>
                <td id="wd_1"></td>
                <td id="wd_2"></td>
                <td id="wd_3"></td>
            </tr>

            <tr>
                <td id="wdb_1"></td>
                <td id="wdb_2"></td>
                <td id="wdb_3"></td>
            </tr>
        </table>

        <script type="text/javascript">
            var p_darray = <?php echo json_encode($_SESSION["products"]); ?>;
            var p_array = [];
        
            //converting 3d array to 1d array
            for(var i = 0; i < p_darray.length; i++) {
                for(var m = 0; m < p_darray[i].length; m++) {
                    p_darray[i][m].push(i);
                    p_array.push(p_darray[i][m]);
                }
            }

            //initializing weekly Deal product ID variables + 
            //randomly assigning them
            var wd1 = document.getElementById("wd_1");
            var wd2 = document.getElementById("wd_2");
            var wd3 = document.getElementById("wd_3");

            <?php 
                $p_wd1 = rand(0, sizeof($_SESSION["products"]));

                $p_wd2 = rand(0, sizeof($_SESSION["products"]));
                    if($p_wd2 == $p_wd1) 
                        while($p_wd2 == $p_wd1) $p_wd2 = rand(0, sizeof($_SESSION["products"]));

                $p_wd3 = rand(0, sizeof($_SESSION["products"]));
                    if($p_wd3 == $p_wd2 || $p_wd3 == $p_wd1)
                        while($p_wd3 == $p_wd2 || $p_wd3 == $p_wd1) $p_wd3 = rand(0, sizeof($_SESSION["products"]));

                if(!isset($_SESSION["w1"])) $_SESSION["w1"] = $p_wd1;
                if(!isset($_SESSION["w2"])) $_SESSION["w2"] = $p_wd2;
                if(!isset($_SESSION["w3"])) $_SESSION["w3"] = $p_wd3;
            ?>

            var p_wd1 = <?php echo json_encode($_SESSION["w1"]); ?>;
            var p_wd2 = <?php echo json_encode($_SESSION["w2"]); ?>;
            var p_wd3 = <?php echo json_encode($_SESSION["w3"]); ?>;

            //first weekly deal
            //creating image element + its link
            var im1 = document.createElement('div');
            var link = "P3.php?aisle_id="+p_array[p_wd1][9]+"&product_id="+p_array[p_wd1][4];

            //setting HTML with cases depending on screen width for mobile responsiveness
            if(screen.width<500) im1.innerHTML = "<a href=\""+link+"\"><img src=\""+p_array[p_wd1][0]+"\" alt=\""+p_array[p_wd1][0]+"\" width=\""+(0.22*screen.width)+"\" height=\""+(0.22*screen.width)+"\"></a>";
            else im1.innerHTML = "<a href=\""+link+"\"><img src=\""+p_array[p_wd1][0]+"\" alt=\""+p_array[p_wd1][0]+"\" width=\"150\" height=\"150\"></a>";
            im1.className = "product_image";

            //creating name element
            var name1 = document.createElement('div');

            //creating the deal string
            var old_price1 = ("$" + (parseFloat(p_array[p_wd1][2].substring(1,p_array[p_wd1][2].length)) + 2)).strike();
            var new_price1 = old_price1 + " " + p_array[p_wd1][2].bold();

            $.post("P1.php", {post_price1:new_price1}, function() {});
            <?php if(!isset($_SESSION["dealstring1"])) $_SESSION["dealstring1"] = $_POST["post_price1"];?>

            var title_string1 = p_array[p_wd1][1]+" / " +new_price1;

            //screen width cases for name + price
            if(screen.width < 500 && title_string1.length > 20) name1.innerHTML = "<p style=\"font-size: 22px\">"+title_string1 +"</p>";
            else if(screen.width < 500) name1.innerHTML = "<p style=\"font-size: 24px\">"+title_string1 +"</p>";
            else if(title_string1.length > 20) name1.innerHTML = "<p style=\"font-size: 28px\">"+title_string1 +"</p>";
            else name1.innerHTML = "<p style=\"font-size: 30px\">"+title_string1 +"</p>";

            //Creating button to go to weekly deal item aisle
            var a_button1 = document.createElement("button");
            a_button1.innerHTML = "Go to aisle";
            a_button1.setAttribute("onclick", "to_aisle("+p_array[p_wd1][9]+")");
            a_button1.setAttribute("class", "weekly_button");
            
            
            if(screen.width < 500) a_button1.style.padding = "12px";
            im1.appendChild(name1);
            wd1.appendChild(im1);

            document.getElementById("wdb_1").appendChild(a_button1);



            //second weekly deal
            var im2 = document.createElement('div');
            var link = "P3.php?aisle_id="+p_array[p_wd2][9]+"&product_id="+p_array[p_wd2][4];

            if(screen.width<500) im2.innerHTML = "<a href=\""+link+"\"><img src=\""+p_array[p_wd2][0]+"\" alt=\""+p_array[p_wd2][0]+"\" width=\""+(0.22*screen.width)+"\" height=\""+(0.22*screen.width)+"\"></a>";
            else im2.innerHTML = "<a href=\""+link+"\"><img src=\""+p_array[p_wd2][0]+"\" alt=\""+p_array[p_wd2][0]+"\" width=\"150\" height=\"150\"></a>";
            im2.className = "product_image";

            var name2 = document.createElement('div');

            var old_price2 = ("$" + (parseFloat(p_array[p_wd2][2].substring(1,p_array[p_wd2][2].length)) + 1)).strike();
            var new_price2 = old_price2 + " " + p_array[p_wd2][2].bold();

            $.post("P1.php", {post_price2:new_price2}, function() {});
            <?php if(!isset($_SESSION["dealstring2"])) $_SESSION["dealstring2"] = $_POST["post_price2"];?>
    
            var title_string2 = p_array[p_wd2][1]+" / " +new_price2;

            if(screen.width<500 && title_string2.length > 20) name2.innerHTML = "<p style=\"font-size: 22px\">"+title_string2 +"</p>";
            else if(screen.width<500) name2.innerHTML = "<p style=\"font-size: 24px\">"+title_string2 +"</p>";
            else if(title_string2.length > 20) name2.innerHTML = "<p style=\"font-size: 28px\">"+title_string2 +"</p>";
            else name2.innerHTML = "<p style=\"font-size: 30px\">"+title_string2 +"</p>";
            
            var a_button2 = document.createElement("button");
            a_button2.innerHTML = "Go to aisle";
            a_button2.setAttribute("onclick", "to_aisle("+p_array[p_wd2][9]+")");
            a_button2.setAttribute("class", "weekly_button");
            if(screen.width < 500) a_button2.style.padding = "12px";

            im2.appendChild(name2);
            wd2.appendChild(im2);
            document.getElementById("wdb_2").appendChild(a_button2);



            //third weekly deal
            var im3 = document.createElement('div');
            var link = "P3.php?aisle_id="+p_array[p_wd3][9]+"&product_id="+p_array[p_wd3][4];
            if(screen.width<500) im3.innerHTML = "<a href=\""+link+"\"><img src=\""+p_array[p_wd3][0]+"\" alt=\""+p_array[p_wd3][0]+"\" width=\""+(0.22*screen.width)+"\" height=\""+(0.22*screen.width)+"\"></a>";
            else im3.innerHTML = "<a href=\""+link+"\"><img src=\""+p_array[p_wd3][0]+"\" alt=\""+p_array[p_wd3][0]+"\" width=\"150\" height=\"150\"></a>";
            im3.className = "product_image";

            var name3 = document.createElement('div');

            var old_price3 = ("$" + (parseFloat(p_array[p_wd3][2].substring(1,p_array[p_wd3][2].length)) + 3)).strike();
            var new_price3 = old_price3 + " " + p_array[p_wd3][2].bold();

            $.post("P1.php", {post_price3:new_price3}, function() {});
            <?php if(!isset($_SESSION["dealstring3"])) $_SESSION["dealstring3"] = $_POST["post_price3"];?>

            var title_string3 = p_array[p_wd3][1]+" / " +new_price3;

            if (screen.width < 500 && title_string3.length > 20)  name3.innerHTML = "<p style=\"font-size: 22px\">"+title_string3 +"</p>";
            else if(screen.width < 500) name3.innerHTML = "<p style=\"font-size: 24px\">"+title_string3 +"</p>";
            else if(title_string3.length > 20) name3.innerHTML = "<p style=\"font-size: 28px\">"+title_string3 +"</p>";
            else name3.innerHTML = "<p style=\"font-size: 30px\">"+title_string3 +"</p>";

            var a_button3 = document.createElement("button");
            a_button3.innerHTML = "Go to aisle";
            a_button3.setAttribute("onclick", "to_aisle("+p_array[p_wd3][9]+")");
            a_button3.setAttribute("class", "weekly_button");
            if(screen.width < 500) a_button3.style.padding = "12px";

            im3.appendChild(name3);
            wd3.appendChild(im3);
            document.getElementById("wdb_3").appendChild(a_button3);


            function to_aisle(aisle) {
                location.href = "P2.php?aisle_id="+(aisle+1);
            }

        </script>
    </div>

</body>

<?php 
    include ("footer.php");
?>