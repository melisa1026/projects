<?php 
    session_start();

    include ("header.php");
?>

<body>

    <link rel="stylesheet" type="text/css" href="css/P3.css">

    <div class="container">
        <table border="0" width="100%" id="product_pane">
            <col style="width:33%">
            <col style="width:67%">
            <tr>

                <td rowspan = 10 style="text-align: center; vertical-align: top;"><img id="image" src="" width="300" height="300"></td>
                <td class="p_name" rowspan = 2 id="name"></td>
            </tr>

            <tr></tr>

            <tr>
                <td class="p_price" id="price"></td>
            </tr>

            <tr>
                <td class="p_weight" id="weight"></td>
            </tr>

            <tr>
                <td rowspan =4 style="padding-left: 15px;">
                    <button type="button" class="button" id="cart_button">Add to Cart</a>
                </td>
            </tr>

            <tr></tr><tr></tr><tr></tr>

            <tr>
                <td rowspan = 2 style="padding-left: 15px;">
                    <button type="button" class="collapsible" id="product_description">Product Description</button>
                    <div class="product_info">
                        <p id="info"> <ul>
                            <li id = "p-id"></li>
                            <li id= "p-q"></li>
                            <li id= "p-s"></li>
                            <li id= "p-t"></li>
                            <li id= "p-ns"></li>
                        </ul></p>
                    </div>
                </td>

                <td rowspan = 2 style="padding-left: 15px;">
                    <button type="button" class="m_desc" id="more_description" onclick="to_detail()">More... </button>
                </td>
            </tr>

            <tr>
            </tr>

        </table>

        <script type="text/javascript">
            var url_string = window.location.href;
            var url = new URL(url_string);
            var a = url.searchParams.get("product_id");
            var b = url.searchParams.get("aisle_id");

            var p_darray = <?php echo json_encode($_SESSION["products"]); ?>;
            var p_array = [];

            for(var i = 0; i < p_darray.length; i++) {
                for(var m = 0; m < p_darray[i].length; m++) {
                    p_array.push(p_darray[i][m]);
                }
            }

            var product_name, price, weight = "";
            var p_ID, p_Q, p_S, p_T, p_NS = "";

            if(screen.width < 500) {
                var t = document.getElementById("product_pane");
                var p = t.parentNode;
                var wrapper = document.createElement('div');
                wrapper.style.overflowX="scroll";
                wrapper.appendChild(t);
                p.appendChild(wrapper);
            }

            //getting data based on id
            var image = document.getElementById("image");
            
            image.src = p_array[+a-1][0];

            product_name = p_array[+a-1][1];
            price = p_array[+a-1][2];
            weight = p_array[+a-1][3];

            p_ID = p_array[+a-1][4];
            p_Q = p_array[+a-1][5];
            p_S = p_array[+a-1][6];
            p_T = p_array[+a-1][7];
            p_NS = p_array[+a-1][8];

            if(screen.width < 500) {
                image.style.width = "200px";
                image.style.height = "200px";

                document.getElementById("cart_button").style.padding = "12px";
            }

            document.getElementById("name").innerHTML = product_name;
            document.getElementById("price").innerHTML = price;
            document.getElementById("weight").innerHTML = weight;

            document.getElementById("p-id").innerHTML = "Product ID: " + p_ID;
            document.getElementById("p-q").innerHTML = "Quantity: " + p_Q;
            document.getElementById("p-s").innerHTML = "Size: " + p_S;
            document.getElementById("p-t").innerHTML = "Type: " + p_T;
            document.getElementById("p-ns").innerHTML = "Nutritional Source: " + p_NS;


            //events for buttons
            document.getElementById("cart_button").onclick = function () {
                <?php 
                    $_SESSION["current_product"] = $_GET["product_id"];
                    $_SESSION["current_aisle"] = $_GET["aisle_id"];
                ?>

                location.href = "P4.php";
            };

            document.getElementById("product_description").addEventListener("click", function() {
                this.classList.toggle("active");
                var content = this.nextElementSibling;
                if (content.style.display === "block") {
                    content.style.display = "none";
                } 
                else {
                    content.style.display = "block";
                }
            });

            function to_detail() {
                var url_string = window.location.href;
                var url = new URL(url_string);
                var a = url.searchParams.get("product_id");
                var b = url.searchParams.get("aisle_id");

                location.href = "P3_d.php?aisle_id="+b+"&product_id="+a;
            }
     
        </script>
    </div>

</body>
</html>