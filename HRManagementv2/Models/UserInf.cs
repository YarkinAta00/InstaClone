using System.ComponentModel.DataAnnotations;

namespace HRManagementv2.Models
{
    public class UserInf
    {
        
        public int JobId { get; set; }
        public int ApplicationId { get; set; }
        public int CandidateId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool AccountStatus { get; set; }
        public string Photo { get; set; }


    }
}
