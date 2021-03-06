﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheckRegisterMVC.common;
namespace CheckRegisterMVC.Models
{
    public class Receipt
    {

        public Receipt()
        {

            this.AccountNumber = "55";
            this.TransactionDate = DateTime.Now;
            this.TransactionType = 1;
            this.StoreName = "Home depot";
            this.Amount = 25.66m;
            this.Approver = "Tom";
            //this.Categories.Add(new Category("House", 33m));
            //this.Categories.Add(new Category("entertainment", 55.5m));

        }
        
        public Receipt(String AccountNumber, DateTime TransactionDate, int TransactionType, String StoreName, Decimal Amount, List<Category> Categories, String Approver)
        {
            this.AccountNumber = AccountNumber;
            this.TransactionDate = TransactionDate;
            this.TransactionType = TransactionType;
            this.StoreName = StoreName;
            this.Amount = Amount;
            this.Categories = Categories;
            this.Approver = Approver;
            //this.Categories = new List<Category> { new Category("Room") };
        }

        public int ID { get; set; }

        [StringLength(30)]
        public String AccountNumber { get; set; }

        [Display(Name = "Transaction Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Transaction Type")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value > 1")]
        public int TransactionType { get; set; }

        [Display(Name ="Store Name")]
        [Required]
        [StringLength(30)]
        public String StoreName { get; set; }

        [Range(1,100)]//100 is not a sensible maximum, it is for validation demonstration only
        [DataType(DataType.Currency)]
        public Decimal Amount { get; set; }

        [StringLength(30)]
        public String Approver { get; set; }

        [SubTotalAttribute("Amount", ErrorMessage = "All categories must equal receipt amount")]
        public List<Category> Categories { get; set; } = new List<Category>();

     }
}