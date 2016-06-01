using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liduina.DL.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [ForeignKey("Activity")]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        [MaxLength(250)]
        public string IconUri { get; set; }
    }
}
