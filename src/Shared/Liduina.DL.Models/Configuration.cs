using System.ComponentModel.DataAnnotations.Schema;

namespace Liduina.DL.Models
{
    public class Configuration
    {
        public int Id { get; set; }

		[ForeignKey("ButtonAction")]
		public int ButtonActionId { get; set; }
        public ButtonAction ButtonAction { get; set; }
		public int ConfigurationKeyId { get; set; }
        public ConfigurationKey ConfigurationKey { get; set; }
        public string Value { get; set; }
        public short Index { get; set; }
    }
}
