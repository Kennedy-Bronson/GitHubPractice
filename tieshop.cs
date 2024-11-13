

namespace TieShopDemo
{
    class Program
    {
        // Global constants
        private const double SOLIDBOW = 5.99; //Cost of solid colored bows
        private const double PAISLEYBOW = 9.99; //Cost of paisley bows
        private const double STRIPEDBOW = 7.99; //Cost of striped bows
        private const double SOLIDTIE = 7.99; //Cost of solid colored ties
        private const double PAISLEYTIE = 9.99; //Cost of paisley ties
        private const double STRIPEDTIE = 11.99; //Cost of striped ties


        static int GetTies() // Asks how many ties will be ordered
        {
            Console.Write("Enter the number of ties: ");
            string input = Console.ReadLine();
            int number = Convert.ToInt32(input); ;

            while (number <= 0) // Error message thrown if the # is out of range
            {
                Console.WriteLine(" ");
                Console.WriteLine("ERROR: INVALID NUMBER OF TIES. TRY AGAIN.");
                Console.WriteLine(" ");
                Console.Write("Enter the number of ties: ");
                input = Console.ReadLine();
                number = Convert.ToInt32(input); ;
            }

            return number;  // Repeats the menu for how many ties you entered
        }

        static int GetTieType(int tieNumber) // Pass in # of ties to the function + prompts user for tie type
        {
            Console.WriteLine(" ");
            Console.WriteLine("Select from one of the following types of ties:");
            Console.WriteLine("\t 1. Bow Tie");
            Console.WriteLine("\t 2. Neck Tie");
            Console.Write("Please choose the tie type for tie #" + tieNumber + ": ");

            int tieType;
            string input = Console.ReadLine();
            while (input != "1" && input != "2") // Error message thrown if the # is out of range
            {
                Console.WriteLine(" ");
                Console.WriteLine("ERROR: INVALID TIE TYPE. TRY AGAIN.");
                Console.WriteLine(" ");
                Console.WriteLine("Select from one of the following types of ties:");
                Console.WriteLine("\t 1. Bow Tie");
                Console.WriteLine("\t 2. Neck Tie");
                Console.Write("Please choose the tie type for tie #" + tieNumber + ": ");
                input = Console.ReadLine();
            }

            tieType = Convert.ToInt32(input); 
            return tieType; // Makes the pattern factor into the cost
        }


        static int GetPattern(int tieNumber) // Pass in # of ties to the function + prompts user for tie pattern
        {
            Console.WriteLine("\nSelect from one of the following tie patterns:");
            Console.WriteLine("\t 1. Solid");
            Console.WriteLine("\t 2. Paisley");
            Console.WriteLine("\t 3. Striped");
            Console.Write("Please choose the tie pattern for tie #" + tieNumber + ": ");

            string input = Console.ReadLine();
            int tiePattern = Convert.ToInt32(input); 

            while (tiePattern < 1 || tiePattern > 3) // Error message thrown if the # is out of range
            {
                Console.WriteLine(" ");
                Console.WriteLine("ERROR: INVALID TIE PATTERN. TRY AGAIN.");
                Console.WriteLine(" ");
                Console.WriteLine("Select from one of the following tie patterns:");
                Console.WriteLine("\t 1. Solid");
                Console.WriteLine("\t 2. Paisley");
                Console.WriteLine("\t 3. Striped");
                Console.Write("Please choose the tie pattern for tie #" + tieNumber + ": ");
                input = Console.ReadLine();
                tiePattern = Convert.ToInt32(input); 
            }

            return tiePattern; // Makes the pattern factor into the cost
        }

        static double CalculateTieCost(int tieType, int tiePattern) // Compiles the cost of each tie 
        {
            double cost = 0.0;

            if (tieType == 1)  // Bow Tie
            {
                if (tiePattern == 1)
                    cost = SOLIDBOW;
                if (tiePattern == 2)
                    cost = PAISLEYBOW;
                if (tiePattern == 3)
                    cost = STRIPEDBOW;
            }
            else  // Neck Tie
            {
                if (tiePattern == 1)
                    cost = SOLIDTIE;
                if (tiePattern == 2)
                    cost = PAISLEYTIE;
                if (tiePattern == 3)
                    cost = STRIPEDTIE;
            }

            return cost; // Makes the cost seen by the program
        }

        static void Main() // Final calculations
        {
            // Get number of ties
            int numberOfTies = GetTies();
            double totalCost = 0.0;

            // Process each tie + loops through the number of how many ties there are + collects info on each one
            for (int i = 1; i <= numberOfTies; i++)
            {
                int tieType = GetTieType(i); // Collects the "type of tie" info
                int tiePattern = GetPattern(i); // Collects the "type of pattern" info
                double tieCost = CalculateTieCost(tieType, tiePattern); // Calculates the cost based on these parameters + adds it to the total

                // Calculates the total cost
                totalCost = totalCost + tieCost;
            }

            Console.WriteLine("\nThe total cost of all the ties in the order: " + totalCost.ToString("C"));
        }
    }
}
