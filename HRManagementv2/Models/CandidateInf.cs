using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagementv2.Models
{
    public class CandidateInf
    {
        [Key]
        public int CandidateId { get; set; }
        [Required(ErrorMessage = "Kullanıcı ID'sini giriniz.")]
        public int UserId { get; set; }
        [StringLength(10)]
        [Required(ErrorMessage = "Telefon numarasını giriniz.")]
        [MinLength(10, ErrorMessage = "Telefon numarasını 10 hane olarak giriniz")]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Telefon numarasını başında 0 olmadan giriniz.")]
        public string? PhoneNumber { get; set; }
        [StringLength(50)]
        public string PersonalityTest { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Adres bilgisi giriniz.")]
        public string AddressLine { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "İl bilgisi giriniz.")]
        public string City { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "İlçe bilgisi giriniz.")]
        public string? Province { get; set; }
        [StringLength(5)]
        public string? Gender { get; set; }
        [StringLength(50)]
        public string? Skills { get; set; }
        [StringLength(50)]
        public string? Hobbies { get; set; }
        public string LanguageName { get; set; }
        public byte LanguageLevel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime AppCreatedDate {get; set;}
        public string  AppStatus { get; set; }

        public string FoundFrom { get; set; }

        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Photo { get; set; }
        public string Resume { get; set; }
        

        public virtual User User { get; set; }

        public ICollection<Language> Languages { get; set; }



    }
}
