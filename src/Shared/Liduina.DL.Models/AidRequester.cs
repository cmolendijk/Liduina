using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Liduina.DL.Models.Profile;

namespace Liduina.DL.Models
{
    public class AidRequester
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
