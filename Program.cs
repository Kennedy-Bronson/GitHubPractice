namespace SimpleBanking
{
    class Program
    {
        // Constants for currency
        public const double HUNDRED = 100.00;
        public const double FIFTY = 50.00;
        public const double TWENTY = 20.00;
        public const double TEN = 10.00;
        public const double FIVE = 5.00;
        public const double ONE = 1.00;
        public const double QUARTER = 0.25;
        public const double DIME = 0.10;
        public const double NICKEL = 0.05;
        public const double PENNY = 0.01;

        // Transaction counters
        static int singleTransactionCount = 0;
        static int singleDepositCount = 0;
        static int singleWithdrawalCount = 0;
        static int generatedTransactionCount = 0;
        static int generatedDepositCount = 0;
        static int generatedWithdrawalCount = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to Clickety Clank Bank!");
            Random rnd = new Random();
            double balance = rnd.Next(1, 5000);
            RunBank(balance);
        }

        static void RunBank(double startingBalance) // Starts the program
        {
            double currentBalance = startingBalance;
            double totalDeposits = 0;
            double totalWithdrawals = 0;
            int transactionCount = 0;
            string choice;

            do
            { //main menu choice validation
                choice = getMainMenuChoice();
                switch (choice.ToUpper())
                {
                    case "A":
                        ProcessTransaction(ref currentBalance, ref totalDeposits, ref totalWithdrawals, ref transactionCount);
                        break;
                    case "B":
                        ProcessRandomTransactions(ref currentBalance, ref totalDeposits, ref totalWithdrawals, ref transactionCount);
                        break;
                    case "C":
                        PrintFinalReport(currentBalance, totalDeposits, totalWithdrawals, transactionCount);
                        break;
                    default:
                        Console.WriteLine("\nERROR: INVALID MENU CHOICE. TRY AGAIN.");
                        break;
                }
            } while (choice.ToUpper() != "C");
        }

        static string getMainMenuChoice() // Validates + displays main menu choice
        {
            // main menu
            Console.WriteLine("\n\t--Main Menu--");
            Console.WriteLine("Choose a from one of the following:");
            Console.WriteLine("\tA - Single Transaction");
            Console.WriteLine("\tB - Multiple Transactions");
            Console.WriteLine("\tC - Exit");
            Console.Write("\nEnter your choice (A, B, or C): ");
            return Console.ReadLine();
        }

        static string getTransactionMenuChoice(double balance) // Validates + displays transaction menu choice
        {
            string choice;
            do
            {
                if (balance < 5.00)
                { 
                    //error message; invalid data
                    Console.WriteLine("\n\tWARNING: LOW ACCOUNT BALANCE. PROCEED WITH A DEPOSIT.");
                    return "A";
                }
                // single transaction menu display
                Console.WriteLine("\n\t--Single Transaction Menu--");
                Console.WriteLine($"Your current account balance is: {balance:C}");
                Console.WriteLine("\nWhat would you like to do today?");
                Console.WriteLine("\tA - Make Deposit");
                Console.WriteLine("\tB - Make Withdrawal");
                Console.Write("Enter choice (A or B): ");
                choice = Console.ReadLine().ToUpper();

                if (choice == "A" || (choice == "B" && balance >= 5.00))
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("\nERROR: INVALID MENU CHOICE. TRY AGAIN.");
                    // Re-display the menu options in the next iteration
                }
            } while (true);
        }

        static string getDepositMenuChoice() // Validates + displays single/deposit menu choice
        {
            string choice;
            do
            {
                Console.WriteLine("\n\t--Deposit Menu--");
                Console.WriteLine("\nEnter your type of deposit:");
                Console.WriteLine("\tA - Cash Only");
                Console.WriteLine("\tB - Change Only");
                Console.Write("Enter your choice (A or B): ");
                choice = Console.ReadLine().ToUpper();

                if (choice == "A" || choice == "B")
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("\nERROR: INVALID MENU CHOICE. TRY AGAIN.");
                    // Re-display the menu options in the next iteration
                }
            } while (true);
        }

        static void currencyBreakdown(string depositType, ref double balance, ref double totalDeposits, ref int transactionCount)
        { // breaks down the amount of money tendered in one session
            double depositAmount = 0;

            // Variables for counting bills and coins
            int hundreds = 0, fifties = 0, twenties = 0, tens = 0, fives = 0, ones = 0;
            int quarters = 0, dimes = 0, nickels = 0, pennies = 0;

            if (depositType.ToUpper() == "A")  // Cash
            {
                //Console.WriteLine("\nEnter the number of hundreds (min: 0, max: 100): ");

                hundreds = GetValidInput("\nEnter the number of hundreds (min: 0, max: 100): ", 0, 100);
                fifties = GetValidInput("\nEnter the number of fifties (min: 0, max: 100): ", 0, 100);
                twenties = GetValidInput("\nEnter the number of twenties (min: 0, max: 100): ", 0, 100);
                tens = GetValidInput("\nEnter the number of tens (min: 0, max: 100): ", 0, 100);
                fives = GetValidInput("\nEnter the number of fives (min: 0, max: 100): ", 0, 100);
                ones = GetValidInput("\nEnter the number of ones (min: 0, max: 100): ", 0, 100);

                depositAmount = (hundreds * HUNDRED) + (fifties * FIFTY) + (twenties * TWENTY) +
                              (tens * TEN) + (fives * FIVE) + (ones * ONE);
            }
            else  // Coins
            {
                //Console.WriteLine("\n\tEnter count for each coin (0-100):");

                quarters = GetValidInput("\nEnter the number of quarters (min: 0, max: 100): ", 0, 100);
                dimes = GetValidInput("\nEnter the number of dimes (min: 0, max: 100): ", 0, 100);
                nickels = GetValidInput("\nEnter the number of nickels (min: 0, max: 100): ", 0, 100);
                pennies = GetValidInput("\nEnter the number of pennies (min: 0, max: 100): ", 0, 100);

                depositAmount = (quarters * QUARTER) + (dimes * DIME) + (nickels * NICKEL) + (pennies * PENNY);
            }

            // Update balances
            balance += depositAmount;
            totalDeposits += depositAmount;
            transactionCount++;

            // Print receipt
            PrintDepositReceipt(depositAmount, balance, hundreds, fifties, twenties, tens, fives, ones,
                              quarters, dimes, nickels, pennies);
        }

        static int GetValidInput(string prompt, int min, int max)
        { // determines what happens if a valid input is entered
            int value;
            do
            {
                Console.Write(prompt);
                if (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
                {
                    Console.WriteLine($"\tPlease enter a number between {min} and {max}");
                    //  prompt will be re-displayed in the next iteration
                    continue;
                }
                break;
            } while (true);
            return value;
        }

        static void ProcessTransaction(ref double balance, ref double totalDeposits, ref double totalWithdrawals, ref int transactionCount)
        { // calculates the breakdown from single deposits + withdrawals
            string transChoice = getTransactionMenuChoice(balance);

            if (transChoice == "A")
            {
                string depChoice = getDepositMenuChoice();
                currencyBreakdown(depChoice, ref balance, ref totalDeposits, ref transactionCount);
                singleTransactionCount++;
                singleDepositCount++;
            }
            else if (transChoice == "B")
            {
                ProcessWithdrawal(ref balance, ref totalWithdrawals, ref transactionCount);
                singleTransactionCount++;
                singleWithdrawalCount++;
            }
        }

        static void ProcessWithdrawal(ref double balance, ref double totalWithdrawals, ref int transactionCount)
        { // calculates the breakdown from withdrawals
            double amount;
            do
            {
                Console.Write($"\n\tHow much would you like to withdraw from your account? (max: {balance:C}) $");

                if (double.TryParse(Console.ReadLine(), out amount) && amount > 0 && amount <= balance)
                {
                    // Proceed with the withdrawal
                    break;
                }
                else
                {
                    Console.WriteLine("\nERROR: INVALID WITHDRAWAL AMOUNT. TRY AGAIN.");
                    // prompt will be re-displayed 
                }
            } while (true);

        }

        static void ProcessRandomTransactions(ref double balance, ref double totalDeposits, ref double totalWithdrawals, ref int transactionCount)
        { // calculates the breakdown from multiple deposits
            int count;
            do
            {
                Console.Write("\nHow many transactions would you like to generate? (min: 1, max: 10) ");
                if (int.TryParse(Console.ReadLine(), out count) && count >= 1 && count <= 10)
                {
                    // Valid input; proceed to generate transactions
                    break;
                }
                else
                {
                    Console.WriteLine("INVALID NUMBER OF TRANSACTIONS. Try Again.");
                }
            } while (true);

            // Proceed to generate and process the transactions
            for (int i = 0; i < count; i++)
            {
                Random rnd = new Random();
                bool isDeposit = rnd.Next(0, 2) == 0; // Randomly choose deposit or withdrawal

                if (isDeposit)
                {
                    // Process Random Deposit
                    double amount = rnd.Next(1, 1000);
                    balance += amount;
                    totalDeposits += amount;

                    // Calculate denominations for the deposited amount
                    long cents = (long)(amount * 100);
                    int hundreds = (int)(cents / 10000); cents %= 10000;
                    int fifties = (int)(cents / 5000); cents %= 5000;
                    int twenties = (int)(cents / 2000); cents %= 2000;
                    int tens = (int)(cents / 1000); cents %= 1000;
                    int fives = (int)(cents / 500); cents %= 500;
                    int ones = (int)(cents / 100); cents %= 100;
                    int quarters = (int)(cents / 25); cents %= 25;
                    int dimes = (int)(cents / 10); cents %= 10;
                    int nickels = (int)(cents / 5); cents %= 5;
                    int pennies = (int)cents;

                    // Print receipt
                    ProcessRandomDepositReceipt(amount, balance, generatedTransactionCount);
                    PrintDepositReceipt(amount, balance, hundreds, fifties, twenties, tens, fives, ones,
                                      quarters, dimes, nickels, pennies);

                    generatedDepositCount++;
                }
                else
                {
                    // Process Random Withdrawal
                    double maxWithdrawal = Math.Min(balance, 1000);

                    if (maxWithdrawal >= 1)
                    {
                        double amount = rnd.Next(1, (int)maxWithdrawal);
                        balance -= amount;
                        totalWithdrawals += amount;

                        // Calculate denominations for the withdrawn amount
                        long cents = (long)(amount * 100);
                        int hundreds = (int)(cents / 10000); cents %= 10000;
                        int fifties = (int)(cents / 5000); cents %= 5000;
                        int twenties = (int)(cents / 2000); cents %= 2000;
                        int tens = (int)(cents / 1000); cents %= 1000;
                        int fives = (int)(cents / 500); cents %= 500;
                        int ones = (int)(cents / 100); cents %= 100;
                        int quarters = (int)(cents / 25); cents %= 25;
                        int dimes = (int)(cents / 10); cents %= 10;
                        int nickels = (int)(cents / 5); cents %= 5;
                        int pennies = (int)cents;

                        // Print receipt
                        ProcessRandomWithdrawalReceipt(amount, balance, generatedTransactionCount);
                        PrintWithdrawalReceipt(amount, balance, hundreds, fifties, twenties, tens, fives, ones,
                                             quarters, dimes, nickels, pennies);

                        generatedWithdrawalCount++;
                    }
                    else if (maxWithdrawal > 0)
                    {
                        double amount = maxWithdrawal; // Withdraw the remaining balance
                        balance -= amount;
                        totalWithdrawals += amount;

                        // Calculate denominations for the withdrawn amount
                        long cents = (long)(amount * 100);
                        int hundreds = (int)(cents / 10000); cents %= 10000;
                        int fifties = (int)(cents / 5000); cents %= 5000;
                        int twenties = (int)(cents / 2000); cents %= 2000;
                        int tens = (int)(cents / 1000); cents %= 1000;
                        int fives = (int)(cents / 500); cents %= 500;
                        int ones = (int)(cents / 100); cents %= 100;
                        int quarters = (int)(cents / 25); cents %= 25;
                        int dimes = (int)(cents / 10); cents %= 10;
                        int nickels = (int)(cents / 5); cents %= 5;
                        int pennies = (int)cents;

                        // Print receipt
                        ProcessRandomWithdrawalReceipt(amount, balance, generatedTransactionCount);
                        PrintWithdrawalReceipt(amount, balance, hundreds, fifties, twenties, tens, fives, ones,
                                             quarters, dimes, nickels, pennies);

                        generatedWithdrawalCount++;
                    }
                    // Else, insufficient balance to make a withdrawal; skip this transaction
                }
                // variables that determine the transaction #
                transactionCount++;
                generatedTransactionCount++;
            }
        }

        static void ProcessRandomDepositReceipt(double amount, double balance, int generatedTransactionCount)
        {
            // increments the transaction # by +1 (deposits)
            Console.WriteLine(" ");
            Console.WriteLine("\n------Transaction #" + (generatedTransactionCount + 1) + " Receipt------ ");
        }

        static void ProcessRandomWithdrawalReceipt(double amount, double balance, int generatedTransactionCount)
        {
            // increments the transaction # by +1 (deposits)
            Console.WriteLine(" ");
            Console.WriteLine("\n------Transaction #" + (generatedTransactionCount + 1) + " Receipt------ ");
        }

        static void PrintDepositReceipt(double amount, double balance, int hundreds, int fifties,
            int twenties, int tens, int fives, int ones, int quarters, int dimes, int nickels, int pennies)
        {
            // Random deposit menu + breakdown
            Console.WriteLine("\n\t\tDeposit Breakdown:");
            Console.WriteLine("\n\tCount \t\t Amount");


            if (hundreds > 0) Console.WriteLine("\t" + hundreds + " x $100.00  \t" + (hundreds * HUNDRED).ToString("C"));
            if (fifties > 0) Console.WriteLine("\t" + fifties + " x $50.00  \t" + (fifties * FIFTY).ToString("C"));
            if (twenties > 0) Console.WriteLine("\t" + twenties + " x $20.00  \t" + (twenties * TWENTY).ToString("C"));
            if (tens > 0) Console.WriteLine("\t" + tens + " x $10.00  \t" + (tens * TEN).ToString("C"));
            if (fives > 0) Console.WriteLine("\t" + fives + " x $5.00  \t" + (fives * FIVE).ToString("C"));
            if (ones > 0) Console.WriteLine("\t" + ones + " x $1.00  \t" + (ones * ONE).ToString("C"));
            if (quarters > 0) Console.WriteLine("\t" + quarters + " x $0.25  \t" + (quarters * QUARTER).ToString("C"));
            if (dimes > 0) Console.WriteLine("\t" + dimes + " x $0.10  \t" + (dimes * DIME).ToString("C"));
            if (nickels > 0) Console.WriteLine("\t" + nickels + " x $0.05  \t" + (nickels * NICKEL).ToString("C"));
            if (pennies > 0) Console.WriteLine("\t" + pennies + " x $0.01  \t" + (pennies * PENNY).ToString("C"));
            Console.WriteLine("\n\t Amount Transacted: " + amount.ToString("C"));

        }

        static void PrintWithdrawalReceipt(double amount, double balance, int hundreds, int fifties,
            int twenties, int tens, int fives, int ones, int quarters, int dimes, int nickels, int pennies)
        {
            // Random withdrawal menu + breakdown
            Console.WriteLine("\n\t\tWithdrawal Breakdown:");
            Console.WriteLine("\n\tCount \t\t Amount");

            if (hundreds > 0) Console.WriteLine("\t" + hundreds + " x $100.00  \t" + (hundreds * HUNDRED).ToString("C"));
            if (fifties > 0) Console.WriteLine("\t" + fifties + " x $50.00  \t" + (fifties * FIFTY).ToString("C"));
            if (twenties > 0) Console.WriteLine("\t" + twenties + " x $20.00  \t" + (twenties * TWENTY).ToString("C"));
            if (tens > 0) Console.WriteLine("\t" + tens + " x $10.00  \t" + (tens * TEN).ToString("C"));
            if (fives > 0) Console.WriteLine("\t" + fives + " x $5.00  \t" + (fives * FIVE).ToString("C"));
            if (ones > 0) Console.WriteLine("\t" + ones + " x $1.00  \t" + (ones * ONE).ToString("C"));
            if (quarters > 0) Console.WriteLine("\t" + quarters + " x $0.25  \t" + (quarters * QUARTER).ToString("C"));
            if (dimes > 0) Console.WriteLine("\t" + dimes + " x $0.10  \t" + (dimes * DIME).ToString("C"));
            if (nickels > 0) Console.WriteLine("\t" + nickels + " x $0.05  \t" + (nickels * NICKEL).ToString("C"));
            if (pennies > 0) Console.WriteLine("\t" + pennies + " x $0.01 = \t" + (pennies * PENNY).ToString("C"));
            Console.WriteLine("\n\t Amount Transacted: " + amount.ToString("C"));

            
        }

        static void PrintFinalReport(double balance, double totalDeposits, double totalWithdrawals, int transactionCount)
        {
            // Print Final Balance and Exit Program
            Console.WriteLine("\nThank you for visiting Clickety Clank Bank!\n\n");

            Console.WriteLine("\n--Current Balance--");
            Console.WriteLine("Personal Account Balance:\t" + balance.ToString("C"));

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("\t\t --All Transaction Report -- ");
            Console.WriteLine("\t# of transactions: \t\t\t" + (transactionCount));
            Console.WriteLine(" ");
            Console.WriteLine("\t# of single transactions: \t\t" + singleTransactionCount);
            Console.WriteLine("\t\t# of single deposits: \t\t" + singleDepositCount);
            Console.WriteLine("\t\t# single withdrawals: \t\t" + singleWithdrawalCount);
            Console.WriteLine(" ");
            Console.WriteLine("\t# of generated Transactions: \t\t" + generatedTransactionCount);
            Console.WriteLine("\t\t# of generated deposits: \t" + generatedDepositCount);
            Console.WriteLine("\t\t# of generated withdrawals: \t" + generatedWithdrawalCount);
            Console.WriteLine(" ");
            Console.WriteLine("\t# of deposits: \t\t\t" + (singleDepositCount + generatedDepositCount));
            Console.WriteLine("\t# of withdrawals: \t\t" + (singleWithdrawalCount + generatedWithdrawalCount));

            // Calculate the bills and coins
            double withdrawalCalculation = totalWithdrawals;

            Console.WriteLine(" ");
            Console.WriteLine("\tTotal Dollar Bills and Change Tendered:");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("\t" + "Count  \t\tAmount");

            // Withdraw $100 bills
            int withdrawAmountHundreds = (int)(withdrawalCalculation / HUNDRED);
            withdrawalCalculation %= HUNDRED;
            Console.WriteLine("\t" + withdrawAmountHundreds + "  x $100.00\t" + (withdrawAmountHundreds * HUNDRED).ToString("C"));

            // Withdraw $50 bills
            int withdrawAmountFifties = (int)(withdrawalCalculation / FIFTY);
            withdrawalCalculation %= FIFTY;
            Console.WriteLine("\t" + withdrawAmountFifties + "  x $50.00\t" + (withdrawAmountFifties * FIFTY).ToString("C"));

            // Withdraw $20 bills
            int withdrawAmountTwenties = (int)(withdrawalCalculation / TWENTY);
            withdrawalCalculation %= TWENTY;
            Console.WriteLine("\t" + withdrawAmountTwenties + "  x $20.00\t" + (withdrawAmountTwenties * TWENTY).ToString("C"));

            // Withdraw $10 bills
            int withdrawAmountTens = (int)(withdrawalCalculation / TEN);
            withdrawalCalculation %= TEN;
            Console.WriteLine("\t" + withdrawAmountTens + "  x $10.00\t" + (withdrawAmountTens * TEN).ToString("C"));

            // Withdraw $5 bills
            int withdrawAmountFives = (int)(withdrawalCalculation / FIVE);
            withdrawalCalculation %= FIVE;
            Console.WriteLine("\t" + withdrawAmountFives + "  x $5.00\t" + (withdrawAmountFives * FIVE).ToString("C"));

            // Withdraw $1 bills
            int withdrawAmountOnes = (int)(withdrawalCalculation / ONE);
            withdrawalCalculation %= ONE;
            Console.WriteLine("\t" + withdrawAmountOnes + "  x $1.00\t" + (withdrawAmountOnes * ONE).ToString("C"));

            // Withdraw quarters
            int withdrawAmountQuarters = (int)(withdrawalCalculation / QUARTER);
            withdrawalCalculation %= QUARTER;
            Console.WriteLine("\t" + withdrawAmountQuarters + "  x $0.25\t" + (withdrawAmountQuarters * QUARTER).ToString("C"));

            // Withdraw dimes
            int withdrawAmountDimes = (int)(withdrawalCalculation / DIME);
            withdrawalCalculation %= DIME;
            Console.WriteLine("\t" + withdrawAmountDimes + "  x $0.10\t" + (withdrawAmountDimes * DIME).ToString("C"));

            // Withdraw nickels
            int withdrawAmountNickels = (int)(withdrawalCalculation / NICKEL);
            withdrawalCalculation %= NICKEL;
            Console.WriteLine("\t" + withdrawAmountNickels + "  x $0.05\t" + (withdrawAmountNickels * NICKEL).ToString("C"));

            // Withdraw pennies
            int withdrawAmountPennies = (int)(withdrawalCalculation / PENNY);
            withdrawalCalculation %= PENNY;
            Console.WriteLine("\t" + withdrawAmountPennies + "  x $0.01\t" + (withdrawAmountPennies * PENNY).ToString("C"));

            Console.WriteLine(" ");
            Console.WriteLine("\tTotal Transacted:\t\t" + (totalDeposits + totalWithdrawals).ToString("C"));
            Console.WriteLine("\tTotal Deposited:\t\t" + totalDeposits.ToString("C"));
            Console.WriteLine("\tTotal Withdrawn:\t\t" + totalWithdrawals.ToString("C"));

          
        }
    }
}