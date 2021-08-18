using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmMachine.Exceptions
{
    public class CardException : Exception
    {
        public CardException()
        {
        }

        public CardException(string message) : base(message)
        {
        }

        public CardException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
