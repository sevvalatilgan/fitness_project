using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Schedule
    {
        public int Id { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public int SessionId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public Member Member { get; set; }
        public Session Session { get; set; }
    }
}