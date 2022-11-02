using System;
using System.ComponentModel.DataAnnotations;

namespace Interview.Api.Dtos
{
    public class TransactionDto
    {
        [Required]
        [RegularExpression(@"^07.+", ErrorMessage = "Number should start with 07###")]
        public string? PhoneNumber { get; set; }

        [Required, Range(5000, 5000000)]
        public int Amount { get; set; }

        [Required, RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Name should only contain letters"), MinLength(5, ErrorMessage = "Name should at least be 5 characters long")]
        public string? Name { set; get; }

        [Required, MaxLength(10, ErrorMessage = "should at least be 10 characters long")]
        public string? AccountNumber { get; set; }

    }
}

