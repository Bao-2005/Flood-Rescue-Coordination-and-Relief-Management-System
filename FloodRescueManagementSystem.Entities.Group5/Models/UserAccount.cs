using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodRescueManagementSystem.Entities.Group5.Models
{
    [Table("System.UserAccount")]
    public class UserAccount
    {
        [Key]
        public int UserAccountID { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmployeeCode { get; set; }

        public int RoleId { get; set; }

        [MaxLength(50)]
        public string? RequestCode { get; set; }

        public DateTime? CreatedDate { get; set; }

        [MaxLength(50)]
        public string? ApplicationCode { get; set; }

        [MaxLength(50)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [MaxLength(50)]
        public string? ModifiedBy { get; set; }

        public bool IsActive { get; set; }

        // Navigation
        public ICollection<RescueTeam>? LedTeams { get; set; }
    }
}
