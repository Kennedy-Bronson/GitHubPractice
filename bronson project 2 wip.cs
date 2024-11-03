
Random rng = new Random();
double balance = Convert.ToDouble(rng.Next(1, 5000));

string userChoice1 = "";
string userChoice2 = ""; // holds main menu choice
string depositCase = ""; // holds how much money was deposited

// Deposit money amounts
double depositAmount;
double depositHundred;
double depositFifty;
double depositTwenty;
double depositTen;
double depositFive;
double depositOne;
double depositQuarters;
double depositDimes;
double depositNickels;
double depositPennies;

// Withdraw money amounts
double withdrawAmount;
int withdrawAmountHundreds;
int withdrawAmountTwenties;
int withdrawAmountOnes;
int withdrawAmountDimes;
int withdrawAmountPennied;
double remainingAmount;
double StartingwithdrawAmount;


//constants
const double HUNDRED = 100.00; // Constant for 100 dollars
const double FIFTY = 50.00; // Constant for 50 dollars
const double TWENTY = 20.00; // Constant for 20 dollars
const double TEN = 10.00; // Constant for 10 dollars
const double FIVE = 5.00; // Constant for 5 dollars
const double ONE = 1.00; // Constant for 1 dollar
const double QUARTER = 0.25; // Constant for 25 cents
const double NICKEL = 0.05; // Constant for 5 cents
const double DIME = 0.10; // Constant for 10 cents
const double PENNY = 0.01; // Constant for 1 cent

//Display Menu 1
Console.WriteLine("Welcome to Clickety Clank Bank!");
Console.WriteLine(" ");
Console.WriteLine("\t --Main Menu--");
Console.WriteLine("Choose a from one of the following:");
Console.WriteLine("\t A - Single Transaction");
Console.WriteLine("\t B - Generate Multiple Transactions");
Console.WriteLine("\t C - Exit");
Console.WriteLine(" ");
Console.Write("Enter your choice (A, B, or C): ");
userChoice1 = Console.ReadLine();

