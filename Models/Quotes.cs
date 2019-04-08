using System;
using System.ComponentModel.DataAnnotations;

namespace QuoteRanks.Models
{
    public class Quotes
    {
       [Required]
       [MinLength(2)]
       public string name { get; set; }

        [Required]
        [MinLength(2)]
        public string quote { get; set; }
    }
}