using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Liduina.DL.Models.Profile;

namespace Liduina.DL.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User User { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [MaxLength(100)]
        public string EmailAddress { get; set; }
    }
}
