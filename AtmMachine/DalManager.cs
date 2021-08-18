using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmMachine
{
    class DalManager
    {
        // Initialize predefined cards for testing application
        public List<Card> Cards = new List<Card>();
        public List<Account> Accounts = new List<Account>();

        public DalManager()
        {
            Init();
        }

        public void Init()
        {
            JObject data = JObject.Parse(File.ReadAllText(Environment.CurrentDirectory + "/cards.json"));
            foreach (JObject obj in data["cards"])
            {
                Cards.Add(new Card(obj));
            }

            JObject a = JObject.Parse(File.ReadAllText(Environment.CurrentDirectory + "/accounts.json"));
            foreach (JObject obj in a["accounts"])
            {
                Accounts.Add(new Account(obj));
            }
        }

        public Account GetAccount(int accountNumber)
        {
            foreach (Account account in Accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }

    }
}
