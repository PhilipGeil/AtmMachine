using AtmMachine.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace AtmMachine
{
    class Program
    {
        // UI only for personal testing of the system
        static DalManager d = new DalManager();
        static Atm atm = new Atm();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < d.Cards.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.");
                    Console.WriteLine(d.Cards[i].CardNumber);
                    Console.WriteLine(d.Cards[i].AccountNumber);
                    Console.WriteLine(d.Cards[i].Cardtype);
                    Console.WriteLine();
                }
                Console.WriteLine("Enter which card you wish to input: ");
                int selected = int.Parse(Console.ReadLine()) - 1;
                if (InsertCard(d.Cards[selected]))
                {
                    Console.WriteLine("Enter pincode");
                    int pincode = int.Parse(Console.ReadLine());
                    int amount = InputPincode(pincode);
                    if (amount != -1)
                    {
                        ShowAccount(amount);
                        Console.WriteLine("Enter the amount you wish to withdraw");
                        int withdraw = int.Parse(Console.ReadLine());
                        if (WithdrawMoney(withdraw))
                        {
                            Console.WriteLine("Press any key to start over...");
                            Console.ReadLine();
                        }
                    }
                }
            }
        }

        static bool InsertCard(Card card)
        {
            try
            {
                atm.InsertCard(card);
                Console.WriteLine($"{card.CardNumber} has been inserted and validated");
                return true;
            }
            catch (CardException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return false;
            }
        }

        static int InputPincode(int pincode)
        {
            try
            {
                int availableAmount = atm.InputPincode(pincode);
                Console.WriteLine("The pincode was correct");
                return availableAmount;
            }
            catch (PincodeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return -1;
            }
        }

        static bool WithdrawMoney(int amount)
        {
            try
            {
                atm.MakeWithdraw(amount);
                Console.WriteLine($"There has been made a withdraw on {amount},- DKK");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return false;
            }
        }

        static void ShowAccount(int amount)
        {
            Console.Clear();
            Console.WriteLine("Welcome!");
            Console.WriteLine($"You have {amount},- DKK on your account");
        }
    }
}
