using CheckRegisterMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CheckRegisterMVC.common
{

    //http://stackoverflow.com/questions/16100300/asp-net-mvc-custom-validation-by-dataannotation
    public class SubTotalAttribute : ValidationAttribute
    {
        public SubTotalAttribute(params string[] propertyNames)
        {
            this.PropertyNames = propertyNames;
        }

        public string[] PropertyNames { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<Category> categories = (List<Category>)value;
            //No categories, validates. Categories are not required
            if (categories == null || categories.Count == 0)
                return null;

            var properties = this.PropertyNames.Select(validationContext.ObjectType.GetProperty);
            var values = properties.Select(p => p.GetValue(validationContext.ObjectInstance, null));
            var subTotals = categories.Sum(x => x.Amount);
            Decimal amount = (Decimal)values.FirstOrDefault();

            if (subTotals != amount)
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }
            return null;
        }
    }
}