using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodRescueManagementSystem.Entities.Group5.Models
{
    [Table("vehicles")]
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }   // Có thể map Enum sau

        public int Capacity { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "AVAILABLE";

        public int? ManagerId { get; set; }

        public DateTime? LastMaintenanceDate { get; set; }

        // Navigation
        [ForeignKey(nameof(ManagerId))]
        public UserAccount? Manager { get; set; }
    }
}
