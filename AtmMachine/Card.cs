using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmMachine
{
    public class Card
    {
        public string CardNumber { get; set; }
        public int AccountNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SecurityNumbers { get; set; }
        public int Pincode { get; set; }
        public string Cardtype { get; set; }

        public Card() { }

        /*
         * 
      "card_number": "1234-1234-2345-2345",
      "account_number": 123456789,
      "expiration_date": "20-08-2021",
      "security_numbers": 123,
      "pincode": 1234,
      "card_type": "Mastercard"
         * */
        public Card(JObject json)
        {
            this.CardNumber = json["card_number"].ToString();
            this.AccountNumber = json["account_number"] != null ? int.Parse(json["account_number"].ToString()) : 0;
            this.Cardtype = json["card_type"].ToString();
            this.Pincode = json["pincode"] != null ? int.Parse(json["pincode"].ToString()) : 0;
        }
    }
}
