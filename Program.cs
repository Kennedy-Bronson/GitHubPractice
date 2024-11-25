

namespace ServiceDeskSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitProgram = false; // Doesnt exit the program until prompted

            while (!exitProgram) 
            {
                int choice = mainMenuChoice();

                switch (choice)
                {
                    case 1: 
                        // Run the simulation
                        RunSimulation();
                        break;
                    case 2: 
                        // Exit the program
                        Console.WriteLine("Program will now exit.");
                        exitProgram = true; // Exit prompt
                        break;
                }
            }
        }

        /// Displays the main menu and gets a valid user choice. Returns 1 to run or 2 to quit
        static int mainMenuChoice()
        {
            int choice = 0;
            bool validInput = false; // Doesnt make the menu choice until prompted

            while (!validInput)
            {
                Console.WriteLine("-- Welcome to the Service Desk Simulator --");
                Console.WriteLine("Choose from one of the following options:");
                Console.WriteLine("\t1. Process 100 Service Desk Requests");
                Console.WriteLine("\t2. Exit");
                Console.Write("Enter your choice (1 or 2): ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                {
                    if (choice == 1 || choice == 2)
                    { // validates the choice of 1 or 2
                        validInput = true; 
                    }
                    else
                    { // Error message
                        Console.WriteLine("ERROR: INVALID MENU CHOICE. TRY AGAIN.\n");
                    }
                }
                else
                { // 2nd error message to as a backup
                    Console.WriteLine("ERROR: INVALID MENU CHOICE. TRY AGAIN.\n");
                }
            }

            Console.WriteLine(" "); // blank line for readability
            return choice;
        }

        /// Generates a random priority level (High, Medium, Low)
        /// 2nd random number generator implemented
        /// Returns a string representing the priority level
        static string generatePriority(Random rand)
        {
            int priorityNumber = rand.Next(1, 4); // Generates 1, 2, or 3

            switch (priorityNumber) // randomizes priority
            {
                case 1:
                    return "High";
                case 2:
                    return "Medium";
                case 3:
                    return "Low";
                default:
                    return "Low"; // Default case (should not happen)
            }
        }

        /// Generates a random service time between 5 and 8 minutes
        /// Random number generator instance
        /// Returns an integer representing the service time in minutes
        static int generateServiceTime(Random rand)
        {
            return rand.Next(5, 9); // Generates 5, 6, 7, or 8
        }

        /// Runs simulation by generating requests and displaying statistics
        static void RunSimulation()
        {
            const int numberOfRequests = 100; // Generates requests up to 100
            string[] priorities = new string[numberOfRequests]; // Generates priority levels
            int[] serviceTimes = new int[numberOfRequests]; // Generates wait times
            Random rand = new Random(); 

            // Populate the arrays with random data
            for (int i = 0; i < numberOfRequests; i++)
            {
                priorities[i] = generatePriority(rand);
                serviceTimes[i] = generateServiceTime(rand);
            }

            // Display the service desk statistics
            serviceDeskStats(priorities, serviceTimes, numberOfRequests);
        }

        /// Displays all service requests and statistics about priorities and service times
        /// Array of priority levels and service times
        /// Total number of service requests
        static void serviceDeskStats(string[] priorities, int[] serviceTimes, int numberOfRequests)
        {
            Console.WriteLine("\t\t-Service Line Stats-");
            Console.WriteLine(" ");
            Console.WriteLine("Request #\t\t\tPriority Level\tService Time");

            // Display each service request
            for (int i = 0; i < numberOfRequests; i++) // Increment each service request by 1
            {
                Console.WriteLine($"Service Request #{i + 1}\t{priorities[i]}\t\t{serviceTimes[i]} minutes"); 
            }

            Console.WriteLine("\nStats:");
            // Initialize counters and accumulators
            int highCount = 0, mediumCount = 0, lowCount = 0;
            int highTotalTime = 0, mediumTotalTime = 0, lowTotalTime = 0;

            // Calculate counts and total service times
            for (int i = 0; i < numberOfRequests; i++)
            {
                switch (priorities[i])
                { // Each case tells which specific parts need to be counted for each priority level
                    case "High":
                        highCount++;
                        highTotalTime += serviceTimes[i];
                        break;
                    case "Medium":
                        mediumCount++;
                        mediumTotalTime += serviceTimes[i];
                        break;
                    case "Low":
                        lowCount++;
                        lowTotalTime += serviceTimes[i];
                        break;
                }
            }

            // Calculate average service times
            double highAvg = highCount > 0 ? (double)highTotalTime / highCount : 0;
            double mediumAvg = mediumCount > 0 ? (double)mediumTotalTime / mediumCount : 0;
            double lowAvg = lowCount > 0 ? (double)lowTotalTime / lowCount : 0;

            // Display counts and averages
            Console.WriteLine($"\tTotal # of High Priority Requests: {highCount} \n\tAverage Service Time Per High Priority Request: {highAvg:F2} minutes");
            Console.WriteLine(" ");
            Console.WriteLine($"\tTotal # of Medium Priority Requests: {mediumCount} \n\tAverage Service Time Per Medium Priority Request: {mediumAvg:F2} minutes");
            Console.WriteLine(" ");
            Console.WriteLine($"\tTotal # of Low Priority Requests: {lowCount} \n\tAverage Service Time Per Low Priority Request: {lowAvg:F2} minutes");
            Console.WriteLine(" "); // Blank line for readability
            Console.WriteLine(" "); // Blank line for readability
        }
    }
}