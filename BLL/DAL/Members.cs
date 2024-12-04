using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<SubscriptionPlan> SubscriptionPlans { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}