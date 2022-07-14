using System.ComponentModel.DataAnnotations;

namespace HRManagementv2.Models
{
    public class InterviewInf
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
        public string? ApplicationStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FoundFrom { get; set; }

    }
}
