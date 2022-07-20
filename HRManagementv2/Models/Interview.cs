using System.ComponentModel.DataAnnotations;

namespace HRManagementv2.Models
{
    public class Interview
    {
        [Key]
        public int InterviewId { get; set; }
        [Required]
        public int ApplicationId { get; set; }
        [StringLength(50)]
        public string? Type { get; set; }
        [StringLength(50)]
        public string?  Participants { get; set; }
        public string? Notes { get; set; }
        public string? Assessment { get; set; }
        public DateTime InterviewDate { get; set; }
        public int SalaryExpectation { get; set; }
        [StringLength(50)]
        public string? AlternateRole { get; set; }
        public string? State { get; set; }

        public DateTime CreatedDate { get; set; } 

    }
}
