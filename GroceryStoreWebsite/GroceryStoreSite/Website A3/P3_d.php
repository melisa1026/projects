<?php 
    session_start();

    include ("header.php");
?>

<body>
    <link rel="stylesheet" type="text/css" href="css/P3_d.css">

    <br>
        <h2 style="text-align:center;">Detailed Description</h2>
    </br>

    <div class="container">
        <table border ="0" width="100%" id="cart_pane">
            <col style="width:13%">
            <col style="width:26%">
            <col style="width:7%">
            <col style="width:13%">
            <col style="width:7%">
            <col style="width: 27%">
            <col style="width: 39%">

            <tr>
                <td><img id="image" src="" alt="" width="100" height="100"></td>
                <td id="name"></td>
                <td id="lb"></td>
                <td id="amount"></td>
                <td id="mb"></td>
                <td id="price"></td>
                <td id="rb"></td>
            </tr>
        </table>

        <br>
        
        <!--Tax part-->
        <table border ="0" width="100%">
            <col style="width:40%">
            <col style="width:21%">
            <col style="width:20%">
            <col style="width:20%">

            <tr style="border-bottom: 0px;">
                <td rowspan="4">
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
                
                <td></td>
                <td style="font-size:12px; font-weight:bold; text-align:left;">QST: </td>
                <td style="font-size:12px; text-align:right;" id="QST"></td>
            </tr>

            <tr style="border-bottom: 0px;">
                <td></td>
                <td style="font-size:12px; font-weight:bold; text-align:left;">GST: </td>
                <td style="font-size:12px; text-align:right;" id="GST"></td>
            </tr>

            <tr style="border-bottom: 0px;">
                <td></td>
                <td style="font-size:15px; font-weight:bold; text-align:left;">Total Tax: </td>
                <td style="font-size:15px; text-align:right;" id="tax"></td>
            </tr>

            <tr style="border-bottom: 0px;">
                <td></td>
                <td style="font-size:20px; font-weight:bold; text-align:left;">Total: </td>
                <td style="font-size:20px; text-align:right;" id="total"></td>
            </tr>

        </table>

        <br>

        <div>
            <button type="button" class="button" id="back_to_product">Back to Product</a>
        </div>

        <script type="text/javascript">
            var p_darray = <?php echo json_encode($_SESSION["products"]); ?>;
            var p_array = [];

            for(var i = 0; i < p_darray.length; i++) {
                for(var m = 0; m < p_darray[i].length; m++) {
                    p_array.push(p_darray[i][m]);
                }
            }

            var am = 1;

            var url_string = window.location.href;
            var url = new URL(url_string);
            var a = url.searchParams.get("product_id");

            var c;

            var im = document.getElementById('image');
            im.setAttribute("src", p_array[a-1][0]);

            document.getElementById("name").innerHTML = p_array[a-1][1];

            //less button
            var less_button = document.createElement('input');
            less_button.setAttribute('type', 'button');
            less_button.setAttribute('class', 'actionButton');
            less_button.setAttribute('value', '-');
            less_button.setAttribute('onclick', 'less()');
            document.getElementById("lb").appendChild(less_button);

            //amount
            document.getElementById("amount").innerHTML = am;

            //more button
            var more_button = document.createElement('input');
            more_button.setAttribute('type', 'button');
            more_button.setAttribute('class', 'actionButton');
            more_button.setAttribute('value', '+');

            more_button.setAttribute('onclick', 'more()');
            document.getElementById("mb").appendChild(more_button);

            //price
            var price_one = p_array[a-1][2].substring(1,p_array[a-1][2].length);
            var price_two = parseFloat(price_one);
            var price_three =  Math.round((am*price_two + Number.EPSILON) * 100) / 100;

            document.getElementById("price").innerHTML = "$" + price_three;

            //remove button
            var remove_button = document.createElement('input');
            remove_button.setAttribute('type', 'button');
            remove_button.setAttribute('class', 'actionButton');
            remove_button.setAttribute('value', 'X');

            remove_button.setAttribute('onclick', 'remove()');
            document.getElementById("rb").appendChild(remove_button);

            
            document.getElementById("QST").innerHTML = "$" + Math.round((price_three*0.1 + Number.EPSILON) * 100) / 100;
            document.getElementById("GST").innerHTML = "$" + Math.round((price_three*0.05 + Number.EPSILON) * 100) / 100;
            document.getElementById("tax").innerHTML = "$" + Math.round((price_three*0.15 + Number.EPSILON) * 100) / 100;
            document.getElementById("total").innerHTML = "$" + Math.round((price_three*1.15 + Number.EPSILON) * 100) / 100;

            //Description
            var p_ID, p_Q, p_S, p_T, p_NS = "";

            p_ID = p_array[a-1][4];
            p_Q = p_array[a-1][5];
            p_S = p_array[a-1][6];
            p_T = p_array[a-1][7];
            p_NS = p_array[a-1][8];

            document.getElementById("p-id").innerHTML = "Product ID: " + p_ID;
            document.getElementById("p-q").innerHTML = "Quantity: " + p_Q;
            document.getElementById("p-s").innerHTML = "Size: " + p_S;
            document.getElementById("p-t").innerHTML = "Type: " + p_T;
            document.getElementById("p-ns").innerHTML = "Nutritional Source: " + p_NS;

            //Event Listeners
            document.getElementById("back_to_product").onclick = function () {
                var url_string = window.location.href;
                var url = new URL(url_string);
                var a = url.searchParams.get("product_id");
                var b = url.searchParams.get("aisle_id");

                location.href = "P3.php?aisle_id="+b+"&product_id="+a;
            }

            function less() {
                var url_string = window.location.href;
                var url = new URL(url_string);
                var a = url.searchParams.get("product_id");

                if(am >0) {
                    am--;

                    var price_one = p_array[a-1][2].substring(1,p_array[a-1][2].length);
                    var price_two = parseFloat(price_one);
                    var price_three =  Math.round((am*price_two + Number.EPSILON) * 100) / 100;

                    var total_price = "$" + price_three;

                    document.getElementById("amount").innerHTML = am;
                    var table = document.getElementById("cart_pane");
                    table.rows[0].cells[5].textContent = total_price;

                    document.getElementById("QST").innerHTML = "$" + Math.round((price_three*0.1 + Number.EPSILON) * 100) / 100;
                    document.getElementById("GST").innerHTML = "$" + Math.round((price_three*0.05 + Number.EPSILON) * 100) / 100;
                    document.getElementById("tax").innerHTML = "$" + Math.round((price_three*0.15 + Number.EPSILON) * 100) / 100;
                    document.getElementById("total").innerHTML = "$" + Math.round((price_three*1.15 + Number.EPSILON) * 100) / 100;
                }
            }

            function more() {
                var url_string = window.location.href;
                var url = new URL(url_string);
                var a = url.searchParams.get("product_id");

                am++;

                var price_one = p_array[a-1][2].substring(1,p_array[a-1][2].length);
                var price_two = parseFloat(price_one);
                var price_three =  Math.round((am*price_two + Number.EPSILON) * 100) / 100;

                var total_price = "$" + price_three;

                document.getElementById("amount").innerHTML = am;
                var table = document.getElementById("cart_pane");
                table.rows[0].cells[5].textContent = total_price;

                document.getElementById("QST").innerHTML = "$" + Math.round((price_three*0.1 + Number.EPSILON) * 100) / 100;
                document.getElementById("GST").innerHTML = "$" + Math.round((price_three*0.05 + Number.EPSILON) * 100) / 100;
                document.getElementById("tax").innerHTML = "$" + Math.round((price_three*0.15 + Number.EPSILON) * 100) / 100;
                document.getElementById("total").innerHTML = "$" + Math.round((price_three*1.15 + Number.EPSILON) * 100) / 100;
            }

            function remove() {
                var url_string = window.location.href;
                var url = new URL(url_string);
                var a = url.searchParams.get("product_id");
                var b = url.searchParams.get("aisle_id");

                location.href = "P3.php?aisle_id="+b+"&product_id="+a;
            }
        </script>


</body>

</html>