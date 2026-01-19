using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodRescueManagementSystem.Entities.Group5.Models
{
    [Table("distribution_logs")]
    public class DistributionLog
    {
        [Key]
        public int LogId { get; set; }

        public int? MissionId { get; set; }
        public int? ItemId { get; set; }

        public int QuantityDistributed { get; set; }

        [MaxLength(255)]
        public string? RecipientLocation { get; set; }

        public DateTime DistributedAt { get; set; } = DateTime.Now;

        // Navigation
        public Mission? Mission { get; set; }
        public ReliefItem? Item { get; set; }
    }
}
