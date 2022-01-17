    <!--collapsible footer for info-->
    <div class="bottom_row" >
        <button class="collapsible" id="info_button">Info</button>
        <div class="content">
            <br>
            <h3>Welcome to Concordia Supermarket! </h3>
            <p>Click on any aisle to be brought to a page of products. Add these products to your cart and get an estimation on how much they'll cost!</p>
        
            <a href="contact_us.php">Contact Us</a>
        </div>
    </div>

    <script>
        var bt = document.getElementById("info_button");

        bt.addEventListener("click", function() {
            this.classList.toggle("active");

            var content = this.nextElementSibling;
            if (content.style.maxHeight){
            content.style.maxHeight = null;
            } 
            else {
            content.style.maxHeight = content.scrollHeight + "px";
            } 
        });
    </script>
</html>
