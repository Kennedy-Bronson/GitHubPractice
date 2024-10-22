// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

/*
 This source code was used to calculate how much cryptocurrency is in any number of US Dollars. 
 */

//list of decimals needed to do the conversion
using System;

decimal numberOfDollars;
string numberOfDollarsStr;

decimal bitcoinResult;
decimal ethereumResult;
decimal dogecoinResult;
decimal cardanoResult;

//define the constants
const decimal oneBitcoin = 0.00002306m; // Convert.ToDecimal(0.00002306);
const decimal oneEthereum = 0.01122814m; // Convert.ToDecimal(0.01122814);
const decimal oneDogecoin = 2.207961078m; // Convert.ToDecimal(2.207961078);
const decimal oneCardano = 0.48910811m; // Convert.ToDecimal(0.48910811);

//input message; prompts the user to enter a monetary value in USD
Console.Write("Enter the amount of money in US Dollars: ");

//remove the dollar sign from the string using the replace function
numberOfDollarsStr = Console.ReadLine();
numberOfDollarsStr = numberOfDollarsStr.Replace("$", String.Empty);

//reassigns it back to the variable after converting to decimal
numberOfDollars = Convert.ToDecimal(numberOfDollarsStr);

//convert the number of any amount of USD into bitcoin
bitcoinResult = numberOfDollars * oneBitcoin;

//convert the number of any amount of USD into ethereum
ethereumResult = numberOfDollars * oneEthereum;

//convert the number of any amount of USD into dogecoin
dogecoinResult = numberOfDollars * oneDogecoin;

//convert the number of any amount of USD into cardano
cardanoResult = numberOfDollars * oneCardano;

//output message; prints the calculations made in the process*/
Console.WriteLine(" ");
Console.WriteLine(numberOfDollars.ToString("c") + " USD equals:");
Console.WriteLine("------------------------------------------------");
Console.WriteLine("Bitcoin: \t\t" + bitcoinResult.ToString("n"));
Console.WriteLine("Ethereum Classic: \t" + ethereumResult.ToString("n"));
Console.WriteLine("Dogecoin: \t\t" + dogecoinResult.ToString("n"));
Console.WriteLine("Cardano: \t\t" + cardanoResult.ToString("n"));

