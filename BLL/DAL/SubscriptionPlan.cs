using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        [StringLength(50)]
        public string PlanName { get; set; } // Örn: Aylık, Yıllık, Premium

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Member Member { get; set; }
    }
}