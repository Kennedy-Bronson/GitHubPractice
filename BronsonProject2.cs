using System;
using System.ComponentModel;
using System.ComponentModel.Design;

Random rng = new Random();
double balance = Convert.ToDouble(rng.Next(1, 5000));
double originalBalance = Convert.ToDouble(rng.Next(1, 5000));
double alternateBalance = Convert.ToDouble(rng.Next(1, 5000));
string userChoice1 = ""; // holds main menu choice

// Constants for money values
//all constant doubles; can be put on the same line
const double HUNDRED = 100.00, FIFTY = 50.00, TWENTY = 20.00, TEN = 10.00, FIVE = 5.00, ONE = 1.00; 
const double QUARTER = 0.25, DIME = 0.10, NICKEL = 0.05, PENNY = 0.01;
// The total amount deposited
double depositAmount = 0.00;
double lowBalance = 5.00;

// Counters for transactions
int sdepositCnt = 0; // Single deposits
int swithdrawCnt = 0; // Single withdrawals
int gdepositCnt = 0; // Generated deposits
int gwithdrawCnt = 0; // Generated withdrawals
int stransactionCnt = 0; // Total single transactions
int gtransactionCnt = 0; // Total generated transactions
// The total amount in transactions
double amtTransacted = 0.00;

// Deposit money amounts
//double depositAmount; //the total amount of money deposited
double depositHundred = 0; //deposits $100
double depositFifty = 0.00; //deposits $50
double depositTwenty = 0.00; //deposits $20
double depositTen = 0.00; //deposits $10
double depositFive = 0.00; //deposits $5
double depositOne = 0.00; //deposits $1
double depositQuarters = 0.00; //deposits $0.25
double depositDimes = 0.00; //deposits $0.10
double depositNickels = 0.00; //deposits $0.05
double depositPennies = 0.00; //deposits $0.01

double runningDeposit = 0.00; //deposits $0.01
double runningWitdrawal = 0.00; //deposits $0.01

// Keeps the application running until you decide to end it
bool continueProgram = true;

