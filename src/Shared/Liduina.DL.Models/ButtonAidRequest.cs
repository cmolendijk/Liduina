using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liduina.DL.Models
{
    public class ButtonAidRequest
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Button")]
        public int ButtonId { get; set; }
        public Button Button { get; set; }
        [ForeignKey("AidRequest")]
        public int AidRequestId { get; set; }
        public AidRequest AidRequest { get; set; }
    }
}
