// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


//variables
int teaChoice; //holds the tea types
int teaSize; //holds size 
double subTotal = 0; //calculated subtotal
double tax = 0; //calculated tax
double finalCost = 0; //final cost
string custName; //name on order

// constants
const double PLAIN = 0.43; //COST of plain tea per ounce
const double BLACK = 0.53; //COST of black tea per ounce
const double GREEN = 0.65; //COST of green tea per ounce
const double WHITE = 0.78; //COST of white tea per ounce
const double TAXRATE = 0.045; //4.5% tax rate


//display menu + input choices
Console.WriteLine("Welcome to the World's Best Tea Shop");
Console.WriteLine("\t 1 - Plain Tea");
Console.WriteLine("\t 2 - Black Tea");
Console.WriteLine("\t 3 - Green Tea");
Console.WriteLine("\t 4 - White Tea");
Console.Write("Enter Choice of Tea: ");

//menu input
teaChoice = Convert.ToInt32(Console.ReadLine());

//use a switch to evaluate tea size
switch (teaChoice)
{
    case 1:
        //user chooses plain
        //input size
        Console.WriteLine(" ");
        Console.WriteLine("Select a Size: ");
        Console.WriteLine("\t 1 - Small (8oz)");
        Console.WriteLine("\t 2 - Medium (16oz)");
        Console.WriteLine("\t 3 - Large (24oz)"); 
        Console.Write("Enter Choice of Size: ");
        teaSize = Convert.ToInt32(Console.ReadLine());

        //check drink size 
        if(teaSize < 1)
        {
            //display error
            Console.WriteLine("ERROR: INVALID MENU CHOICE. PROGRAM WILL TERMINATE.");
            Environment.Exit(0);
        }
        else if(teaSize == 1)
        {
            //if small, calculate subtotal
            subTotal = 8 * PLAIN;
        }
        else if(teaSize == 2)
        {
            //if medium, calculate subtotal
            subTotal = 16 * PLAIN;
        }
        else if(teaSize == 3)
        {
            //if large, calculate subtotal
            subTotal = 24 * PLAIN;
        }
        else
        {
            Console.WriteLine("ERROR: INVALID MENU CHOICE. PROGRAM WILL TERMINATE.");
            Environment.Exit(0);
        }
        break;
    case 2:
        //user chooses black
        //input size
        Console.WriteLine(" ");
        Console.WriteLine("Select a Size: ");
        Console.WriteLine("\t 1 - Small (8oz)");
        Console.WriteLine("\t 2 - Medium (16oz)");
        Console.WriteLine("\t 3 - Large (24oz)");
        Console.Write("Enter Choice of Size: "); 
        teaSize = Convert.ToInt32(Console.ReadLine());

        //check drink size 
        if(teaSize < 1)
        {
            //display error
            Console.WriteLine("ERROR: INVALID MENU CHOICE. PROGRAM WILL TERMINATE.");
            Environment.Exit(0);
        }
        else if(teaSize == 1)
        {
            //if small, calculate subtotal
            subTotal = 8 * BLACK;
        }
        else if(teaSize == 2)
        {
            //if medium, calculate subtotal
            subTotal = 16 * BLACK;
        }
        else if(teaSize == 3)
        {
            //if large, calculate subtotal
            subTotal = 24 * BLACK;
        }
        else
        {
            Console.WriteLine("ERROR: INVALID MENU CHOICE. PROGRAM WILL TERMINATE.");
            Environment.Exit(0);
        }
        break;
    case 3:
        //user chooses green
        //input size
        Console.WriteLine(" ");
        Console.WriteLine("Select a Size: ");
        Console.WriteLine("\t 1 - Small (8oz)");
        Console.WriteLine("\t 2 - Medium (16oz)");
        Console.WriteLine("\t 3 - Large (24oz)");
        Console.Write("Enter Choice of Size: "); 
        teaSize = Convert.ToInt32(Console.ReadLine());

        //check drink size 
        if(teaSize < 1)
        {
            //display error
            Console.WriteLine("ERROR: INVALID MENU CHOICE. PROGRAM WILL TERMINATE.");
            Environment.Exit(0);
        }
        else if(teaSize == 1)
        {
            //if small, calculate subtotal
            subTotal = 8 * GREEN;
        }
        else if(teaSize == 2)
        {
            //if medium, calculate subtotal
            subTotal = 16 * GREEN;
        }
        else if(teaSize == 3)
        {
            //if large, calculate subtotal
            subTotal = 24 * GREEN;
        }
        else
        {
            Console.WriteLine("ERROR: INVALID MENU CHOICE. PROGRAM WILL TERMINATE.");
            Environment.Exit(0);
        }
        break; 
    case 4:
        //user chooses white
        //input size
        Console.WriteLine(" ");
        Console.WriteLine("Select a Size: ");
        Console.WriteLine("\t 1 - Small (8oz)");
        Console.WriteLine("\t 2 - Medium (16oz)");
        Console.WriteLine("\t 3 - Large (24oz)");
        Console.Write("Enter Choice of Size: "); 
        teaSize = Convert.ToInt32(Console.ReadLine());

        //check drink size 
        if(teaSize < 1)
        {
            //display error
            Console.WriteLine("ERROR: INVALID MENU CHOICE. PROGRAM WILL TERMINATE.");
            Environment.Exit(0);
        }
        else if(teaSize == 1)
        {
            //if small, calculate subtotal
            subTotal = 8 * WHITE;
        }
        else if(teaSize == 2)
        {
            //if medium, calculate subtotal
            subTotal = 16 * WHITE;
        }
        else if(teaSize == 3)
        {
            //if large, calculate subtotal
            subTotal = 24 * WHITE;
        }
        else
        {
            Console.WriteLine("ERROR: INVALID MENU CHOICE. PROGRAM WILL TERMINATE.");
            Environment.Exit(0);
        }
        break;
    default:
        //invalid input
        Console.WriteLine("ERROR: INVALID MENU CHOICE. PROGRAM WILL TERMINATE.");
        Environment.Exit(0);

        break;


}

//name on order
Console.WriteLine(" ");
Console.Write("Enter the name of the customer: ");
custName = Convert.ToString(Console.ReadLine());


//tax
tax = subTotal * TAXRATE;
//final cost
finalCost = subTotal + tax;

//display subtotal, tax, and final cost
Console.WriteLine(" ");
Console.WriteLine("Name on order: " + custName);
Console.WriteLine("Price of Tea: {0}", subTotal.ToString("c"));
Console.WriteLine("Sales Tax: {0}", tax.ToString("c"));
Console.WriteLine("Order Total: {0}", finalCost.ToString("c"));
