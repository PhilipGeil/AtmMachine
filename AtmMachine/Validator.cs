using AtmMachine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmMachine
{
    public class Validator
    {
        private readonly int PincodeLength = 4;
        private readonly int MinWithdrawAmount = 50;
        private readonly int MaxWithdrawAmount = 15000;
        private readonly List<string> AcceptedCards = new List<string>() { 
            "Mastercard",
            "Dankort",
            "Visa"
        };

        public Validator() { }
        /// <summary>
        /// Validate the inputted card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool ValidateInputtedCard(Card card)
        {
            if (!AcceptedCards.Contains(card.Cardtype))
            {
                throw new CardException("Unsupported card");
            }
            return true;
        }
        /// <summary>
        /// Validate the inputted pincode
        /// </summary>
        /// <param name="pincode"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool ValidatePincodeInput(int pincode, Card card)
        {
            if (pincode.ToString().Length != PincodeLength)
            {
                throw new PincodeException("The pincode should consist of 4 digits");
            }

            if (card.Pincode != pincode)
            {
                throw new PincodeException("The pincode is incorrect");
            }

            return true;
        }
        /// <summary>
        /// Validate the entered withdraw amount
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool ValidateWithdrawAmount(int amount, Account account)
        {
            if (amount > account.AvailableAmount)
            {
                throw new AccountException("insufficient amount");
            } else if (amount < MinWithdrawAmount || amount > MaxWithdrawAmount)
            {
                throw new AccountException("Amount out of bounce");
            }
            return true;
        }
    }
}
