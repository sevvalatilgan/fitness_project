using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Specialization { get; set; } // Örn: Yoga, Ağırlık, Kardiyo

        public ICollection<Session> Sessions { get; set; }
    }
}