switch (userChoice1)
{
    case "A":
        //If A is selected:
        //display menu 2
        Console.WriteLine(" ");
        Console.WriteLine("\t --Single Transaction Menu--");
        Console.WriteLine("Your current account balance is: " + balance.ToString("c"));
        Console.WriteLine(" ");
        Console.WriteLine("What would you like to do today?");
        Console.WriteLine("\t A - Make a Deposit");
        Console.WriteLine("\t B - Make a Withdrawal");
        Console.Write("Enter your choice (A or B): ");
        userChoice2 = Console.ReadLine();


        switch (userChoice2)
        {
            case "A":
                //deposit
                Console.WriteLine(" ");
                Console.WriteLine("\t --Deposit Menu--");
                Console.WriteLine("Enter your type of deposit:");
                Console.WriteLine("\t A - Cash Only");
                Console.WriteLine("\t B - Change Only");
                Console.Write("Enter your choice (A or B): ");
                depositCase = Console.ReadLine();

                if (depositCase == "A")
                {
                    //Cash Only
                    //Input $100
                    Console.WriteLine(" ");
                    Console.Write("Enter the number of hundreds (min: 0, max: 100): ");
                    depositHundred = Convert.ToDouble(Console.ReadLine());

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

                    //calculate amount
                    depositAmount = (depositHundred * HUNDRED) + (depositFifty * FIFTY) + (depositTwenty * TWENTY) + (depositTen * TEN) + (depositFive * FIVE) + (depositOne * ONE);

                    //deposit receipt
                    Console.WriteLine(" ");
                    Console.WriteLine("------Transaction Receipt------");
                    Console.WriteLine("\t Starting Balance:\t" + (balance - depositAmount).ToString("C"));
                    Console.WriteLine("\t Deposit Amount:\t" + depositAmount.ToString("c"));
                    Console.WriteLine(" ");
                    Console.WriteLine("\t\t Deposit Breakdown");
                    Console.WriteLine(" ");
                    Console.WriteLine("\t\t Count \t\t Amount ");
                    if (depositHundred > 0 && depositHundred <= 100)
                    {
                        Console.WriteLine("\t\t" + depositHundred + " x $100.00\t" + (depositHundred * HUNDRED).ToString("C"));
                    }
                    if (depositFifty > 0 && depositFifty <= 100)
                    {
                        Console.WriteLine("\t\t" + depositFifty + " x $50.00\t" + (depositFifty * FIFTY).ToString("C"));
                    }
                    if (depositTwenty > 0 && depositTwenty <= 100)
                    {
                        Console.WriteLine("\t\t" + depositTwenty + " x $20.00\t" + (depositTwenty * TWENTY).ToString("C"));
                    }
                    if (depositTen > 0 && depositTen <= 100)
                    {
                        Console.WriteLine("\t\t" + depositTen + " x $10.00\t" + (depositTen * TEN).ToString("C"));
                    }
                    if (depositFive > 0 && depositFive <= 100)
                    {
                        Console.WriteLine("\t\t" + depositFive + " x $5.00\t" + (depositFive * FIVE).ToString("C"));
                    }
                    if (depositOne > 0 && depositOne <= 100)
                    {
                        Console.WriteLine("\t\t" + depositOne + " x $1.00\t" + (depositOne * ONE).ToString("C"));
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("\t Ending Balance: \t\t" + balance.ToString("c"));
                }
                //Change Only
                else if (depositCase == "B")
                {
                    double startingBalance = balance;

                    // Input quarters
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

                    // Calculate total deposit amount for change
                    depositAmount = (QUARTER * depositQuarters) + (DIME * depositDimes) + (NICKEL * depositNickels) + (PENNY * depositPennies);

                    Console.WriteLine(" ");
                    Console.WriteLine("------Transaction Receipt------");
                    Console.WriteLine("\t Starting Balance:\t" + (balance - depositAmount).ToString("C"));
                    Console.WriteLine("\t Deposit Amount:\t " + depositAmount.ToString("c"));
                    Console.WriteLine(" ");
                    Console.WriteLine("\t\t Deposit Breakdown");
                    Console.WriteLine(" ");
                    Console.WriteLine("\t\t Count \t\t Amount ");
                    if (depositQuarters <= 0 || depositQuarters > 100)
                    {
                        Console.Write("");
                    }
                    else
                    {
                        Console.WriteLine("\t\t" + depositQuarters + " x $0.25\t" + (QUARTER * depositQuarters).ToString("C"));
                    }
                    if (depositDimes <= 0 || depositDimes > 100)
                    {
                        Console.Write("");
                    }
                    else
                    {
                        Console.WriteLine("\t\t" + depositDimes + " x $0.10\t" + (DIME * depositDimes).ToString("C"));
                    }
                    if (depositNickels <= 0 || depositNickels > 100)
                    {
                        Console.Write("");
                    }
                    else
                    {
                        Console.WriteLine("\t\t" + depositNickels + " x $0.05\t" + (NICKEL * depositNickels).ToString("C"));
                    }
                    if (depositPennies <= 0 || depositPennies > 100)
                    {
                        Console.Write("");
                    }
                    else
                    {
                        Console.WriteLine("\t\t" + depositPennies + " x $0.01\t" + (PENNY * depositPennies).ToString("C"));
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("\t Ending Balance: \t\t" + balance.ToString("c"));
                }

                else
                {
                    depositAmount = 0;
                    Console.WriteLine("ERROR: Invalid Deposit Menu Choice. No Deposit will be processed.");

                    //deposit receipt
                    Console.WriteLine(" ");
                    Console.WriteLine("------Transaction Receipt------");
                    Console.WriteLine("\t Starting Balance:\t" + (balance - depositAmount).ToString("C"));
                    Console.WriteLine("\t Deposit Amount:\t" + depositAmount.ToString("c"));
                    Console.WriteLine(" ");
                    Console.WriteLine("\t\t Ending Balance: " + balance.ToString("c"));
                }
                break;

            case "B":

                // Withdrawal
                Console.WriteLine(" ");
                Console.Write("How much would you like to withdraw from your account? (max:" + balance.ToString("C") + ") ");
                withdrawAmount = Convert.ToDouble(Console.ReadLine());
                StartingwithdrawAmount = withdrawAmount;

                if (withdrawAmount <= 0)
                {
                    Console.WriteLine("ERROR: Invalid Withdrawal Amount. No withdrawal will be processed.");
                }
                else if (withdrawAmount > balance)
                {
                    Console.WriteLine("ERROR: Invalid Withdrawal Amount. No withdrawal will be processed.");
                }
                else
                {
                    // balance = balance - withdrawAmount;
                    Console.WriteLine("\n\n");
                    Console.WriteLine("-------Transaction Receipt-------");
                    Console.WriteLine("\t Starting Balance:\t " + balance.ToString("C"));
                    Console.WriteLine("\t Withdrawal Amount:\t " + withdrawAmount.ToString("C"));

                    Console.WriteLine(" ");
                    Console.WriteLine("\n\t" + "    Withdrawal Breakdown \n");

                    // Calculate the bills and coin
                    Console.WriteLine("\t\t" + "Count  \tAmount");
                    // remainingAmount = balance;

                    // Withdraw $100 bills
                    withdrawAmountHundreds = (int)(withdrawAmount / HUNDRED);  // Determine how many $100 bills
                    withdrawAmount %= HUNDRED;  // Update withdrawAmount to remainder after $100 bills
                    Console.WriteLine("\t\t" + withdrawAmountHundreds + "  x \t$100.00");

                    // Withdraw $20 bills
                    withdrawAmountTwenties = (int)(withdrawAmount / TWENTY);  // Determine how many $20 bills
                    withdrawAmount %= TWENTY;  // Update withdrawAmount to remainder after $20 bills
                    Console.WriteLine("\t\t" + withdrawAmountTwenties + "  x \t$20.00");

                    // Withdraw $1 bills
                    withdrawAmountOnes = (int)(withdrawAmount / ONE);  // Determine how many $1 bills
                    withdrawAmount %= ONE;  // Update withdrawAmount to remainder after $1 bills
                    Console.WriteLine("\t\t" + withdrawAmountOnes + "  x \t$1.00");

                    // Withdraw dimes
                    withdrawAmountDimes = (int)(withdrawAmount / DIME);  // Determine how many $0.10 dimes
                    withdrawAmount %= DIME;  // Update withdrawAmount to remainder after $0.10 dimes
                    Console.WriteLine("\t\t" + withdrawAmountDimes + "  x \t$0.10");

                    // Withdraw pennies
                    withdrawAmountPennied = (int)(withdrawAmount / PENNY);  // Determine how many $0.01 pennies
                    withdrawAmount %= PENNY;  // Update withdrawAmount to remainder after pennies
                    Console.WriteLine("\t\t" + withdrawAmountPennied + "  x \t$0.01");

                    // Calculate the remaining balance
                    remainingAmount = balance - StartingwithdrawAmount;
                    Console.WriteLine("\n\tRemaining Balance: " + remainingAmount.ToString("C"));
                }
                break;

            default:
                Console.WriteLine(" ");
                Console.WriteLine("ERROR: Invalid Main Menu Choice. Program will exit.");
                break;

        }
        break;
    case "B":

        break;
    case "C":
        Environment.Exit(0);
        break;
}

