using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HangoverApp.DL.Models
{
    public class ButtonAction
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [ForeignKey("ActionType")]
        public int ActionTypeId { get; set; }
        public ActionType ActionType { get; set; }
    }
}