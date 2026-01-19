using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FloodRescueManagementSystem.Entities.Group5.Models
{
    [Table("rescue_teams")]
    public class RescueTeam
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TeamName { get; set; }

        public int? LeaderId { get; set; }

        public decimal? CurrentLatitude { get; set; }
        public decimal? CurrentLongitude { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "READY";

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation
        [ForeignKey(nameof(LeaderId))]
        public UserAccount? Leader { get; set; }
    }
}