while (continueProgram)
{
    // Display Main Menu
    Console.WriteLine("Welcome to Clickety Clank Bank!");
    Console.WriteLine("\n\t--Main Menu--");
    Console.WriteLine("Choose from one of the following:");
    Console.WriteLine("\t A - Single Transaction");
    Console.WriteLine("\t B - Generate Multiple Transactions");
    Console.WriteLine("\t C - Exit");
    Console.Write("Enter your choice (A, B, or C): ");
    userChoice1 = Console.ReadLine().ToUpper();

    if (userChoice1 == "A") //Single Transaction
    {
        // Single Transaction Menu
        Console.WriteLine("\n\t--Single Transaction Menu--");
        Console.WriteLine("Your current account balance is: " + balance.ToString("C"));
        Console.Write("\nWhat would you like to do today?\n\tA - Make a Deposit\n\tB - Make a Withdrawal\nEnter your choice (A or B): ");
        string transactionType = Console.ReadLine().ToUpper();

        if (originalBalance <= lowBalance) //is the balance is 5 dollars, make a deposit
        {
            Console.WriteLine("WARNING: LOW ACCOUNT BALANCE. PROCEED WITH A DEPOSIT.");
            transactionType = "A";
        }
        if (transactionType == "A")
        {
            // Deposit menu (kept as in the original code)
            Console.Write("\nEnter your type of deposit:\n\tA - Cash Only\n\tB - Change Only\nEnter your choice (A or B): ");
            string depositCase = Console.ReadLine().ToUpper();

            if (depositCase == "A")
            {

                if (depositHundred < 0 || depositHundred > 100)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("ERROR: INVALID NUMBER OF HUNDREDS ENTERED. 0 $100.00 Bills will be added. ");
                    depositHundred = 0;
                }
                else
                {
                    //do math
                    balance = balance + (HUNDRED * depositHundred);
                }
                //Input 50
                Console.WriteLine(" ");
                Console.Write("Enter the number of fifties (min: 0, max: 100): ");
                depositFifty = Convert.ToDouble(Console.ReadLine());

                if (depositFifty < 0 || depositFifty > 100)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("ERROR: INVALID NUMBER OF FIFTIES ENTERED. 0 $50.00 Bills will be added. ");
                    depositFifty = 0;
                }
                else
                {
                    //do math
                    balance = balance + (FIFTY * depositFifty);
                }


                //Input 20
                Console.WriteLine(" ");
                Console.Write("Enter the number of twenties (min: 0, max: 100): ");
                depositTwenty = Convert.ToDouble(Console.ReadLine());

                if (depositTwenty < 0 || depositTwenty > 100)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("ERROR: INVALID NUMBER OF TWENTIES ENTERED. 0 $20.00 Bills will be added. ");
                    depositTwenty = 0;
                }
                else
                {
                    //do math
                    balance = balance + (TWENTY * depositTwenty);
                }

                //Input 10
                Console.WriteLine(" ");
                Console.Write("Enter the number of tens (min: 0, max: 100): ");
                depositTen = Convert.ToDouble(Console.ReadLine());

                if (depositTen < 0 || depositTen > 100)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("ERROR: INVALID NUMBER OF TENS ENTERED. 0 $10.00 Bills will be added. ");
                    depositTen = 0;
                }
                else
                {
                    //do math
                    balance = balance + (TEN * depositTen);
                }

                //Input 5
                Console.WriteLine(" ");
                Console.Write("Enter the number of fives (min: 0, max: 100): ");
                depositFive = Convert.ToDouble(Console.ReadLine());

                if (depositFive < 0 || depositFive > 100)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("ERROR: INVALID NUMBER OF FIVES ENTERED. 0 $5.00 Bills will be added. ");
                    depositFive = 0;
                }
                else
                {
                    //do math
                    balance = balance + (FIVE * depositFive);
                }

                //Input 1
                Console.WriteLine(" ");
                Console.Write("Enter the number of ones (min: 0, max: 100): ");
                depositOne = Convert.ToDouble(Console.ReadLine());

                if (depositOne < 0 || depositOne > 100)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("ERROR: INVALID NUMBER OF ONES ENTERED. 0 $1.00 Bills will be added.");
                    depositOne = 0;
                }
                else
                {
                    //do math
                    balance = balance + (ONE * depositOne);
                }

                depositAmount = (HUNDRED * depositHundred) + (FIFTY * depositFifty) + (TWENTY * depositTwenty) +
                               (TEN * depositTen) + (FIVE * depositFive) + (ONE * depositOne);

                // Print Receipt
                sdepositCnt++;
                stransactionCnt++;
                Console.WriteLine("\n------Transaction Receipt------");
                Console.WriteLine("\tStarting Balance:\t" + (originalBalance - depositAmount).ToString("C"));
                Console.WriteLine("\tDeposit Amount:\t" + depositAmount.ToString("C"));
                Console.WriteLine(" ");

                Console.WriteLine("\t\t Deposit Breakdown");
                Console.WriteLine(" ");

                // deposit $100 bills
                int depositAmountHundreds = (int)(depositAmount / HUNDRED);  // Determine how many $100 bills
                depositAmount %= HUNDRED;  // Update withdrawAmount to remainder after $100 bills
                Console.WriteLine("\t" + depositAmountHundreds + "  x \t$100.00\t\t" + (depositAmountHundreds * HUNDRED).ToString("C"));

                // deposit $50 bills
                int withdrawAmountFifties = (int)(depositAmount / FIFTY);  // Determine how many $20 bills
                depositAmount %= FIFTY;  // Update withdrawAmount to remainder after $50 bills
                Console.WriteLine("\t" + withdrawAmountFifties + "  x \t$50.00\t\t" + (withdrawAmountFifties * FIFTY).ToString("C"));

                // deposit $20 bills
                int depositAmountTwenties = (int)(depositAmount / TWENTY);  // Determine how many $20 bills
                depositAmount %= TWENTY;  // Update withdrawAmount to remainder after $20 bills
                Console.WriteLine("\t" + depositAmountTwenties + "  x \t$20.00\t\t" + (depositAmountTwenties * TWENTY).ToString("C"));

                // deposit $10 bills
                int depositAmountTens = (int)(depositAmount / TEN);  // Determine how many $20 bills
                depositAmount %= TEN;  // Update withdrawAmount to remainder after $10 bills
                Console.WriteLine("\t" + depositAmountTens + "  x \t$10.00\t\t" + (depositAmountTens * TEN).ToString("C"));

                // deposit $5 bills
                int depositAmountFives = (int)(depositAmount / FIVE);  // Determine how many $20 bills
                depositAmount %= FIVE;  // Update withdrawAmount to remainder after $10 bills
                Console.WriteLine("\t" + depositAmountFives + "  x \t$5.00\t\t" + (depositAmountFives * FIVE).ToString("C"));

                // Depsoit $1 bills
                int depositAmountOnes = (int)(depositAmount / ONE);  // Determine how many $1 bills
                depositAmount %= ONE;  // Update withdrawAmount to remainder after $1 bills
                Console.WriteLine("\t" + depositAmountOnes + "  x \t$1.00\t\t" + (depositAmountOnes * ONE).ToString("C"));
                Console.WriteLine(" ");

                Console.WriteLine("\n\tEnding Balance:\t" + originalBalance.ToString("C"));
            }
            else if (depositCase == "B")
            {

                Console.WriteLine(" ");
                Console.Write("Enter the number of quarters (min: 0, max: 100): ");
                depositQuarters = Convert.ToDouble(Console.ReadLine());

                if (depositQuarters < 0 || depositQuarters > 100)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("ERROR: INVALID NUMBER OF QUARTERS ENTERED. 0 quarters will be added.");
                    depositQuarters = 0;
                }
                else
                {
                    balance = balance + (QUARTER * depositQuarters);
                }

                // Input dimes
                Console.WriteLine(" ");
                Console.Write("Enter the number of dimes (min: 0, max: 100): ");
                depositDimes = Convert.ToDouble(Console.ReadLine());

                if (depositDimes < 0 || depositDimes > 100)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("ERROR: INVALID NUMBER OF DIMES ENTERED. 0 dimes will be added.");
                    depositDimes = 0;
                }
                else
                {
                    balance = balance + (DIME * depositDimes);
                }

                // Input nickels
                Console.WriteLine(" ");
                Console.Write("Enter the number of nickels (min: 0, max: 100): ");
                depositNickels = Convert.ToDouble(Console.ReadLine());

                if (depositNickels < 0 || depositNickels > 100)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("ERROR: INVALID NUMBER OF NICKELS ENTERED. 0 nickels will be added.");
                    depositNickels = 0;
                }
                else
                {
                    balance = balance + (NICKEL * depositNickels);
                }

                // Input pennies
                Console.WriteLine(" ");
                Console.Write("Enter the number of pennies (min: 0, max: 100): ");
                depositPennies = Convert.ToDouble(Console.ReadLine());

                if (depositPennies < 0 || depositPennies > 100)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("ERROR: INVALID NUMBER OF PENNIES ENTERED. 0 pennies will be added.");
                    depositPennies = 0;
                }
                else
                {
                    balance = balance + (PENNY * depositPennies);
                }
                depositAmount = (QUARTER * depositQuarters) + (DIME * depositDimes) + (NICKEL * depositNickels) +
                               (PENNY * depositPennies);

                // Print Receipt
                sdepositCnt++;
                stransactionCnt++;
                runningDeposit = runningDeposit + depositAmount;
                Console.WriteLine("\n------Transaction Receipt------");
                Console.WriteLine("\tStarting Balance:\t" + (originalBalance - depositAmount).ToString("C"));

                Console.WriteLine("\tDeposit Amount:\t\t" + depositAmount.ToString("C"));
                Console.WriteLine(" ");

                Console.WriteLine("\t\t Deposit Breakdown");
                Console.WriteLine(" ");

                // deposit quarters
                int depositAmountQuarters = (int)(depositAmount / QUARTER);  // Determine how many $0.10 dimes
                depositAmount %= QUARTER;  // Update withdrawAmount to remainder after $0.10 dimes
                Console.WriteLine("\t" + depositAmountQuarters + "  x \t$0.25\t\t" + (depositAmountQuarters * QUARTER).ToString("C"));

                // deposit dimes
                int depositAmountDimes = (int)(depositAmount / DIME);  // Determine how many $0.10 dimes
                depositAmount %= DIME;  // Update withdrawAmount to remainder after $0.10 dimes
                Console.WriteLine("\t" + depositAmountDimes + "  x \t$0.10\t\t" + (depositAmountDimes * DIME).ToString("C"));

                // deposit nickels
                int depositAmountNickels = (int)(depositAmount / NICKEL);  // Determine how many $0.10 dimes
                depositAmount %= NICKEL;  // Update withdrawAmount to remainder after $0.10 dimes
                Console.WriteLine("\t" + depositAmountNickels + "  x \t$0.10\t\t" + (depositAmountNickels * NICKEL).ToString("C"));

                // deposit pennies
                int depositAmountPennied = (int)(depositAmount / PENNY);  // Determine how many $0.01 pennies
                depositAmount %= PENNY;  // Update withdrawAmount to remainder after pennies
                Console.WriteLine("\t" + depositAmountPennied + "  x \t$0.01\t\t" + (depositAmountPennied * PENNY).ToString("C"));
                
                Console.WriteLine(" ");
                Console.WriteLine("\n\tEnding Balance:\t" + originalBalance.ToString("C"));
            }
            else
            {
                Console.WriteLine("ERROR: Invalid Deposit Menu Choice. Returning to Single Transaction Menu.");
                continue;
            }
        }
        else if (transactionType == "B")
        {
            // Withdrawal menu
            Console.Write("\nEnter the amount to withdraw: ");
            double withdrawAmount = Convert.ToDouble(Console.ReadLine());

            if (withdrawAmount <= 0 || withdrawAmount > originalBalance)
            {
                Console.WriteLine("ERROR: Invalid withdrawal amount. Returning to Single Transaction Menu.");
            }
            else
            {
                originalBalance -= withdrawAmount;
                swithdrawCnt++;
                stransactionCnt++;

                // Print Receipt
                runningWitdrawal = runningWitdrawal + withdrawAmount;
                Console.WriteLine("\n------Transaction Receipt------");
                Console.WriteLine("\tStarting Balance:\t" + (originalBalance + withdrawAmount).ToString("C"));
                Console.WriteLine("\tWithdrawal Amount:\t" + withdrawAmount.ToString("C"));
                //
                // Withdraw $100 bills
                int withdrawAmountHundreds = (int)(withdrawAmount / HUNDRED);  // Determine how many $100 bills
                withdrawAmount %= HUNDRED;  // Update withdrawAmount to remainder after $100 bills
                Console.WriteLine("\t" + withdrawAmountHundreds + "  x \t$100.00\t\t" + (withdrawAmountHundreds * HUNDRED).ToString("C"));

                // Withdraw $50 bills
                int withdrawAmountFifties = (int)(withdrawAmount / FIFTY);  // Determine how many $20 bills
                withdrawAmount %= FIFTY;  // Update withdrawAmount to remainder after $50 bills
                Console.WriteLine("\t" + withdrawAmountFifties + "  x \t$50.00\t\t" + (withdrawAmountFifties * FIFTY).ToString("C"));

                // Withdraw $20 bills
                int withdrawAmountTwenties = (int)(withdrawAmount / TWENTY);  // Determine how many $20 bills
                withdrawAmount %= TWENTY;  // Update withdrawAmount to remainder after $20 bills
                Console.WriteLine("\t" + withdrawAmountTwenties + "  x \t$20.00\t\t" + (withdrawAmountTwenties * TWENTY).ToString("C"));

                // Withdraw $10 bills
                int withdrawAmountTens = (int)(withdrawAmount / TEN);  // Determine how many $20 bills
                withdrawAmount %= TEN;  // Update withdrawAmount to remainder after $10 bills
                Console.WriteLine("\t" + withdrawAmountTens + "  x \t$10.00\t\t" + (withdrawAmountTens * TEN).ToString("C"));

                // Withdraw $5 bills
                int withdrawAmountFives = (int)(withdrawAmount / FIVE);  // Determine how many $20 bills
                withdrawAmount %= FIVE;  // Update withdrawAmount to remainder after $10 bills
                Console.WriteLine("\t" + withdrawAmountFives + "  x \t$5.00\t\t" + (withdrawAmountFives * FIVE).ToString("C"));

                // Withdraw $1 bills
                int withdrawAmountOnes = (int)(withdrawAmount / ONE);  // Determine how many $1 bills
                withdrawAmount %= ONE;  // Update withdrawAmount to remainder after $1 bills
                Console.WriteLine("\t" + withdrawAmountOnes + "  x \t$1.00\t\t" + (withdrawAmountOnes * ONE).ToString("C"));
                Console.WriteLine("\n\tEnding Balance:\t" + originalBalance.ToString("C"));
            }
        }
        else
        {
            Console.WriteLine("ERROR: Invalid transaction type. Returning to Main Menu.");
        }
    }
    else if (userChoice1 == "B")
    {
        // Multiple Transactions on alternate balance
        Console.Write("\nHow many random transactions would you like to perform? ");
        int numTransactions = Convert.ToInt32(Console.ReadLine());

        if (numTransactions <= 0) //error message
        {
            Console.WriteLine("ERROR: Invalid number of transactions. Returning to Main Menu.");
            continue;
        }

        int loopCnt = 0; // Adds to the transaction breakdown at the end
        while (loopCnt < numTransactions)
        {
            Console.WriteLine($"\n-----Transaction #" + (loopCnt + 1) + " Receipt-----");
            double randomAmount = rng.Next(1, 200);
            bool isDeposit = rng.Next(0, 2) == 0; // Randomly choose deposit or withdrawal

            if (isDeposit)
            {
                // Deposit
                Console.WriteLine("\tDeposit Amount:\t\t" + randomAmount.ToString("C"));
                alternateBalance += randomAmount;
                runningDeposit = runningDeposit + randomAmount;
                gdepositCnt++;
            }
            else
            {
                // Withdrawal
                if (randomAmount > alternateBalance)
                {
                    Console.WriteLine("Skipping withdrawal of " + randomAmount.ToString("C") + ", not enough balance.");
                }
                else
                {
                    Console.WriteLine("\tWithdrawal Amount:\t" + randomAmount.ToString("C"));
                    amtTransacted = randomAmount;
                    alternateBalance -= randomAmount;
                    gwithdrawCnt++;
                    runningWitdrawal = runningWitdrawal + randomAmount;
                }
            }
            amtTransacted = randomAmount;
            Console.WriteLine(" ");
            Console.WriteLine("\t Count \t\t Amount ");
            int withdrawAmountHundreds = (int)(randomAmount / HUNDRED);  // Determine how many $100 bills
            randomAmount %= HUNDRED;  // Update withdrawAmount to remainder after $100 bills
            Console.WriteLine("\t" + withdrawAmountHundreds + "  x $100.00\t" + (withdrawAmountHundreds * HUNDRED).ToString("C"));

            // Withdraw $50 bills
            int withdrawAmountFifties = (int)(randomAmount / FIFTY);  // Determine how many $20 bills
            randomAmount %= FIFTY;  // Update withdrawAmount to remainder after $50 bills
            Console.WriteLine("\t" + withdrawAmountFifties + "  x $50.00\t" + (withdrawAmountFifties * FIFTY).ToString("C"));

            // Withdraw $20 bills
            int withdrawAmountTwenties = (int)(randomAmount / TWENTY);  // Determine how many $20 bills
            randomAmount %= TWENTY;  // Update withdrawAmount to remainder after $20 bills
            Console.WriteLine("\t" + withdrawAmountTwenties + "  x $20.00\t" + (withdrawAmountTwenties * TWENTY).ToString("C"));

            // Withdraw $10 bills
            int withdrawAmountTens = (int)(randomAmount / TEN);  // Determine how many $20 bills
            randomAmount %= TEN;  // Update withdrawAmount to remainder after $10 bills
            Console.WriteLine("\t" + withdrawAmountTens + "  x $10.00\t" + (withdrawAmountTens * TEN).ToString("C"));

            // Withdraw $5 bills
            int withdrawAmountFives = (int)(randomAmount / FIVE);  // Determine how many $20 bills
            randomAmount %= FIVE;  // Update withdrawAmount to remainder after $10 bills
            Console.WriteLine("\t" + withdrawAmountTens + "  x $5.00\t" + (withdrawAmountTens * FIVE).ToString("C"));

            // Withdraw $1 bills
            int withdrawAmountOnes = (int)(randomAmount / ONE);  // Determine how many $1 bills
            randomAmount %= ONE;  // Update withdrawAmount to remainder after $1 bills
            Console.WriteLine("\t" + withdrawAmountOnes + "  x $1.00\t" + (withdrawAmountOnes * ONE).ToString("C"));
            loopCnt++; // Increment the transaction counter
            gtransactionCnt++;

            Console.WriteLine("\n\tAmount Transacted:\t" + amtTransacted.ToString("C") + "\n");
        }
    }
    else if (userChoice1 == "C")
    {
        double totalTransacted = runningDeposit + runningWitdrawal;

        if (totalTransacted > 0)
        {


            // Print Final Balance and Exit Program
            Console.WriteLine("\nThank you for visiting Clickety Clank Bank!\n\n");

            Console.WriteLine("\n--Current Balance--\n");
            Console.WriteLine("Personal Account Balance:\t" + originalBalance.ToString("C"));
            // Console.WriteLine("\n\t\t--Final Original Balance--");
            // Print Summary of Transactions
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("\t\t --All Transaction Report -- ");
            Console.WriteLine("\t# of transactions: \t\t\t" + (stransactionCnt + gtransactionCnt));
            Console.WriteLine(" ");
            Console.WriteLine("\t# of single transactions: \t\t" + stransactionCnt);
            Console.WriteLine("\t\t# of single deposits: \t\t" + sdepositCnt);
            Console.WriteLine("\t\t# single withdrawals: \t\t" + swithdrawCnt);
            Console.WriteLine(" ");
            Console.WriteLine("\t# of generated Transactions: \t\t" + gtransactionCnt);
            Console.WriteLine("\t\t# of generated deposits: \t" + gdepositCnt);
            Console.WriteLine("\t\t# of generated withdrawals: \t" + gwithdrawCnt);
            Console.WriteLine(" ");
            Console.WriteLine("\t# of deposits: \t\t\t" + (sdepositCnt + gdepositCnt));
            Console.WriteLine("\t# of withdrawals: \t\t" + (swithdrawCnt + gwithdrawCnt));

            // Calculate the bills and coin
            Console.WriteLine(" ");
            Console.WriteLine("\tTotal Dollar Bills and Change Tendered:");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("\n\t" + "Count  \t\tAmount");

            // Withdraw $100 bills
            int withdrawAmountHundreds = (int)(totalTransacted / HUNDRED);  // Determine how many $100 bills
            totalTransacted %= HUNDRED;  // Update withdrawAmount to remainder after $100 bills
            Console.WriteLine("\t" + withdrawAmountHundreds + "  x \t$100.00\t\t" + (withdrawAmountHundreds * HUNDRED).ToString("C"));

            // Withdraw $50 bills
            int withdrawAmountFifties = (int)(totalTransacted / FIFTY);  // Determine how many $20 bills
            totalTransacted %= FIFTY;  // Update withdrawAmount to remainder after $50 bills
            Console.WriteLine("\t" + withdrawAmountFifties + "  x \t$50.00\t\t" + (withdrawAmountFifties * FIFTY).ToString("C"));

            // Withdraw $20 bills
            int withdrawAmountTwenties = (int)(totalTransacted / TWENTY);  // Determine how many $20 bills
            totalTransacted %= TWENTY;  // Update withdrawAmount to remainder after $20 bills
            Console.WriteLine("\t" + withdrawAmountTwenties + "  x \t$20.00\t\t" + (withdrawAmountTwenties * TWENTY).ToString("C"));

            // Withdraw $10 bills
            int withdrawAmountTens = (int)(totalTransacted / TEN);  // Determine how many $20 bills
            totalTransacted %= TEN;  // Update withdrawAmount to remainder after $10 bills
            Console.WriteLine("\t" + withdrawAmountTens + "  x \t$10.00\t\t" + (withdrawAmountTens * TEN).ToString("C"));

            // Withdraw $5 bills
            int withdrawAmountFives = (int)(totalTransacted / FIVE);  // Determine how many $20 bills
            totalTransacted %= FIVE;  // Update withdrawAmount to remainder after $10 bills
            Console.WriteLine("\t" + withdrawAmountFives + "  x \t$10.00\t\t" + (withdrawAmountFives * FIVE).ToString("C"));

            // Withdraw $1 bills
            int withdrawAmountOnes = (int)(totalTransacted / ONE);  // Determine how many $1 bills
            totalTransacted %= ONE;  // Update withdrawAmount to remainder after $1 bills
            Console.WriteLine("\t" + withdrawAmountOnes + "  x \t$1.00\t\t" + (withdrawAmountOnes * ONE).ToString("C"));

            // Withdraw quarters
            int withdrawAmountQuarters = (int)(totalTransacted / QUARTER);  // Determine how many $0.10 dimes
            totalTransacted %= QUARTER;  // Update withdrawAmount to remainder after $0.10 dimes
            Console.WriteLine("\t" + withdrawAmountQuarters + "  x \t$0.25\t\t" + (withdrawAmountQuarters * QUARTER).ToString("C"));

            // Withdraw dimes
            int withdrawAmountDimes = (int)(totalTransacted / DIME);  // Determine how many $0.10 dimes
            totalTransacted %= DIME;  // Update withdrawAmount to remainder after $0.10 dimes
            Console.WriteLine("\t" + withdrawAmountDimes + "  x \t$0.10\t\t" + (withdrawAmountDimes * DIME).ToString("C"));

            // Withdraw nickels
            int withdrawAmountNickels = (int)(totalTransacted / NICKEL);  // Determine how many $0.10 dimes
            totalTransacted %= NICKEL;  // Update withdrawAmount to remainder after $0.10 dimes
            Console.WriteLine("\t" + withdrawAmountNickels + "  x \t$0.10\t\t" + (withdrawAmountNickels * NICKEL).ToString("C"));

            // Withdraw pennies
            int withdrawAmountPennied = (int)(totalTransacted / PENNY);  // Determine how many $0.01 pennies
            totalTransacted %= PENNY;  // Update withdrawAmount to remainder after pennies
            Console.WriteLine("\t" + withdrawAmountPennied + "  x \t$0.01\t\t" + (withdrawAmountPennied * PENNY).ToString("C"));

            Console.WriteLine(" ");
            Console.WriteLine("\n\n\tTotal Transacted:\t\t" + (runningDeposit + runningWitdrawal).ToString("C"));
            Console.WriteLine("\tTotal Deposited:\t\t" + runningDeposit.ToString("C"));
            Console.WriteLine("\tTotal Withdrawn:\t\t" + runningWitdrawal.ToString("C"));


            // ends the program after the breakdown
            continueProgram = false;
        }
        else
        {
            Console.WriteLine("\nThank you for visiting Clickety Clank Bank!\n\n");
            Console.WriteLine("\n--Current Balance--\n");
            Console.WriteLine("Personal Account Balance:\t" + originalBalance.ToString("C"));

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("\t --All Transaction Report -- ");
            Console.WriteLine(" ");

            Console.WriteLine("There were no transactions for the day.");
            Environment.Exit(0);
        }
        
    }
    else
    {
        Console.WriteLine(" ");

        Console.WriteLine("ERROR: Invalid choice. Please try again.");
    }
}
