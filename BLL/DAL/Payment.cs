using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; } // Örn: Nakit, Kredi Kartı

        public Member Member { get; set; }
    }
}