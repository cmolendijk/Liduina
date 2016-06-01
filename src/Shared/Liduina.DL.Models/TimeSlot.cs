using System;
using System.ComponentModel.DataAnnotations;

namespace Liduina.DL.Models
{
    public class TimeSlot
    {
        [Key]
        public int Id { get; set; }
        public short Day { get; set; } // 1 - 7 = ma - zo
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
    }
}