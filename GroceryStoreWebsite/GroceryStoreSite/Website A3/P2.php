<?php 
    session_start();

    include ("header.php");
?>

<body>

    <link rel="stylesheet" type="text/css" href="css/P2.css">


    <br>
        <h2 style="text-align:center;" id="aisle_title"></h2>
    </br>

    <!--table that auto generates and has links plus the product id appendage-->
    <div class="container">
        <table border="0" width="100%" id="product_pane">
            <col style="width:33%">
        </table>
        <br>
        <button type="button" class="button" id="back_to_home">Back to Homepage</a>

        <script type="text/javascript">
            var p_array = <?php echo json_encode($_SESSION["products"]); ?>;
            var at_array = <?php echo json_encode($_SESSION["aisle_type_array"]); ?>;
            
            var url_string = window.location.href;
            var url = new URL(url_string);
            var a = url.searchParams.get("aisle_id");

            var title = document.getElementById("aisle_title");

            var tt = at_array[a-1];
            title.innerHTML = tt;

            var current_aisle = [];

            current_aisle= p_array[a-1];

            var t = document.getElementById("product_pane");
            var rows = t.rows.length;
            var tr = t.insertRow(rows);
            var i;
            var count = 0;

            for(i = 0; i < current_aisle.length; i++){
                if((i%3==0) && i !=0 ) {
                    tr = t.insertRow(-1);
                    count = 0;
                }

                var td = document.createElement('td'); 
                td = tr.insertCell(count);

                var im = document.createElement('div');
                var link = "P3.php?aisle_id="+a+"&product_id="+current_aisle[i][4];

                

                if(screen.width <500) im.innerHTML = "<a href=\""+link+"\"><img src=\""+current_aisle[i][0]+"\" alt=\""+current_aisle[i][1]+"\" width=\""+(0.22*screen.width)+"\" height=\""+(0.22*screen.width)+"\"></a>";
                else im.innerHTML = "<a href=\""+link+"\"><img src=\""+current_aisle[i][0]+"\" alt=\""+current_aisle[i][1]+"\" width=\"150\" height=\"150\"></a>";
                im.className = "product_image";

                var na = document.createElement('div');

                var temp_name = "";

                var weekly1 = <?php echo json_encode($_SESSION["w1"]); ?> + 1;
                var weekly2 = <?php echo json_encode($_SESSION["w2"]); ?> + 1;
                var weekly3 = <?php echo json_encode($_SESSION["w3"]); ?> + 1;

                var dealstring1 = <?php echo json_encode($_SESSION["dealstring1"]); ?>;
                var dealstring2 = <?php echo json_encode($_SESSION["dealstring2"]); ?>;
                var dealstring3 = <?php echo json_encode($_SESSION["dealstring3"]); ?>;

                if(current_aisle[i][4] == weekly1) temp_name = current_aisle[i][1]+" / " +dealstring1;
                else if (current_aisle[i][4] == weekly2) temp_name = current_aisle[i][1]+" / " +dealstring2;
                else if (current_aisle[i][4] == weekly3) temp_name = current_aisle[i][1]+" / " +dealstring3;
                else temp_name = current_aisle[i][1]+" / " +current_aisle[i][2];

                if(screen.width < 500 && temp_name.length > 10) na.innerHTML = "<p style=\"font-size: 20px\">"+temp_name+"</p>";
                else if(screen.width < 500) na.innerHTML = "<p style=\"font-size: 24px\">"+temp_name+"</p>";
                else if(temp_name > 20) na.innerHTML = "<p style=\"font-size: 28px\">"+temp_name+"</p>";
                else na.innerHTML = "<p style=\"font-size: 30px\">"+temp_name+"</p>";

                
                //to cart button
                var cart = document.createElement('button');
                cart.setAttribute("class", "cart_button");
                cart.textContent = 'Add to Cart';
                cart.setAttribute("onclick", "to_cart(this, " + current_aisle[i][4] + ")");
                
                //collapsible info button
                var info_button = document.createElement('button');
                info_button.setAttribute('class', 'collapsible');
                info_button.innerHTML = "product info";
                info_button.setAttribute("onclick","show_info(this)");

                //collapsible info
                var info = document.createElement('div');
                info.setAttribute('class', 'product_info');

                var p_ID, p_Q, p_S, p_T, p_NS = "";
                p_ID = current_aisle[i][4];
                p_Q = current_aisle[i][5];
                p_S = current_aisle[i][6];
                p_T = current_aisle[i][7];
                p_NS = current_aisle[i][8];

                info.innerHTML = "<p style=\"font-size: 13px\"><ul> <li>Product ID: " + p_ID +"</li>"+
                    "<li>Quantity: " + p_Q +"</li>"+
                    "<li>Size: " + p_S +"</li>"+
                    "<li>Type: " + p_T +"</li>"+
                    "<li>Nutritional Source: " + p_NS+"</li></ul></p>";


                im.appendChild(na);

                td.appendChild(im);
                td.appendChild(cart);
                td.appendChild(info_button);
                td.appendChild(info);
                count++;
            }

            document.getElementById("back_to_home").onclick = function () {
                location.href = "P1.php";
            }

            function to_cart(oButton, prod_id) {
                var id = prod_id;

                $.post("P2.php", {post_id:id}, function() {});

                <?php 
                    $_SESSION["current_product"] = $_POST["post_id"];
                    $_SESSION["current_aisle"] = $_GET["aisle_id"];
                ?>

                location.href = "P4.php";
            }

            function show_info(oButton) {
                oButton.classList.toggle("active");
                var content = oButton.nextElementSibling;

                if (content.style.display === "block") {
                    content.style.display = "none";
                } 
                else {
                    content.style.display = "block";
                }
            }
            
        </script>
    </div>


</body>

</html>