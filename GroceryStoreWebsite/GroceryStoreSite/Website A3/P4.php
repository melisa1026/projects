<?php 
    session_start();

    if(!isset($_SESSION["cart"]))  {
        $cart = array();
        $amounts = array();

        $_SESSION["cart"] = $cart;
        $_SESSION["amounts"] = $amounts;

    }

    include ("header.php");
?>

<body>
    <link rel="stylesheet" type="text/css" href="css/P4.css">

    <br>
        <h2 style="text-align:center;">Grocery Cart</h2>
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
        </table>

        <br>
        
        <table border ="0" width="100%">
            <col style="width:40%">
            <col style="width:21%">
            <col style="width:20%">
            <col style="width:20%">

            <tr style="border-bottom: 0px;">
                <td></td><td></td>
                <td style="font-size:12px; font-weight:bold; text-align:left;">QST: </td>
                <td style="font-size:12px; text-align:right;" id="QST"></td>
            </tr>

            <tr style="border-bottom: 0px;">
                <td></td><td></td>
                <td style="font-size:12px; font-weight:bold; text-align:left;">GST: </td>
                <td style="font-size:12px; text-align:right;" id="GST"></td>
            </tr>

            <tr style="border-bottom: 0px;">
                <td></td><td></td>
                <td style="font-size:15px; font-weight:bold; text-align:left;">Total Tax: </td>
                <td style="font-size:15px; text-align:right;" id="tax"></td>
            </tr>

            <tr style="border-bottom: 0px;">
                <td><button type="button" class="button" id="send_order">Send Order</a></td>
                <td></td>
                <td style="font-size:20px; font-weight:bold; text-align:left;">Total: </td>
                <td style="font-size:20px; text-align:right;" id="total"></td>
            </tr>

        </table>

        <script type="text/javascript">
            <?php 
                if(!in_array(($_SESSION["current_product"]-1), $_SESSION["cart"]) && ($_SESSION["current_product"]-1) >=0) {
                    array_push($_SESSION["cart"], $_SESSION["current_product"]-1);
                    array_push($_SESSION["amounts"], array($_SESSION["current_product"], 1));
                }
            ?>

            var g_array = <?php echo json_encode($_SESSION["cart"]); ?>;

            var a_array = <?php echo json_encode($_SESSION["amounts"]); ?>;

            //alert(g_array);
            //alert(a_array);

            var p_darray = <?php echo json_encode($_SESSION["products"]); ?>;
            var p_array = [];

            for(var i = 0; i < p_darray.length; i++) {
                for(var m = 0; m < p_darray[i].length; m++) {
                    p_array.push(p_darray[i][m]);
                }
            }

            var t = document.getElementById("cart_pane");
            var rows = t.rows.length;
            var tr = t.insertRow(rows);
            tr = t.insertRow(rows);

            var i;
            var c;
            
            var x;
            var total_price = 0.0;
            for(x = 0; x < g_array.length; x++) {
                var price_one = p_array[+g_array[x]][2].substring(1,p_array[+g_array[x]][2].length);
                var price_two = parseFloat(price_one);
                var price_three = a_array[x][1]*Math.round((price_two + Number.EPSILON) * 100) / 100;

                total_price += price_three;
            }
            

            for(i = 0; i < g_array.length; i++) {
                for(c = 0; c < 7; c++) {        
                    var td = document.createElement('td'); 
                    td = tr.insertCell(c);
                    switch(c) {
                        //image
                        case 0:
                            var im = document.createElement("IMG");
                            im.setAttribute("src", p_array[+g_array[i]][0]);
                            im.setAttribute("width", "100");
                            im.setAttribute("height", "100");
                            im.setAttribute("alt", p_array[+g_array[i]][1]);
                            td.appendChild(im);
                            break;

                        //name
                        case 1:
                            var nam = document.createTextNode(p_array[+g_array[i]][1]);
                            td.appendChild(nam);
                            break;

                        //less button
                        case 2:
                            var less_button = document.createElement('input');
                            less_button.setAttribute('type', 'button');
                            less_button.setAttribute('class', 'actionButton');
                            less_button.setAttribute('value', '-');

                            var current = g_array[i];
                            less_button.setAttribute('onclick', 'less(this)');
                            td.appendChild(less_button);
                            break;

                        //amount
                        case 3:
                            var amount = document.createTextNode(a_array[i][1]);

                            td.appendChild(amount);
                            break;

                        //more button
                        case 4:
                            var more_button = document.createElement('input');
                            more_button.setAttribute('type', 'button');
                            more_button.setAttribute('class', 'actionButton');
                            more_button.setAttribute('value', '+');

                            more_button.setAttribute('onclick', 'more(this)');
                            td.appendChild(more_button);
                            break;

                        //price per item
                        case 5:
                            var price_one = p_array[+g_array[i]][2].substring(1,p_array[+g_array[i]][2].length);
                            var price_two = parseFloat(price_one);
                            var price_three =  Math.round((a_array[i][1]*price_two + Number.EPSILON) * 100) / 100;
                            //total_price += price_two;

                            var price = document.createTextNode("$" + price_three);
                            td.appendChild(price);
                            break;

                        //remove button
                        case 6:
                            var remove_button = document.createElement('input');
                            remove_button.setAttribute('type', 'button');
                            remove_button.setAttribute('class', 'actionButton');
                            remove_button.setAttribute('value', 'X');

                            remove_button.setAttribute('onclick', 'remove(this)');
                            td.appendChild(remove_button);
                            break;
                    }
                }
                tr = t.insertRow(rows);
            }
            document.getElementById("QST").innerHTML = "$" + Math.round((total_price*0.1 + Number.EPSILON) * 100) / 100;
            document.getElementById("GST").innerHTML = "$" + Math.round((total_price*0.05 + Number.EPSILON) * 100) / 100;
            document.getElementById("tax").innerHTML = "$" + Math.round((total_price*0.15 + Number.EPSILON) * 100) / 100;
            document.getElementById("total").innerHTML = "$" + Math.round((total_price*1.15 + Number.EPSILON) * 100) / 100;
            
            document.getElementById("send_order").onclick = function () {
                var order_num = <?php echo json_encode($_SESSION["email"]);?>;

		        if(order_num == null) order_num = "default";

                var add_string = "" + order_num;
                
                var om;

                for(om = 0; om < a_array.length; om++) {
                    var p_name = p_array[(+a_array[om][0]-1)][1];
                    var p_number = a_array[om][1];
                    add_string += ","+p_name+","+p_number;
                }

                add_string+='\n';

                $.post("P4.php", {ord:add_string}, function() {});

                <?php 
                    if(isset($_POST['ord'])) {
                        $orders = fopen("orders.txt", "a") or die("Unable to open file.");
                        $txt = $_POST['ord'];
                        fwrite($orders, $txt);
                        fclose($orders);
                    }
                ?>

                alert("Order successfully sent!");
            }

            function more(oButton) {
                var x;
                var index = g_array.length - +oButton.parentNode.parentNode.rowIndex;
                var table = document.getElementById("cart_pane");

                for(x = 0; x < a_array.length; x++) {
                    var c_ind = +g_array[index] + 1;

                    //alert("work: " + c_ind);
                    if(a_array[x][0] == c_ind) {
                        //alert("found : " + a_array[x][0]);
                        a_array[x][1]++;

                        //alert("altered: " + a_array[x]);
                        
                        //save
                        $.post("P4.php", {inc:a_array}, function() {});

                        <?php 
                            if(isset($_POST['inc'])) {
                                $_SESSION["amounts"] = $_POST['inc'];
                            }
                        ?>
                        
                        table.rows[+oButton.parentNode.parentNode.rowIndex].cells[3].textContent = a_array[x][1];


                        var price_one = p_array[g_array[index]][2].substring(1,p_array[g_array[index]][2].length);
                        var price_two = parseFloat(price_one);
                        total_price += price_two;

                        table.rows[+oButton.parentNode.parentNode.rowIndex].cells[5].textContent = "$" + Math.round((a_array[x][1] * price_two) * 100) / 100;
                    }
                }

                document.getElementById("QST").innerHTML = "$" + Math.round((total_price*0.1 + Number.EPSILON) * 100) / 100;
                document.getElementById("GST").innerHTML = "$" + Math.round((total_price*0.05 + Number.EPSILON) * 100) / 100;
                document.getElementById("tax").innerHTML = "$" + Math.round((total_price*0.15 + Number.EPSILON) * 100) / 100;
                document.getElementById("total").innerHTML = "$" + Math.round((total_price*1.15 + Number.EPSILON) * 100) / 100;
            }

            function less(oButton) {
                var x;
                var index = g_array.length - +oButton.parentNode.parentNode.rowIndex;
                var table = document.getElementById("cart_pane");

                for(x = 0; x < a_array.length; x++) {
                    var c_ind = +g_array[index] + 1;
                    if(a_array[x][0] == c_ind) {
                        if((+a_array[x][1]-1) >0) {
                            a_array[x][1]--;

                            //alter array and save
                            $.post("P4.php", {dec:a_array}, function() {});

                            <?php 
                                if(isset($_POST['dec'])) {
                                    $_SESSION["amounts"] = $_POST['dec'];
                                }
                            ?>

                            table.rows[+oButton.parentNode.parentNode.rowIndex].cells[3].textContent = a_array[x][1];

                            var price_one = p_array[g_array[index]][2].substring(1,p_array[g_array[index]][2].length);
                            var price_two = parseFloat(price_one);
                            total_price -= price_two;

                            table.rows[+oButton.parentNode.parentNode.rowIndex].cells[5].textContent = "$" + Math.round((a_array[x][1] * price_two) * 100) / 100;
                        }
                    }
                }

                document.getElementById("QST").innerHTML = "$" + Math.round((total_price*0.1 + Number.EPSILON) * 100) / 100;
                document.getElementById("GST").innerHTML = "$" + Math.round((total_price*0.05 + Number.EPSILON) * 100) / 100;
                document.getElementById("tax").innerHTML = "$" + Math.round((total_price*0.15 + Number.EPSILON) * 100) / 100;
                document.getElementById("total").innerHTML = "$" + Math.round((total_price*1.15 + Number.EPSILON) * 100) / 100;
            }

            function remove(oButton) {
                var t = document.getElementById('cart_pane');
                var index = g_array.length - +oButton.parentNode.parentNode.rowIndex;
                var q;

                if(g_array.length-1 !=0) {
                    for( q = 0; q < a_array.length; q++) {
                        var c_ind = (+g_array[index] + 1);

                        if(a_array[q][0] == c_ind) {
                            var price_one = p_array[+g_array[index]][2].substring(1,p_array[+g_array[index]][2].length);
                            var price_two = parseFloat(price_one);
                            var price_three = Math.round((a_array[q][1]*price_two + Number.EPSILON) * 100) / 100;

                            total_price -= price_three;


                            a_array.splice(q, 1);

                            g_array.splice(index, 1);

                            $.post("P4.php", {rem_a:a_array, rem_g:g_array}, function() {});

                        }
                    }

                    <?php 
                        if(isset($_POST['rem_a'])) {
                            $a = array();
                            $a = $_POST['rem_a'];
                            $_SESSION["amounts"] = $a;

                            unset($_POST['rem_a']);
                        }

                        if(isset($_POST['rem_g'])) {
                            $c = array();
                            $c = $_POST['rem_g'];
                            $_SESSION["cart"] = $c;

                            unset($_POST['rem_g']);
                        }
                    ?>
                    
                    t.deleteRow(oButton.parentNode.parentNode.rowIndex); 
                }

                else alert("Grocery cart must have at least one item in it!");

                document.getElementById("QST").innerHTML = "$" + Math.round((total_price*0.1 + Number.EPSILON) * 100) / 100;
                document.getElementById("GST").innerHTML = "$" + Math.round((total_price*0.05 + Number.EPSILON) * 100) / 100;
                document.getElementById("tax").innerHTML = "$" + Math.round((total_price*0.15 + Number.EPSILON) * 100) / 100;
                document.getElementById("total").innerHTML = "$" + Math.round((total_price*1.15 + Number.EPSILON) * 100) / 100;
            }

        </script>
    </div>
</body>
</html>