using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Session
    {
        public int Id { get; set; }

        [Required]
        public int TrainerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Trainer Trainer { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}