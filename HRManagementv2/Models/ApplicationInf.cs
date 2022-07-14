using System.ComponentModel.DataAnnotations;

namespace HRManagementv2.Models
{
    public class ApplicationInf
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }

    }
}
