//EXAM 1



//variables
int oilChoice; //the oil type selected
double quarts = 0.00; //the number of quarts of oil used
double price = 0.00; //original sale price/quart
double laborCost = 0.00; //35% of the oil cost
double subtotal = 0.00; //sum of the oil and labor cost
double oilCost = 0.00; //cost after multiplying quarts
double discountPrice = 0.00; //the discount that's applied if more than 5 quarts of oil is used
double totalCost = 0.00; //total cost of the purchase

//Create the Constants
const double REGULAR = 5.99; //cost of regular oil
const double REGSYN = 7.49; //cost of regular/synthetic blend oil
const double SYNTHETIC = 8.99; //cost of synthetic oil
const double LABOR = 0.35; //Labor is 35% of the oil cost
const double DISCOUNT = 0.10; //Discount price (10% off)

//MAIN MENU
//Ask the user for the type of oil
Console.WriteLine("\t1. Regular");
Console.WriteLine("\t2. Regular/Synthetic");
Console.WriteLine("\t3. Synthetic");
Console.Write("Please select and oil type from the menu above: ");
oilChoice = Convert.ToInt32(Console.ReadLine());

//Chose Type of oil
switch (oilChoice)
{
    case 1: //Set variables for REGULAR
        {
            price = REGULAR;
        }
        break;
    case 2: //Set variables for REGSYN
        {
            price = REGSYN;
        }
        break;
    case 3: //Set variables for SYNTHETIC
        {
            price = SYNTHETIC;
        }
        break;
    default: //error message for oil type
        Console.WriteLine(" ");
        Console.WriteLine("ERROR: INVALID OIL TYPE CHOSEN. PROGRAM WILL END.");
        Environment.Exit(0);
        break;
} // end of the oilChoice check

//Ask the user for the  number of quarts of oil
Console.WriteLine(" ");
Console.Write("Enter the number of quarts of oil it took to perform the oil change: ");
quarts = Convert.ToDouble(Console.ReadLine());

//Determine the discount
if (quarts > 0 && quarts < 6) //not adding the discount
{
    discountPrice = 0.00;
}
else if (quarts > 5) //adding the discount if the quart level is above 5
{
    discountPrice = DISCOUNT;
}
else //Display error message for quarts
{
    Console.WriteLine(" ");
    Console.WriteLine("ERROR: INVALID NUMBER OF QUARTS ENTERED. PROGRAM WILL END.");
    Environment.Exit(0);
}//end of select discount

//Set the print out values
oilCost = quarts * price; //calculations for the oil cost
laborCost = oilCost * LABOR; //calculations for the labor cost
subtotal = oilCost + laborCost; //calculations for the subtotal
totalCost = subtotal - discountPrice; //calculations for the total cost

//Write out the caluculations to the screen
Console.WriteLine(" ");
Console.WriteLine("Oil Change Service Calculator");
Console.WriteLine(" ");
Console.WriteLine("Oil Cost: " + oilCost.ToString("c"));
Console.WriteLine("Labor Cost: " + laborCost.ToString("c"));
Console.WriteLine("Subtotal: " + subtotal.ToString("c"));

//discount calculation
if (quarts < 6) //adding the discount
{
    Console.WriteLine("Discount: " + (discountPrice).ToString("c"));
    Console.WriteLine("Total Cost: " + (totalCost).ToString("c"));
}
else //omitting the discount
{
    Console.WriteLine("Discount: " + (discountPrice * subtotal).ToString("c"));
    Console.WriteLine("Total Cost: " + (subtotal - (discountPrice * subtotal)).ToString("c"));
}//end of discount calculation
