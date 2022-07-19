using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagementv2.Models
{
    public class Media
    {
        public int MediaId { get; set; }
        public int CandidateId { get; set; }
        [DisplayName("Image Name") ]
        public string? Photo { get; set; }
        public string? Resume { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile mediaFile { get; set; }
    }
}
