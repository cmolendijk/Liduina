using System.ComponentModel.DataAnnotations;

namespace Liduina.DL.Models
{
    public class ConfigurationKey
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsOptional { get; set; }
        public bool IsRecurring { get; set; }
		public int ActionTypeId { get; set; }
		public ActionType ActionType { get; set; }
    }
}