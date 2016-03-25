using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MvcTutorial.Models
{
    [ManufactureYearIsFirstFourDigitsOfProductKey]
    public class Product
    {
        [ProductKey]
        public string ProductKey { get; set; }
        public int ManufactureYear { get; set; }
        [ProductNamePrefix("AA-")]
        public string ProductName { get; set; }
    }

    public class ProductKeyAttribute: ValidationAttribute
    {
        public ProductKeyAttribute()
        {
            ErrorMessage = "The field {0} must be of format xxxx-xxxx-xxxx-xxxx.";
        }

        public override bool IsValid(object value)
        {
            return (
                value is string &&
                new Regex("^\\d{4}-\\d{4}-\\d{4}-\\d{4}$").IsMatch((string)value)
            );
        }
    }

    public class ProductNamePrefixAttribute: ValidationAttribute
    {
        private string prefix;

        public ProductNamePrefixAttribute(string _prefix)
        {
            prefix = _prefix;
        }

        public override bool IsValid(object value)
        {
            return value is string && (value as string).StartsWith(prefix);
        }
    }

    public class ManufactureYearIsFirstFourDigitsOfProductKeyAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var p = value as Product;
            return p != null && p.ProductKey.Substring(0, 4) == p.ManufactureYear.ToString();
        }
    }
}