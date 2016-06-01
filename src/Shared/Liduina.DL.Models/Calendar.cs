using System;
using System.Collections.Generic;

namespace Liduina.DL.Models
{
    public class Calendar
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public ICollection<TimeSlot> TimeSlots { get; set; } 
    }
}