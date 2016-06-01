using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Liduina.DL.Models
{
    public class Button
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(6)]
        public string Color { get; set; }
        public short TillHours { get; set; }
        public ICollection<ButtonAction> Actions { get; set; }
    }
}
