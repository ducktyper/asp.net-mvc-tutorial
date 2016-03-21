using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcTutorial.Models
{
    public class House
    {
        [Required]
        [Range(1, 100)]
        public int? NumberOfRooms { get; set; }
    }
}