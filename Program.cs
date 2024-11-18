// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

namespace Banking2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variables
            string transactionMenuChoice, mainMenuChoice, depositMenuChoice; // Menu option validation
            double depositAmt = 0.0, withAmt = 0.0, endBalance = 0.0; //States of the deposit count
            long hundreds = 0, fifties = 0, twenties = 0, tens = 0, fives = 0, ones = 0; // Dollars
            long quarters = 0, dimes = 0, nickels = 0, pennies = 0; // Change
            long totalHundreds = 0, totalFifties = 0, totalTwenties = 0, totalTens = 0, totalFives = 0, totalOnes = 0; // Dollar amount
            long totalQuarters = 0, totalDimes = 0, totalNickels = 0, totalPennies = 0; // Change amount
            long depositCount = 0, withdrawCount = 0;
            long dollarsAndCents = 0;
            double totalDep = 0.0, totalWith = 0.0, totalTransacted = 0.0;
            long generatedTransactions;
            long singleTrans = 0, totalGenTrans = 0, totalTransactions = 0;
            long singDep = 0, singWith = 0;
            long genDep = 0, genWith = 0;

            // random number generator
            Random rnd = new Random();

            // generate a balance between 1 and 5000
            double currentBalance = rnd.Next(1, 5000);

            // Constants
            const double HUNDRED = 100.00, FIFTY = 50.00, TWENTY = 20.00, TEN = 10.00, FIVE = 5.00, ONE = 1.00;
            const double QUARTER = 0.25, DIME = 0.10, NICKEL = 0.05, PENNY = 0.01;

            //transaction file
            string fileName = "transaction report.txt";

            // header
            Console.WriteLine("\n\tWelcome to Clickety Clank Bank!\n");

            do
            { // main menu
                Console.WriteLine("\t\t--Main Menu--");
                Console.WriteLine("\tChoose a from one of the following:");
                Console.WriteLine("\t\tA - Single Transaction");
                Console.WriteLine("\t\tB - Generate Multiple Transactions");
                Console.WriteLine("\t\tC - Exit \n");
                Console.WriteLine("\tEnter your choice (A, B, or C): ");
                mainMenuChoice = Console.ReadLine();

                if (mainMenuChoice == "A" || mainMenuChoice == "a")
                {
                    //single transaction
                    do
                    {
                        // Display menu
                        Console.WriteLine("\n\t--Single Transaction Menu--");

                        // Display current balance
                        Console.WriteLine("\tYour current account balance is: {0} \n", currentBalance.ToString("c"));

                        // Checks for balance
                        if (currentBalance > 5.00)
                        {
                            Console.Write("\tWhat would you like to do today?\n\t\tA - Make a Deposit\n\t\tB - Make a Withdrawal\n\tEnter your choice (A or B): ");
                            transactionMenuChoice = Console.ReadLine();

                            if (transactionMenuChoice != "A" && transactionMenuChoice != "a" &&
                                transactionMenuChoice != "B" && transactionMenuChoice != "b")
                            {
                                // Error menu
                                Console.WriteLine("\n\tERROR: Invalid Main Menu Choice. Try Again.\n");
                            }
                        }
                        else
                        {
                            // Low account balance alert
                            Console.WriteLine("\n\tWARNING: LOW ACCOUNT BALANCE. PROCEED WITH A DEPOSIT.");
                            transactionMenuChoice = "A";
                        }

                    } while (transactionMenuChoice != "A" && transactionMenuChoice != "a" &&
                    transactionMenuChoice != "B" && transactionMenuChoice != "b");

                    // Valid transaction
                    if (transactionMenuChoice == "A" || transactionMenuChoice == "a")
                    {
                        // process single deposit
                        do
                        {
                            Console.Write("\nEnter your type of deposit:\n\tA - Cash Only\n\tB - Change Only\nEnter your choice (A or B): ");
                            depositMenuChoice = Console.ReadLine();

                            if (depositMenuChoice != "A" && depositMenuChoice != "a" &&
                                depositMenuChoice != "B" && depositMenuChoice != "b")
                            {
                                //error menu
                                Console.WriteLine("\n\tERROR: Invalid Deposit Menu Choice. Try Again.\n");
                            }
                        } while (depositMenuChoice != "A" && depositMenuChoice != "a" &&
                        depositMenuChoice != "B" && depositMenuChoice != "b");

                        if (transactionMenuChoice == "A" || transactionMenuChoice == "a")
                        {
                            //Cash deposit
                            do
                            {
                                //get + validate hundreds
                                Console.WriteLine("\n\tEnter the number of hundreds (min: 0, max 100): ");
                                hundreds = Convert.ToInt64(Console.ReadLine());

                                if (hundreds < 0 || hundreds > 100)
                                    Console.WriteLine("\n\tERROR: INVALID NUMBER OF HUNDREDS ENTERED. Try Again.");

                            } while (hundreds < 0 || hundreds > 100);

                            do
                            {
                                //get + validate hundreds
                                Console.WriteLine("\n\tEnter the number of twenties (min: 0, max 100): ");
                                twenties = Convert.ToInt64(Console.ReadLine());

                                if (twenties < 0 || twenties > 100)
                                    Console.WriteLine("\n\tERROR: INVALID NUMBER OF TWENTIES ENTERED. Try Again.");

                            } while (twenties < 0 || twenties > 100);

                            do
                            {
                                //get + validate hundreds
                                Console.WriteLine("\n\tEnter the number of tens (min: 0, max 100): ");
                                tens = Convert.ToInt64(Console.ReadLine());

                                if (tens < 0 || tens > 100)
                                    Console.WriteLine("\n\tERROR: INVALID NUMBER OF TENS ENTERED. Try Again.");

                            } while (tens < 0 || tens > 100);

                            do
                            {
                                //get + validate hundreds
                                Console.WriteLine("\n\tEnter the number of fives (min: 0, max 100): ");
                                fives = Convert.ToInt64(Console.ReadLine());

                                if (fives < 0 || fives > 100)
                                    Console.WriteLine("\n\tERROR: INVALID NUMBER OF FIVES ENTERED. Try Again.");

                            } while (fives < 0 || fives > 100);

                            do
                            {
                                //get + validate hundreds
                                Console.WriteLine("\n\tEnter the number of ones (min: 0, max 100): ");
                                ones = Convert.ToInt64(Console.ReadLine());

                                if (ones < 0 || ones > 100)
                                    Console.WriteLine("\n\tERROR: INVALID NUMBER OF ONES ENTERED. Try Again.");

                            } while (ones < 0 || ones > 100);

                            // Add the deposit amounts
                            depositAmt += hundreds * HUNDRED;
                            depositAmt += fifties * FIFTY;
                            depositAmt += twenties * TWENTY;
                            depositAmt += tens * TEN;
                            depositAmt += fives * FIVE;
                            depositAmt += ones * ONE;

                            // Add on the total amt of bills tendered
                            totalHundreds += hundreds;
                            totalFifties += fifties;
                            totalTwenties += twenties;
                            totalTens += tens;
                            totalFives += fives;
                            totalOnes += ones;
                        }
                        else
                        {
                            //change deposit
                            do
                            {
                                //get + validate hundreds
                                Console.WriteLine("\n\tEnter the number of quarters (min: 0, max 100): ");
                                quarters = Convert.ToInt64(Console.ReadLine());

                                if (quarters < 0 || quarters > 100)
                                    Console.WriteLine("\n\tERROR: INVALID NUMBER OF QUARTERS ENTERED. Try Again.");

                            } while (quarters < 0 || quarters > 100);

                            do
                            {
                                //get + validate hundreds
                                Console.WriteLine("\n\tEnter the number of dimes (min: 0, max 100): ");
                                dimes = Convert.ToInt64(Console.ReadLine());

                                if (dimes < 0 || dimes > 100)
                                    Console.WriteLine("\n\tERROR: INVALID NUMBER OF DIMES ENTERED. Try Again.");

                            } while (dimes < 0 || dimes > 100);

                            do
                            {
                                //get + validate hundreds
                                Console.WriteLine("\n\tEnter the number of nickels (min: 0, max 100): ");
                                nickels = Convert.ToInt64(Console.ReadLine());

                                if (nickels < 0 || nickels > 100)
                                    Console.WriteLine("\n\tERROR: INVALID NUMBER OF NICKELS ENTERED. Try Again.");

                            } while (nickels < 0 || nickels > 100);

                            do
                            {
                                //get + validate hundreds
                                Console.WriteLine("\n\tEnter the number of pennies (min: 0, max 100): ");
                                pennies = Convert.ToInt64(Console.ReadLine());

                                if (pennies < 0 || pennies > 100)
                                    Console.WriteLine("\n\tERROR: INVALID NUMBER OF PENNIES ENTERED. Try Again.");

                            } while (pennies < 0 || pennies > 100);

                            // Add the deposit amounts
                            depositAmt += quarters * QUARTER;
                            depositAmt += dimes * DIME;
                            depositAmt += nickels * NICKEL;
                            depositAmt += pennies * PENNY;

                            // Add on the total amt of change tendered
                            totalQuarters += quarters;
                            totalDimes += dimes;
                            totalNickels += nickels;
                            totalPennies += pennies;
                        }

                        //increment single deposits
                        singDep++;
                        //add to total deposits
                        depositCount++;
                    }
                    else
                    {
                        //process withdrawal
                        do
                        {
                            //handle a withdrawal
                            Console.WriteLine("\n\tHow much would you like to withdraw from your account? " +
                                "(max: {0}) $", currentBalance.ToString("c"));
                            withAmt = Convert.ToDouble(Console.ReadLine());

                            // error message
                            if (withAmt < 0 || withAmt > currentBalance)
                                Console.WriteLine("\n\tERROR: Invalid Withdrawal AMount. Try Again.");
                        } while (withAmt < 0 || withAmt > currentBalance);

                        // Process the withdrawal and break that amt down into denominations
                        dollarsAndCents = Convert.ToInt64(withAmt * 100); // Converts entire amount into pennies

                        // Sequential + modular division to calculate amounts
                        hundreds = dollarsAndCents / 10000; // $100.00 = 10,000 pennies
                        dollarsAndCents = dollarsAndCents % 10000; // remove the hundreds
                        fifties = dollarsAndCents / 5000; // $50.00 = 5,000 pennies
                        dollarsAndCents = dollarsAndCents % 5000; //  remove the fifties
                        twenties = dollarsAndCents / 2000; // $20.00 = 2,000 pennies
                        dollarsAndCents = dollarsAndCents % 2000; //  remove the twenties
                        tens = dollarsAndCents / 1000; // $10.00 = 1,000 pennies
                        dollarsAndCents = dollarsAndCents % 1000; //  remove the tens
                        fives = dollarsAndCents / 500; // $5.00 = 500 pennies
                        dollarsAndCents = dollarsAndCents % 500; //  remove the fives
                        ones = dollarsAndCents / 100; // $1.00 = 100 pennies
                        dollarsAndCents = dollarsAndCents % 100; //  remove the ones
                        quarters = dollarsAndCents / 25; // $0.25 = 25 pennies
                        dollarsAndCents = dollarsAndCents % 25; //  remove the quarters
                        dimes = dollarsAndCents / 10; // $0.10 = 10 pennies
                        dollarsAndCents = dollarsAndCents % 10; //  remove the dimes
                        nickels = dollarsAndCents / 5; // $0.05 = 5 pennies
                        pennies = dollarsAndCents / 5; // remove the nickels to get the leftover pennies

                        // Add on the total amt of bills tendered
                        totalHundreds += hundreds;
                        totalFifties += fifties;
                        totalTwenties += twenties;
                        totalTens += tens;
                        totalFives += fives;
                        totalOnes += ones;

                        // Add on the total amt of change tendered
                        totalQuarters += quarters;
                        totalDimes += dimes;
                        totalNickels += nickels;
                        totalPennies += pennies;

                        // add onto single withdrawals
                        singWith++;
                        // add onto total withdrawals
                        withdrawCount++;
                    }

                    Console.WriteLine("\n\n------Transaction Reciept------");
                    Console.WriteLine("\t\tStarting Balance: \t {0}", currentBalance.ToString("c"));
                    if (transactionMenuChoice == "A" || transactionMenuChoice == "a")
                    {
                        Console.WriteLine("\t\tDeposit Amount: \t {0}", depositAmt.ToString("c"));
                        if (depositAmt > 0)
                        {
                            Console.WriteLine("\n\t\t   Deposit Breakdown ");
                            Console.WriteLine("\n\t\t      Count\t Amount");
                            endBalance = currentBalance + depositAmt;
                            // update current balance
                            currentBalance = endBalance;

                            // add to total deposited
                            totalDep += depositAmt;

                            // add onto total transacted
                            totalTransacted += depositAmt;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\t\tWithdrawal Amount: \t {0}", withAmt.ToString("c"));

                        if (withAmt > 0)
                        {
                            Console.WriteLine("\n\t\t   Withdrawal Breakdown ");
                            Console.WriteLine("\n\t\t      Count\t Amount");
                            endBalance = currentBalance - withAmt;
                            //update current balance
                            currentBalance = endBalance;

                            // add to total deposited
                            totalWith += withAmt;

                            // add onto total transacted
                            totalTransacted += withAmt;
                        }
                    }
                    // display transaction breakdown
                    if (hundreds > 0)
                        Console.WriteLine("\t\t    {0} x {1}\t {2} ", hundreds,
                            HUNDRED.ToString("c"), (hundreds * HUNDRED).ToString("c"));
                    if (fifties > 0)
                        Console.WriteLine("\t\t    {0} x {1}\t {2} ", fifties,
                            FIFTY.ToString("c"), (fifties * FIFTY).ToString("c"));
                    if (twenties > 0)
                        Console.WriteLine("\t\t    {0} x {1}\t {2} ", twenties,
                            TWENTY.ToString("c"), (twenties * TWENTY).ToString("c"));
                    if (tens > 0)
                        Console.WriteLine("\t\t    {0} x {1}\t {2} ", tens,
                            TEN.ToString("c"), (tens * TEN).ToString("c"));
                    if (fives > 0)
                        Console.WriteLine("\t\t    {0} x {1}\t {2} ", fives,
                            FIVE.ToString("c"), (fives * FIVE).ToString("c"));
                    if (ones > 0)
                        Console.WriteLine("\t\t    {0} x {1}\t {2} ", ones,
                            ONE.ToString("c"), (ones * ONE).ToString("c"));
                    if (quarters > 0)
                        Console.WriteLine("\t\t    {0} x {1}\t {2} ", quarters,
                            QUARTER.ToString("c"), (quarters * QUARTER).ToString("c"));
                    if (dimes > 0)
                        Console.WriteLine("\t\t    {0} x {1}\t {2} ", dimes,
                            DIME.ToString("c"), (dimes * DIME).ToString("c"));
                    if (nickels > 0)
                        Console.WriteLine("\t\t    {0} x {1}\t {2} ", nickels,
                            NICKEL.ToString("c"), (nickels * NICKEL).ToString("c"));
                    if (pennies > 0)
                        Console.WriteLine("\t\t    {0} x {1}\t {2} ", pennies,
                            PENNY.ToString("c"), (pennies * PENNY).ToString("c"));

                    Console.WriteLine("\n\t\tEnding Balance: \t {0}", endBalance.ToString("c"));

                    // add onto single transactions
                    singleTrans++;
                    //add to total transactions
                    totalTransactions++;

                    //reset deposit and withdrawal amts
                    depositAmt = 0.0;
                    withAmt = 0.0;

                    //reset currency amts
                    hundreds = 0;
                    fifties = 0;
                    twenties = 0;
                    tens = 0;
                    fives = 0;
                    ones = 0;
                    quarters = 0;
                    dimes = 0;
                    nickels = 0;
                    pennies = 0;

                    Console.WriteLine();
                }
                else if (mainMenuChoice == "B" || mainMenuChoice == "b")
                {
                    // multiple transactions
                    do
                    {
                        // get + validate number of generated transactions
                        Console.Write("\n\tHow many transactions would you like to generate? (min: 1, max: 10) ");
                        generatedTransactions = Convert.ToInt64(Console.ReadLine());

                        if (generatedTransactions < 0 || generatedTransactions > 10)
                            Console.WriteLine("\tINVALID NUMBER OF TRANSACTIONS. Try Again.");

                    } while (generatedTransactions < 0 || generatedTransactions > 10);

                    //generate + process transactions
                    for (int i = 0; i < generatedTransactions; i++)
                    {
                        // transaction header
                        Console.WriteLine("\n\n\t ------Transaction #{0} Reciept------", (i + 1));

                        //generate transaction type
                        if (Convert.ToInt64(rnd.Next(0, 2)) == 1)
                        {
                            //deposit
                            depositAmt = 0;

                            //generate type
                            if (Convert.ToInt64(rnd.Next(0, 2)) == 1)
                            {
                                // cash only deposit
                                hundreds = Convert.ToInt64(rnd.Next(0, 100));
                                fifties = Convert.ToInt64(rnd.Next(0, 100));
                                twenties = Convert.ToInt64(rnd.Next(0, 100));
                                tens = Convert.ToInt64(rnd.Next(0, 100));
                                fives = Convert.ToInt64(rnd.Next(0, 100));
                                ones = Convert.ToInt64(rnd.Next(0, 100));

                                // add deposit amounts
                                depositAmt += hundreds * HUNDRED;
                                depositAmt += fifties * FIFTY;
                                depositAmt += twenties * TWENTY;
                                depositAmt += tens * TEN;
                                depositAmt += fives * FIVE;
                                depositAmt += ones * ONE;

                                //add onto total # of bills tendered
                                totalHundreds += hundreds;
                                totalFifties += fifties;
                                totalTwenties += twenties;
                                totalTens += tens;
                                totalFives += fives;
                                totalOnes += ones;
                            }
                            else
                            {
                                // change only deposit
                                quarters = Convert.ToInt64(rnd.Next(0, 100));
                                dimes = Convert.ToInt64(rnd.Next(0, 100));
                                nickels = Convert.ToInt64(rnd.Next(0, 100));
                                pennies = Convert.ToInt64(rnd.Next(0, 100));

                                // add deposit amounts
                                depositAmt += quarters * QUARTER;
                                depositAmt += dimes * DIME;
                                depositAmt += nickels * NICKEL;
                                depositAmt += pennies * PENNY;

                                //add onto total # of bills tendered
                                totalQuarters += quarters;
                                totalDimes += dimes;
                                totalNickels += nickels;
                                totalPennies += pennies;
                            }

                            // add to total amt gen deposits
                            genDep++;
                            // add to total count of deposits
                            depositCount++;

                            // add onto total dep
                            totalDep += depositAmt;
                            // add onto total trans
                            totalTransacted += depositAmt;

                            Console.WriteLine("\t\tDeposit Amount: \t {0}", depositAmt.ToString("c"));
                            if (depositAmt > 0)
                            {
                                Console.WriteLine("\n\t\t   Deposit Breakdown");
                                Console.WriteLine("\n\t\t      Count\t Amount");
                            }
                        }
                        else
                        {
                            //withdraw
                            withAmt = Convert.ToDouble(rnd.Next(0, 5000));

                            // Process the withdrawal and break that amt down into denominations
                            dollarsAndCents = Convert.ToInt64(withAmt * 100); // Converts entire amount into pennies

                            // Sequential + modular division to calculate amounts
                            hundreds = dollarsAndCents / 10000; // $100.00 = 10,000 pennies
                            dollarsAndCents = dollarsAndCents % 10000; // remove the hundreds
                            fifties = dollarsAndCents / 5000; // $50.00 = 5,000 pennies
                            dollarsAndCents = dollarsAndCents % 5000; //  remove the fifties
                            twenties = dollarsAndCents / 2000; // $20.00 = 2,000 pennies
                            dollarsAndCents = dollarsAndCents % 2000; //  remove the twenties
                            tens = dollarsAndCents / 1000; // $10.00 = 1,000 pennies
                            dollarsAndCents = dollarsAndCents % 1000; //  remove the tens
                            fives = dollarsAndCents / 500; // $5.00 = 500 pennies
                            dollarsAndCents = dollarsAndCents % 500; //  remove the fives
                            ones = dollarsAndCents / 100; // $1.00 = 100 pennies
                            dollarsAndCents = dollarsAndCents % 100; //  remove the ones
                            quarters = dollarsAndCents / 25; // $0.25 = 25 pennies
                            dollarsAndCents = dollarsAndCents % 25; //  remove the quarters
                            dimes = dollarsAndCents / 10; // $0.10 = 10 pennies
                            dollarsAndCents = dollarsAndCents % 10; //  remove the dimes
                            nickels = dollarsAndCents / 5; // $0.05 = 5 pennies
                            pennies = dollarsAndCents / 5; // remove the nickels to get the leftover pennies

                            // Add on the total amt of bills tendered
                            totalHundreds += hundreds;
                            totalFifties += fifties;
                            totalTwenties += twenties;
                            totalTens += tens;
                            totalFives += fives;
                            totalOnes += ones;

                            // Add on the total amt of change tendered
                            totalQuarters += quarters;
                            totalDimes += dimes;
                            totalNickels += nickels;
                            totalPennies += pennies;

                            // withdrawal
                            genWith++;
                            //add onto total withdrawn
                            totalWith += withAmt;
                            //add onto total transacted
                            totalTransacted += withAmt;

                            Console.WriteLine("\t\tWithdrawal Amount: \t {0}", withAmt.ToString("c"));
                            if (withAmt > 0)
                            {
                                Console.WriteLine("\n\t\t   Withdrawal Breakdown");
                                Console.WriteLine("\n\t\t      Count\t Amount");
                            }
                        }

                        //display transaction breakdown
                        if (hundreds > 0)
                            Console.WriteLine("\t\t    {0} x {1}\t {2} ", hundreds,
                                HUNDRED.ToString("c"), (hundreds * HUNDRED).ToString("c"));
                        if (fifties > 0)
                            Console.WriteLine("\t\t    {0} x {1}\t {2} ", fifties,
                                FIFTY.ToString("c"), (fifties * FIFTY).ToString("c"));
                        if (twenties > 0)
                            Console.WriteLine("\t\t    {0} x {1}\t {2} ", twenties,
                                TWENTY.ToString("c"), (twenties * TWENTY).ToString("c"));
                        if (tens > 0)
                            Console.WriteLine("\t\t    {0} x {1}\t {2} ", tens,
                                TEN.ToString("c"), (tens * TEN).ToString("c"));
                        if (fives > 0)
                            Console.WriteLine("\t\t    {0} x {1}\t {2} ", fives,
                                FIVE.ToString("c"), (fives * FIVE).ToString("c"));
                        if (ones > 0)
                            Console.WriteLine("\t\t    {0} x {1}\t {2} ", ones,
                                ONE.ToString("c"), (ones * ONE).ToString("c"));
                        if (quarters > 0)
                            Console.WriteLine("\t\t    {0} x {1}\t {2} ", quarters,
                                QUARTER.ToString("c"), (quarters * QUARTER).ToString("c"));
                        if (dimes > 0)
                            Console.WriteLine("\t\t    {0} x {1}\t {2} ", dimes,
                                DIME.ToString("c"), (dimes * DIME).ToString("c"));
                        if (nickels > 0)
                            Console.WriteLine("\t\t    {0} x {1}\t {2} ", nickels,
                                NICKEL.ToString("c"), (nickels * NICKEL).ToString("c"));
                        if (pennies > 0)
                            Console.WriteLine("\t\t    {0} x {1}\t {2} ", pennies,
                                PENNY.ToString("c"), (pennies * PENNY).ToString("c"));

                        Console.WriteLine("\n\t\tAmount Transacted: \t {0}", ((hundreds * HUNDRED) +
                            (fifties * FIFTY) + (twenties * TWENTY) + (tens * TEN) + (fives * FIVE) +
                            (ones * ONE) + (quarters * QUARTER) + (dimes * DIME) + (nickels * NICKEL) +
                            (pennies * PENNY)).ToString("c"));

                        // Add onto the total gen transactions and total transactions
                        totalGenTrans++;
                        totalTransactions++;

                        //reset the amts
                        hundreds = 0;
                        fifties = 0;
                        twenties = 0;
                        tens = 0;
                        fives = 0;
                        ones = 0;
                        quarters = 0;
                        dimes = 0;
                        nickels = 0;
                        pennies = 0;
                    }
                    // reset deposit and withdrawal amts
                    depositAmt = 0.0;
                    withAmt = 0.0;
                    Console.WriteLine();
                }
                else if (mainMenuChoice == "C" || mainMenuChoice == "c")
                {
                    // exit
                    Console.WriteLine("\n\tThank you for visiting Clickety Clank Bank!");
                }
                else
                {
                    // error message
                    Console.WriteLine("\n\tERROR: INVALID MENU CHOICE. TRY AGAIN \n");
                }
            } while (mainMenuChoice != "C" && mainMenuChoice != "c");
            // display balance + generate transaction report
            // reference file using StreamWriter
            StreamWriter sw = new StreamWriter(fileName);

            Console.WriteLine("\n\n\t--Current Balance--");
            Console.WriteLine("\tPersonal Account Balance: \t{0}", currentBalance.ToString("c"));

            sw.Write("\n\n\t--Current Balance--");
            sw.WriteLine("\tPersonal Account Balance: \t{0}", currentBalance.ToString("c"));

            // generate transaction report
            Console.WriteLine("\n\n\t\t\t--All Transaction Report--");

            sw.WriteLine("\n\n\t\t\t--All Transaction Report--");

            if (totalTransactions > 0)
            {
                // display amount of total transactions
                Console.WriteLine("\t\t# of transactions: \t\t\t{0}", totalTransactions);
                sw.WriteLine("\t\t# of transactions: \t\t\t{0}", totalTransactions);

                if (singleTrans > 0)
                {
                    Console.WriteLine("\n\t\t# of single transactions: \t\t{0}", singleTrans);
                    sw.WriteLine("\n\t\t# of single transactions: \t\t{0}", singleTrans);
                    if (singDep > 0)
                    {
                        Console.WriteLine("\t\t\t# of single deposits: \t\t{0}", singDep);
                        sw.WriteLine("\t\t\t# of single deposits: \t\t{0}", singDep);
                    }
                    if (singWith > 0)
                    {
                        Console.WriteLine("\t\t\t# of single withdrawals: \t{0}", singWith);
                        sw.WriteLine("\t\t\t# of single withdrawals: \t{0}", singWith);
                    }
                }
                if (totalGenTrans > 0)
                {
                    Console.WriteLine("\n\t\t# of generated transactions: \t\t{0}", totalGenTrans);
                    sw.WriteLine("\n\t\t# of generated transactions: \t\t{0}", totalGenTrans);
                    if (genDep > 0)
                    {
                        Console.WriteLine("\t\t\t# of generated deposits: \t{0}", genDep);
                        sw.WriteLine("\t\t\t# of generated deposits: \t{0}", genDep);
                    }
                    if (genWith > 0)
                    {
                        Console.WriteLine("\t\t\t# of generated withdrawals: \t{0}", genWith);
                        sw.WriteLine("\t\t\t# of generated withdrawals: \t{0}", genWith);
                    }
                }

                Console.WriteLine();
                sw.WriteLine();
                if (depositCount > 0)
                {
                    Console.WriteLine("\t\t\t# of deposits: \t{0}", depositCount);
                    sw.WriteLine("\t\t\t# of deposits: \t{0}", depositCount);
                }
                if (genWith > 0)
                {
                    Console.WriteLine("\t\t\t# of withdrawals: \t{0}", withdrawCount);
                    sw.WriteLine("\t\t\t# of withdrawals: \t{0}", withdrawCount);
                }

                Console.WriteLine("\n\t\tTotal Dollar Bills and Change Tendered: \n");
                Console.WriteLine("\n\t\t       Count\t\t Amount");

                sw.WriteLine("\n\t\tTotal Dollar Bills and Change Tendered: \n");
                sw.WriteLine("\n\t\t       Count\t\t Amount");

                if (totalHundreds > 0)
                {
                    if (totalHundreds > 90)
                    {
                        Console.WriteLine("\t\t    {0} x {1}\t {2} ", totalHundreds,
                                HUNDRED.ToString("c"), (totalHundreds * HUNDRED).ToString("c"));
                        sw.WriteLine("\t\t    {0} x {1}\t {2} ", totalHundreds,
                                HUNDRED.ToString("c"), (totalHundreds * HUNDRED).ToString("c"));
                    }
                    else
                    {
                        Console.WriteLine("\t\t    {0} x {1}\t {2} ", totalHundreds,
                                HUNDRED.ToString("c"), (totalHundreds * HUNDRED).ToString("c"));
                        sw.WriteLine("\t\t    {0} x {1}\t {2} ", totalHundreds,
                                HUNDRED.ToString("c"), (totalHundreds * HUNDRED).ToString("c"));
                    }
                }
                if (totalFifties > 0)
                {

                    Console.WriteLine("\t\t    {0} x {1}\t {2} ", totalFifties,
                            FIFTY.ToString("c"), (totalFifties * FIFTY).ToString("c"));
                    sw.WriteLine("\t\t    {0} x {1}\t {2} ", totalFifties,
                            FIFTY.ToString("c"), (totalFifties * FIFTY).ToString("c"));
                }
                if (totalTwenties > 0)
                {

                    Console.WriteLine("\t\t    {0} x {1}\t {2} ", totalTwenties,
                            TWENTY.ToString("c"), (totalTwenties * TWENTY).ToString("c"));
                    sw.WriteLine("\t\t    {0} x {1}\t {2} ", totalTwenties,
                            TWENTY.ToString("c"), (totalTwenties * TWENTY).ToString("c"));
                }
                if (totalTens > 0)
                {

                    Console.WriteLine("\t\t    {0} x {1}\t {2} ", totalTens,
                            TEN.ToString("c"), (totalTens * TEN).ToString("c"));
                    sw.WriteLine("\t\t    {0} x {1}\t {2} ", totalTens,
                            TEN.ToString("c"), (totalTens * TEN).ToString("c"));
                }
                if (totalFives > 0)
                {

                    Console.WriteLine("\t\t    {0} x {1}\t {2} ", totalFives,
                            FIVE.ToString("c"), (totalFives * FIVE).ToString("c"));
                    sw.WriteLine("\t\t    {0} x {1}\t {2} ", totalFives,
                            FIVE.ToString("c"), (totalFives * FIVE).ToString("c"));
                }
                if (totalOnes > 0)
                {

                    Console.WriteLine("\t\t    {0} x {1}\t {2} ", totalOnes,
                            ONE.ToString("c"), (totalOnes * ONE).ToString("c"));
                    sw.WriteLine("\t\t    {0} x {1}\t {2} ", totalOnes,
                            ONE.ToString("c"), (totalOnes * ONE).ToString("c"));
                }
                if (totalQuarters > 0)
                {

                    Console.WriteLine("\t\t    {0} x {1}\t {2} ", totalQuarters,
                            QUARTER.ToString("c"), (totalQuarters * QUARTER).ToString("c"));
                    sw.WriteLine("\t\t    {0} x {1}\t {2} ", totalQuarters,
                            QUARTER.ToString("c"), (totalQuarters * QUARTER).ToString("c"));
                }
                if (totalDimes > 0)
                {

                    Console.WriteLine("\t\t    {0} x {1}\t {2} ", totalDimes,
                            DIME.ToString("c"), (totalDimes * DIME).ToString("c"));
                    sw.WriteLine("\t\t    {0} x {1}\t {2} ", totalDimes,
                            DIME.ToString("c"), (totalDimes * DIME).ToString("c"));
                }
                if (totalNickels > 0)
                {

                    Console.WriteLine("\t\t    {0} x {1}\t {2} ", totalNickels,
                            NICKEL.ToString("c"), (totalNickels * NICKEL).ToString("c"));
                    sw.WriteLine("\t\t    {0} x {1}\t {2} ", totalNickels,
                            NICKEL.ToString("c"), (totalNickels * NICKEL).ToString("c"));
                }
                if (totalPennies > 0)
                {

                    Console.WriteLine("\t\t    {0} x {1}\t {2} ", totalPennies,
                            PENNY.ToString("c"), (totalPennies * PENNY).ToString("c"));
                    sw.WriteLine("\t\t    {0} x {1}\t {2} ", totalPennies,
                            PENNY.ToString("c"), (totalPennies * PENNY).ToString("c"));
                }

                Console.WriteLine("\n\t\tTotal Transacted: \t{0}", totalTransacted.ToString("c"));
                Console.WriteLine("\t\tTotal Deposited: \t{0}", totalDep.ToString("c"));
                Console.WriteLine("\t\tTotal Withdrawn: \t{0}", totalWith.ToString("c"));

                sw.WriteLine("\n\t\tTotal Transacted: \t{0}", totalTransacted.ToString("c"));
                sw.WriteLine("\t\tTotal Deposited: \t{0}", totalDep.ToString("c"));
                sw.WriteLine("\t\tTotal Withdrawn: \t{0}", totalWith.ToString("c"));
            }
            else
            {
                // no transactions for the day
                Console.WriteLine("\n\tThere were no transactions for the day. \n");
                sw.WriteLine("\n\tThere were no transactions for the day. \n");
            }
            sw.Close(); //close and save file
        }
    }
}