using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Liduina.DL.Models
{
    public class ActionType
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public ICollection<ConfigurationKey> ConfigurationKeys { get; set; }
        [MaxLength(250)]
        public string IconUri { get; set; }
    }
}