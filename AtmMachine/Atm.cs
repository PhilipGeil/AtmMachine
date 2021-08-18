using AtmMachine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmMachine
{
    public class Atm
    {
        Validator v = new Validator();
        DalManager d = new DalManager();
        TransactionHandler t = new TransactionHandler(); 
        Card card;
        Account a;
        public Atm()
        {
        }

        public void InsertCard(Card card)
        {
            try
            {
                bool ok = v.ValidateInputtedCard(card);
                if (ok)
                {
                    this.card = card;
                    return;
                }
            }
            catch (CardException)
            {
                throw;
            }
        }

        public int InputPincode(int pincode)
        {
            try
            {
                bool ok = v.ValidatePincodeInput(pincode, this.card);
                if (ok)
                {
                    a = d.GetAccount(this.card.AccountNumber);
                    return a.AvailableAmount;
                }
            }
            catch (PincodeException)
            {
                throw;
            }
            return 0;
        }

        public void MakeWithdraw(int amount)
        {
            try
            {
                bool ok = v.ValidateWithdrawAmount(amount, a);
                if (ok)
                {
                    try
                    {
                        t.WithdrawMoney(amount, a);
                    }
                    catch (AccountException)
                    {
                        throw;
                    }
                    return;
                }
            }
            catch (TransactionException)
            {
                throw;
            }
        }
    }
}
