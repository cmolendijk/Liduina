using System.ComponentModel.DataAnnotations;

namespace Liduina.DL.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string IconUri { get; set; }
    }
}