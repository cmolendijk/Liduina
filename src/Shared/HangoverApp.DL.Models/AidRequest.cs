using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HangoverApp.DL.Models.Profile;

namespace HangoverApp.DL.Models
{
    public class AidRequest
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Time)]
        public TimeSlot StartTime { get; set; }
        [DataType(DataType.Time)]
        public TimeSlot EndTime { get; set; }
        public short RecurrenceFrequency { get; set; }
        public RecurrencePattern RecurrencePattern { get; set; } 
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public ICollection<AidProvider> AidProviders { get; set; }
        public ICollection<TimeSlot> TimeSlots { get; set; }
    }
}
