using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodRescueManagementSystem.Entities.Group5.Models
{
    [Table("rescue_requests")]
    public class RescueRequest
    {
        [Key]
        public int RequestId { get; set; }

        public int? CitizenId { get; set; }

        public string? Description { get; set; }

        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        [MaxLength(255)]
        public string? AddressText { get; set; }

        [MaxLength(50)]
        public string Priority { get; set; } = "MEDIUM";

        [MaxLength(50)]
        public string Status { get; set; } = "PENDING";

        public int? VerifierId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ResolvedAt { get; set; }

        // Navigation
        [ForeignKey(nameof(CitizenId))]
        public UserAccount? Citizen { get; set; }

        [ForeignKey(nameof(VerifierId))]
        public UserAccount? Verifier { get; set; }
    }
}
