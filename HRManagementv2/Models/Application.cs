using System.ComponentModel.DataAnnotations;

namespace HRManagementv2.Models
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }
        public int JobId { get; set; } 
        public int CandidateId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(20)]
        public string FoundFrom { get; set; }
    }
}
