using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodRescueManagementSystem.Entities.Group5.Models
{
    [Table("relief_items")]
    public class ReliefItem
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Unit { get; set; }

        public int StockQuantity { get; set; } = 0;

        [MaxLength(255)]
        public string? WarehouseLocation { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
