using AtmMachine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmMachine
{
    public class TransactionHandler
    {
        public TransactionHandler() { }

        public bool WithdrawMoney(int amount, Account account)
        {
            if (amount < account.AvailableAmount)
            {
                account.AvailableAmount -= amount;
            } else
            {
                throw new TransactionException("Amount can't be greater than the available amount");
            }
            return true;
        }
    }
}
