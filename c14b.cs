// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


using System.Collections;
using System.Globalization;

double finalAPlusTax;
//int vinylCostA;
double finalA;
//double vinylCostB;
double finalBPlusTax;
double finalB;
int vinylNumber;


const double vinylCostA7 = 19.99;
const double vinylCostA12 = 22.99;
const double vinylCostB7 = 17.99;
const double vinylCostB12 = 20.99;
const double tax = 0.0725;



Console.WriteLine("** Welcome to the Record Shop **");
Console.WriteLine("Choose from one of the following types of Vinyl Records:");
Console.WriteLine(" \t\t1. 7-inch");
Console.WriteLine(" \t\t2. 12-inch");
Console.Write("Which type of records will be purchased? ");
vinylNumber = Convert.ToInt32(Console.ReadLine());
if (vinylNumber > 2)
{
    Console.WriteLine("ERROR: INVALID MENU OPTION SELECTED. PROGRAM WILL NOW END");
}
else
{

    if (vinylNumber == 1)
    {
        Console.WriteLine(" ");
        Console.Write("How many 7-inch records will be purchased? edit ");
        string countInchStr = Console.ReadLine();
        /*int vinylNumber;
        //int vinylAmount;
        double vinylCostSevenA;
        double vinylCostTwelveA;
        double vinylCostSevenB;
        double vinylCostTwelveB;
        double finalSevenA;
        double finalSevenB;
        double finalTwelveA;
        double finalTwelveB;
        double  finalSevenAPlusTax;
        double finalSevenBPlusTax;
        double finalTwelveAPlusTax;
        double finalTwelveBPlusTax;
        double tax = 0.0725;

        string count7InchStr;
        int count7InchInt;
        double total7Inch;
        string count12InchStr;
        int count12InchInt;
        double total12Inch;*/

        // variables im using
        int countInchInt = Convert.ToInt32(countInchStr);
        if (countInchInt < 1)
        {
            Console.WriteLine(" ");
            Console.WriteLine("ERROR: INVALID NUMBER OF RECORDS ENTERED. PROGRAM WILL NOW END edit");
        }
        else
        {



            double totalInch;
            if (countInchInt < 3)
            {
                Console.WriteLine(" ");
                totalInch = countInchInt * vinylCostA7;

                Console.WriteLine("         Subtotal: " + totalInch.ToString("c"));
                finalAPlusTax = totalInch * tax;

                Console.WriteLine("         Sales Tax: " + finalAPlusTax.ToString("c"));
                finalA = totalInch + (totalInch * tax);
                Console.WriteLine("The total cost of this purchase: " + finalA.ToString("c"));
            }
            else
            {
                Console.WriteLine(" ");
                totalInch = countInchInt * vinylCostB7;

                Console.WriteLine("         Subtotal: " + totalInch.ToString("c"));
                finalBPlusTax = totalInch * tax;

                Console.WriteLine("         Sales Tax: " + finalBPlusTax.ToString("c"));
                finalB = totalInch + (totalInch * tax);
                Console.WriteLine("The total cost of this purchase: " + finalB.ToString("c"));
            }
        }
    }
    else if (vinylNumber == 2)
    {
        Console.WriteLine(" ");
        Console.Write("How many 7-inch records will be purchased? edit ");
        string countInchStr = Console.ReadLine();
        int countInchInt = Convert.ToInt32(countInchStr);
        if (countInchInt < 1)
         {
             Console.WriteLine(" ");
             Console.WriteLine("ERROR: INVALID NUMBER OF RECORDS ENTERED. PROGRAM WILL NOW END");
         }
         else
         {

             if (countInchInt < 3)
             {
                Console.WriteLine(" ");
                totalInch = countInchInt * vinylCostA7;

                Console.WriteLine("         Subtotal: " + totalInch.ToString("c"));
                finalAPlusTax = totalInch * tax;

                Console.WriteLine("         Sales Tax: " + finalAPlusTax.ToString("c"));
                finalA = totalInch + (totalInch * tax);
                Console.WriteLine("The total cost of this purchase: " + finalA.ToString("c"));
            }
            else
            {
                Console.WriteLine(" ");
                totalInch = countInchInt * vinylCostB7;

                Console.WriteLine("         Subtotal: " + totalInch.ToString("c"));
                finalBPlusTax = totalInch * tax;

                Console.WriteLine("         Sales Tax: " + finalBPlusTax.ToString("c"));
                finalB = totalInch + (totalInch * tax);
                Console.WriteLine("The total cost of this purchase: " + finalB.ToString("c"));
            }

         }
     }
        Console.WriteLine("inside of 12");
    }
    else
    {
        Console.WriteLine("ERROR: INVALID NUMBER OF RECORDS ENTERED. PROGRAM WILL NOW END");
    }
    Console.WriteLine("         Sales Tax: " + finalAPlusTax.ToString("c"));
    finalA = totalInch + (totalInch * tax);
    Console.WriteLine("The total cost of this purchase: " + finalA.ToString("c"));
}

Console.WriteLine("         Sales Tax: " + finalAPlusTax.ToString("c"));
finalA = totalInch + (totalInch * tax);
Console.WriteLine("The total cost of this purchase: " + finalA.ToString("c"));
/*Console.WriteLine(" Subtotal: " + total7Inch.ToString("c"));

finalSevenAPlusTax = total7Inch * tax;

Console.WriteLine("Sales Tax: " + finalSevenAPlusTax.ToString("c"));

finalSevenA = total7Inch + (total7Inch * tax);

Console.WriteLine("The total cost of this purchase: " + finalSevenA.ToString("c"));*/