using AtmMachine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AtmMachine.Tests
{
    public class ValidatorTests
    {
        Validator v = new Validator();
        /// <summary>
        /// Validates the inputted card - Checks if the cardtype is supported by this ATM. <br></br>
        /// Supported card types are:
        /// <list type="bullet">
        /// <item>Mastercard</item>
        /// <item>Dankort</item>
        /// <item>Visa</item>
        /// </list>
        /// </summary>
        /// <param name="cardType"></param>
        [Theory]
        [InlineData("Mastercard")]
        [InlineData("Dankort")]
        [InlineData("Coop kort")]
        public void ValidateInputtedCard(string cardType)
        {
            // Create test card for testing purpose
            Card card = new Card()
            {
                Cardtype = cardType
            };
            if (card.Cardtype != "Mastercard" && card.Cardtype != "Dankort" && card.Cardtype != "Visa")
            {
                Assert.Throws<CardException>(() => v.ValidateInputtedCard(card));
            }
            else
            {
                Assert.True(v.ValidateInputtedCard(card));
            }
        }


        /// <summary>
        /// Validates the inputted pincode <br></br>
        /// <list type="number">
        /// <item>Checks if it consists of 4 digits</item>
        /// <item>Checks if it matches the pincode of the inserted card</item>
        /// </list>
        /// </summary>
        /// <param name="pincode"></param>
        [Theory]
        [InlineData(1234)]
        [InlineData(123)]
        [InlineData(1235)]
        public void ValidatePincodeInput(int pincode)
        {
            // Create a test card for testing purpose
            Card card = new Card()
            {
                Pincode = 1234
            };
            // Check if the pincode consists of 4 digits
            if (pincode.ToString().Length != 4)
            {
                Assert.Throws<PincodeException>(() => v.ValidatePincodeInput(pincode, card));
            }
            else if (card.Pincode != pincode)
            {
                Assert.Throws<PincodeException>(() => v.ValidatePincodeInput(pincode, card));
            }
            else
            {
                Assert.True(v.ValidatePincodeInput(pincode, card));
            }
        }

        /// <summary>
        /// Checks the requested withdraw amount <br></br>
        /// Checks the following scenarios: <br></br>
        /// <list type="bullet">
        /// <item>Amount being lower than the available amount</item>
        /// <item>Amount being between the ATM limits (50 - 15000)</item>
        /// </list>
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="availableAmount"></param>
        [Theory]
        [InlineData(1500, 10000)]
        [InlineData(15000, 10000)]
        [InlineData(150000, 1000000)]
        [InlineData(15, 10000)]
        public void ValidateWithdrawAmount(int amount, int availableAmount)
        {
            Account account = new Account()
            {
                AvailableAmount = availableAmount
            };
            // Check if the amount is greater than the available amount - Should result in a AccountException
            if (amount > account.AvailableAmount)
            {
                Assert.Throws<AccountException>(() => v.ValidateWithdrawAmount(amount, account));
            }
            // Check if amount is above or belove ATM limits - should result in a AccountException
            else if (amount < 50 || amount > 15000)
            {
                Assert.Throws<AccountException>(() => v.ValidateWithdrawAmount(amount, account));
            }
            // Everything checks out, and it should result in true.
            else
            {
                Assert.True(v.ValidateWithdrawAmount(amount, account));
            }
            
        }
    }
}
