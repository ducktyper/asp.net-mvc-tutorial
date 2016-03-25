using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MvcTutorial.Models
{
    public class Product
    {
        [ProductKey]
        public string ProductKey { get; set; }
    }

    public class ProductKeyAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (
                value is string &&
                new Regex("^\\d{4}-\\d{4}-\\d{4}-\\d{4}$").IsMatch((string)value)
            );
        }
    }
}