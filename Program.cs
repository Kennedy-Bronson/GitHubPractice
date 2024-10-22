
namespace whileloop2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //loop for the Main Menu + error message
            int sprayChoice = 0; //Shows the choice of LieSol or Microbond
            int lieAmt = 0; //Amount of LieSol bought
            int microAmt = 0; //Amount of Microbond bought
            // calculations for the tax
            double tax = 0; //Sales tax
            double subTotal = 0; //The total minus the sales tax
            double total = 0; //The subtotal plus the tax

            //constants for the price of 1 - 2 and 3 + of each respectively
            const double LIESOL1 = 8.99; // Price of 1-2 LieSol Sprays
            const double LIESOL2 = 8.75; // Price of 3+ LieSol Sprays
            const double MICRO1 = 7.99; // Price of 1-2 Microbond Sprays
            const double MICRO2 = 7.50; // Price of 3+ Microbond Sprays
            const double TAXRATE = 0.0475; //Sales tax amount


            //Validate the choice input; Main Menu
            Console.WriteLine("** Welcome to the Wake Tech Disinfectant Shop");
            Console.WriteLine("Choose from one of the following types of Disinfectant Sprays:");
            Console.WriteLine("\t1. LieSol");
            Console.WriteLine("\t2. Microbond");
            Console.Write("Which type of Disinfectant will be purchased? ");
            sprayChoice = Convert.ToInt32(Console.ReadLine());

            //Display error if the choice is less/more than 1-2
            while (sprayChoice < 1 || sprayChoice > 2)
            {
                Console.WriteLine(" ");
                Console.WriteLine("ERROR: INVALID MENU OPTION. PLEASE TRY AGAIN.");
                Console.WriteLine(" ");
                Console.WriteLine("** Welcome to the Wake Tech Disinfectant Shop");
                Console.WriteLine("Choose from one of the following types of Disinfectant Sprays:");
                Console.WriteLine("\t1. LieSol");
                Console.WriteLine("\t2. Microbond");
                Console.Write("Which type of Disinfectant will be purchased? ");
                sprayChoice = Convert.ToInt32(Console.ReadLine());
            }

            //Display next menu if the choice is valid
            //LieSol purchase
            while (sprayChoice == 1) //If LieSol is chosen
            {
                Console.WriteLine(" ");
                Console.Write("How many LieSol sprays will be purchased? (min: 1)? ");
                lieAmt = Convert.ToInt32(Console.ReadLine());

                while (lieAmt <= 0)  // Keep asking until a you get a value that is not zero or less
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("ERROR: INVALID NUMBER OF LIESOL SPRAYS ENTERED. TRY AGAIN.");
                    Console.WriteLine(" ");
                    Console.Write("How many LieSol sprays will be purchased? (min: 1)? ");
                    lieAmt = Convert.ToInt32(Console.ReadLine());
                }

                // Calculate price based on quantity
                if (lieAmt == 1 || lieAmt == 2) //If the amount is 1 or 2
                {
                    subTotal = lieAmt * LIESOL1;
                }
                else // If lieAmt >= 3
                {
                    subTotal = lieAmt * LIESOL2;
                }

                //Calculations
                tax = TAXRATE * subTotal;
                total = subTotal + tax;

                Console.WriteLine(" ");
                Console.WriteLine("\tSubtotal:\t\t" + subTotal.ToString("c"));
                Console.WriteLine("\tSales Tax:\t\t" + tax.ToString("c"));
                Console.WriteLine("The total cost of this purchase: " + total.ToString("c"));
                break;
            }

            //Microbond purchase
            while (sprayChoice == 2) //If Microbond is chosen
            {
                Console.WriteLine(" ");
                Console.Write("How many Microbond sprays will be purchased? (min: 1)? ");
                microAmt = Convert.ToInt32(Console.ReadLine());

                while (microAmt <= 0)  // Keep asking until a you get a value that is not zero or less
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("ERROR: INVALID NUMBER OF MICROBOND SPRAYS ENTERED. TRY AGAIN.");
                    Console.WriteLine(" ");
                    Console.Write("How many Microbond sprays will be purchased? (min: 1)? ");
                    microAmt = Convert.ToInt32(Console.ReadLine());
                }

                // Calculate price based on quantity
                if (microAmt == 1 || microAmt == 2) //If the amount is 1 or 2
                {
                    subTotal = microAmt * MICRO1;
                }
                else // If microAmt >= 3
                {
                    subTotal = microAmt * MICRO2;
                }

                //Calculations
                tax = TAXRATE * subTotal;
                total = subTotal + tax;

                Console.WriteLine(" ");
                Console.WriteLine("\tSubtotal:\t\t" + subTotal.ToString("c"));
                Console.WriteLine("\tSales Tax:\t\t" + tax.ToString("c"));
                Console.WriteLine("The total cost of this purchase: " + total.ToString("c"));
                break;
            }
        }
    }
}