// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

//variables
int menuChoice; //holds the vinyl types
int numRecords; //holds number of records purchased
double subTotal = 0; //calculated subtotal
double tax = 0; //calculated tax
double finalCost = 0; //final cost

// constants
const double SEVENINCH_1 = 19.99; //COST PER RECORD FOR 1 OR 2 7-IN. RECORDS
const double SEVENINCH_2 = 17.99; //COST PER RECORD FOR 3 OR more 7-IN. RECORDS
const double TWELVEINCH_1 = 22.99; //COST PER RECORD FOR 1 OR 2 12-IN. RECORDS
const double TWELVEINCH_2 = 20.99; //COST PER RECORD FOR 3 OR more 12-IN. RECORDS
const double TAXRATE = 0.0725; //7.25% tax rate


//display menu + input choices
Console.WriteLine("** Welcom to the Record Shop **");
Console.WriteLine("Choose from one of the following types of vinyl records: ");
Console.WriteLine("\t 1. 7-inch");
Console.WriteLine("\t 2. 12-inch");
Console.Write("Which type of records will be purchased? ");

//menu input
menuChoice = Convert.ToInt32(Console.ReadLine());

//use a switch to evaluate menu choice
switch (menuChoice)
{
    case 1:
        //user chooses 1
        //input number of 7s
        Console.Write("\nHow many 7-inch records will be purchased? ");
        numRecords = Convert.ToInt32(Console.ReadLine());

        //check number of records
        if(numRecords < 1)
        {
            //display error
            Console.WriteLine("\nERROR: INVALID NUMBER OF RECORDS ENTERED. PROGRAM WILL NOW END");
            Environment.Exit(0);
        }
        else if(numRecords <= 2)
        {
            //if 1 or 2 7-in vinyls, calculate subtotal
            subTotal = numRecords * SEVENINCH_1;
        }
        else
        {
            //if 3 or more 7-in vinyls, calculate subtotal
            subTotal = numRecords * SEVENINCH_2;
        }
        break;
    case 2:
        //user chooses 2
        //input number of 12s
        Console.Write("\nHow many 12-inch records will be purchased? ");
        numRecords = Convert.ToInt32(Console.ReadLine());

        //check number of records
        if (numRecords < 1)
        {
            //display error
            Console.WriteLine("\nERROR: INVALID NUMBER OF RECORDS ENTERED. PROGRAM WILL NOW END");
            Environment.Exit(0);
        }
        else if (numRecords <= 2)
        {
            //if 1 or 2 7-in vinyls, calculate subtotal
            subTotal = numRecords * TWELVEINCH_1;
        }
        else
        {
            //if 3 or more 7-in vinyls, calculate subtotal
            subTotal = numRecords * TWELVEINCH_2;
        }
        break;
    default:
        //invalid input
        Console.WriteLine("\nERROR: INVALID MENU OPTION SELECTED. PROGRAM WILL NOW END");
        Environment.Exit(0);

        break;


}

//tax
tax = subTotal * TAXRATE;
//final cost
finalCost = subTotal + tax;

//display subtotal, tax, and final cost
Console.WriteLine("\n\t Subtotal: {0}", subTotal.ToString("c"));
Console.WriteLine("\t Sales Tax: {0}", tax.ToString("c"));
Console.WriteLine("The total cost of this purchase: {0}", finalCost.ToString("c"));