using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcTutorial.Models
{
    public enum HouseType { Apartment, House, Townhouse, Unit }

    public class House
    {
        [Required]
        [Range(1, 100)]
        public int? NumberOfRooms { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"[1-9a-zA-Z- ]+ rd")]
        [MinLength(5)]
        public string Road { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string OwnerEmail { get; set; }

        [CreditCard]
        public string OwnerCreditCard { get; set; }

        [Compare("OwnerCreditCard")]
        public string ConfirmOwnerCreditCard { get; set; }

        [EnumDataType(typeof(HouseType))]
        public HouseType HouseType { get; set; }
    }
}