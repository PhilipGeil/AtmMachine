using AtmMachine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AtmMachine.Tests
{
    public class TransactionHandlerTests
    {
        TransactionHandler t = new TransactionHandler();


        [Theory]
        [InlineData(200, 10000)]
        [InlineData(200, 100)]
        public void WithdrawMoney(int amount, int availableAmount)
        {
            Account account = new Account()
            {
                AccountNumber = availableAmount
            };

            if (amount < account.AvailableAmount)
            {
                Assert.True(t.WithdrawMoney(amount, account));
            } else
            {
                Assert.Throws<TransactionException>(() => t.WithdrawMoney(amount, account));
            }
        }
    }
}
