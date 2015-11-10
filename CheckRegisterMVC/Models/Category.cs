using System;

namespace CheckRegisterMVC.Models
{
    public class Category
    {
        public Category(String description, Decimal amount)
        {
            this.Description = description;
            this.Amount = amount;
        }

        public Category(int ID, String description, Decimal amount)
        {
            this.ID = ID;
            this.Description = description;
            this.Amount = amount;
        }
        public Category()
        {

        }

        public int ID { get; set; }
        public String Description { get; set; }
        public Decimal Amount { get; set; }
    }
}