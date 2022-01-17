<?php
session_start();
?>
<?php
// global $products;
// $products = array(
//     array(
//         array("Banana", "images/banana.png", "Quantity: 6 (per bunch)", "Size: 7-8 inches", "Type: Fruit", "Nutritional Source: Potassium, Fiber", 10, "$0.33/190g"),
//         array("Apple", "images/apple.png", "Quantity: 48 (per box)", "Size: 2 3⁄4 to 3 1⁄4 inches in diameter", "Type: Fruit", "Nutritional Source: Fiber, Vitamin C", 8, "$0.86/170g"),
//         array("Tomato", "images/tomato.png", "Sold Individually", "Size: 50 to 70mm in diameter", "Type: Fruit", "Nutritional Source: Vitamin A, Fiber", 7, "$1.76/200g"),
//         array("Lettuce", "images/lettuce.png", "Sold Individually", "Size: 8 inches in diameter", "Type: Vegetable", "Nutritional Source: Vitamin A, Vitamin C", 11, "$2.99/800g"),
//         array("Carrot", "images/carrot.png", "Quantity: 12 (per bunch)", "Size: 10 inches", "Type: Vegetable", "Nutritional Source: Fiber, Calcium", 15, "$1.99/38g"),
//         array("Onion", "images/onion.png", "Sold Individually", "Size: 4.5 inches", "Type: Vegetable", "Nutritional Source: Fiber", 4, "$4.39/300g")
//     ),
//     array(
//         array("Eggs", "images/eggs.jpg", "Quantity: 12 (per box)", "Size: 10 inches", "Type: Eggs", "Nutritional Source: Iron", 5, "$3.49/340g"),
//         array("Milk", "images/milk.png", "Quantity: 2 bags", "Size: 10 inches", "Type: Dairy", "Nutritional Source: Protein, Calcium", 19, "$6.86/4L"),
//         array("Cheese", "images/cheese.png", "Sold Individually", "Size: 27cm", "Type: Dairy", "Nutritional Source: Fat, Calcium", 17, "$5.49/270g"),
//         array("Butter", "images/butter.png", "Sold Individually", "Size: 10cm", "Type: Dairy", "Nutritional Source: Fat", 3, "$4.69/454g"),
//         array("Yogurt", "images/yogurt.png", "Sold Individually", "Size: 8cm", "Type: Dairy", "Nutritional Source: Protein, Carbs", 13, "$6.99/750g"),
//         array("Cream Cheese", "images/cream_cheese.jpg", "Sold Individually", "Size: 8cm", "Type: Dairy", "Nutritional Source: Fat, Carbs", 35, "$5.49/250g")
//     ),
//     array(
//         array("Ketchup", "images/ketchup.png", "Sold Individually", "Size: 12cm", "Type: Condiment", "Nutritional Source: Sugar, Sodium", 34, "$3.99/1L"),
//         array("Salt", "images/salt.png", "Sold Individually", "Size: 10cm", "Type: Seasoning", "Nutritional Source: Sodium", 3, "$6.49/1.36kg"),
//         array("Sugar", "images/sugar.jpg", "Sold Individually", "Size: 15cm", "Type: Condiment", "Nutritional Source: Protein, Carbs", 9, "$3.49/2kg"),
//         array("Olive Oil", "images/olive oil.png", "Sold Individually", "Size: 20cm", "Type: Condiment", "Nutritional Source: Fat", 10, "$12.99/1L"),
//         array("Spaghetti", "images/spaghetti.jpg", "Sold Individually", "Size: 15cm", "Type: Pasta", "Nutritional Source: Carbs", 15, "$2.39/500g"),
//         array("Mayonnaise", "images/mayonnaise.jpg", "Sold Individually", "Size: 13cm", "Type: Condiment", "Nutritional Source: Fat", 67, "$6.49/600g")
//     ),
//     array(
//         array("Water", "images/water.png", "Quantity: 15 (per box)", "Size: 15cm", "Type: Beverage", "Nutritional Source: Water", 13, "$4.49/330ml"),
//         array("Juice", "images/juice.png", "Sold Individually", "Size: 17cm", "Type: Beverage", "Nutritional Source: Water, Sugar", 8, "$2.79/190g"),
//         array("Soft Drink (Coca Cola)", "images/coca-cola.png", "Sold Individually", "Size: 12cm", "Type: Beverage", "Nutritional Source: Sugar", 27, "$1.89/1.25L"),
//         array("Coffee", "images/coffee.jpg", "Sold Individually", "Size: 11cm", "Type: Beverage", "Nutritional Source: Micronutrients", 12, "$6.99/100g"),
//         array("Tea", "images/tea.png", "Sold Individually", "Size: 10cm", "Type: Beverage", "Nutritional Source: Antioxidants", 18, "$3.49/24oz"),
//         array("Almond Milk", "images/almond_milk.jpg", "Quantity: 3 (per box)", "Size: 10cm", "Type: Beverage", "Nutritional Source: Fats, Protein", 3, "$3.70/300g")
//     ),
//     array(
//         array("Ground Beef", "images/ground_beef.png", "Sold Individually", "Size: 8cm", "Type: Meat", "Nutritional Source: Protein", 24, "$1.54/100g"),
//         array("Chicken", "images/chicken.png", "Sold Individually", "Size: 10cm", "Type: Poultry", "Nutritional Source: Protein", 48, "$12.54/1.6kg"),
//         array("Steak", "images/steak.jpg", "Sold Individually", "Size: 9cm", "Type: Meat", "Nutritional Source: Protein", 17, "$8.88/130g"),
//         array("Wieners", "images/sausage.png", "Sold Individually", "Size: 8cm", "Type: Meat", "Nutritional Source: Protein", 321, "$5.99/100g"),
//         array("Turkey", "images/turkey.jpg", "Sold Individually", "Size: 16cm", "Type: Poultry", "Nutritional Source: Protein", 13, "$61.83/8kg"),
//         array("Duck", "images/duck.jpg", "Sold Individually", "Size: 12cm", "Type: Poultry", "Nutritional Source: Protein", 13, "$19.28/500g")
//     ),
//     array(
//         array("Popcorn", "images/popcorn.png", "Quantity: 6 (per box)", "Size: 12cm", "Type: Snack", "Nutritional Source: Magnesium, Phosphorus", 3, "$5.59/340g"),
//         array("Lays Chips", "images/chips.png", "Sold Individually", "Size: 7cm", "Type: Snack", "Nutritional Source: Fat, Sodium", 8, "$1.89/50g"),
//         array("Chocolate", "images/chocolate.png", "Sold Individually", "Size: 12cm", "Type: Snack", "Nutritional Source: Sugar, Protein", 50, "$3.39/135g"),
//         array("Cookies", "images/cookies.jpg", "Sold Individually", "Size: 12cm", "Type: Snack", "Nutritional Source: Sugar, Carbohydrates", 23, "$3.99/255g"),
//         array("Nuts", "images/nuts.jpg", "Sold Individually", "Size: 13cm", "Type: Snack", "Nutritional Source: Magnesium, Fiber", 43, "$12.99/300g"),
//         array("Jell-o", "images/jello.jpg", "Quantity: 2 (per box)", "Size: 7cm", "Type: Snack", "Nutritional Source: Sugar", 17, "$3.29/265g")
//     )
// );



$categories = array("Vegetables and Fruits", "Dairy and Eggs", "Pantry", "Beverages", "Meat and Poultry", "Snacks");
$header = array("ID", "Product", "Image", "Description", "Quantity", "Price", "");

$_SESSION["products"] = $products;
$_SESSION["categories"] = $categories;
$_SESSION["header"] = $header;

$numCategories = count($categories);



?>