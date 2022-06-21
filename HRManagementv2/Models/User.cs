using System.ComponentModel.DataAnnotations;

namespace HRManagementv2.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(50)]
        public string Email { get; set; } = null!;
        [StringLength(50)]
        public string Password { get; set; } = null!;
        public byte WrongPass { get; set; } = 0;
        public bool AccountStatus { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
