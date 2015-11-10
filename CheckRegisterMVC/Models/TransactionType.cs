using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckRegisterMVC.Models
{
    public class TransactionType
    {
        public TransactionType()
        {

        }

        public TransactionType(int ID, int Ordinal, String Description)
        {
            this.ID = ID;
            this.Ordinal = Ordinal;
            this.Description = Description;
        }

        public int ID { get; set; }
        public int Ordinal { get; set; }
        public String Description { get; set; }

    }
}