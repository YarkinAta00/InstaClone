using System.ComponentModel.DataAnnotations;

namespace HRManagementv2.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [StringLength(50)]
        public string JobTitle { get; set; } = null!;
        [StringLength(50)]
        public string Department { get; set; } = null!;
        [StringLength(50)] 
        public string Location { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public string Description { get; set; } 
        public bool IsActive { get; set; }
    }
}
