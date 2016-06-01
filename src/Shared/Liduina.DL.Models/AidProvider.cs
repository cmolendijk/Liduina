using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Liduina.DL.Models.Profile;

namespace Liduina.DL.Models
{
    public class AidProvider
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Availability")]
        public int AvailabilityId { get; set; }
        public Calendar Availability { get; set; }
        public bool IsProfessional { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<AidOffer> AidOffers { get; set; }
    }
}