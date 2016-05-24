using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HangoverApp.DL.Models
{
    public class AidOffer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [ForeignKey("AidProvider")]
        public int AidProviderId { get; set; }
        public AidProvider AidProvider { get; set; }
        public short Frequency { get; set; }
        public short ActionsLeftThisMonth { get; set; }
        public short MaxTravelDistance { get; set; }
        public Calendar Availability { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
