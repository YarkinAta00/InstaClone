using System.ComponentModel.DataAnnotations;

namespace HRManagementv2.Models
{
    public class User
    {
        
        public int UserId { get; set; } = 0;
        [StringLength(50)]
        [Required(ErrorMessage ="Kullanıcı İsmi zorunludur.")]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        [Required(ErrorMessage ="Kullanıcı Soyadı zorunludur.")]
        public string LastName { get; set; } = null!;
        [StringLength(50)]
        [Required(ErrorMessage ="E-posta adresi girmek zorunludur.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi giriniz.")]
        public string Email { get; set; } = null!;
        [StringLength(50)]
        [Required(ErrorMessage = "Şifre girmek zorunludur.")]
        [MinLength(8,ErrorMessage = "Şifre en az 8 karakter olmalıdır.")]

        public string Password { get; set; }
        public byte? WrongPass { get; set; } = 0;  
        public bool AccountStatus { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<Candidate>? Candidates { get; set; }

    }
}
