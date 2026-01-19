using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodRescueManagementSystem.Entities.Group5.Models
{
    [Table("missions")]
    public class Mission
    {
        [Key]
        public int MissionId { get; set; }

        public int? RequestId { get; set; }
        public int? TeamId { get; set; }
        public int? VehicleId { get; set; }
        public int? AssignedBy { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.Now;
        public DateTime? CompletedAt { get; set; }

        public string? ResultReport { get; set; }

        // Navigation
        public RescueRequest? Request { get; set; }
        public RescueTeam? Team { get; set; }
        public Vehicle? Vehicle { get; set; }

        [ForeignKey(nameof(AssignedBy))]
        public UserAccount? Assigner { get; set; }
    }
}
