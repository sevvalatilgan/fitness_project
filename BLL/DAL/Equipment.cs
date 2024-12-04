using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, 1000)]
        public int Quantity { get; set; }
    }
}