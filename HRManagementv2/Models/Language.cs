using System.ComponentModel.DataAnnotations;

namespace HRManagementv2.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        [Required]
        public int CandidateId { get; set; }
        [StringLength(20)]
        public string LanguageName { get; set; }
        public byte LanguageLevel { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
