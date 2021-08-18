using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmMachine
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public int AvailableAmount { get; set; }

        public Account() { }

        public Account(JObject json)
        {
            this.AccountNumber = json["account_number"] != null ? int.Parse(json["account_number"].ToString()) : 0;
            this.AvailableAmount = json["available_amount"] != null ? int.Parse(json["available_amount"].ToString()) : 0;
        }
    }
}
