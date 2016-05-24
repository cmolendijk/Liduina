using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HangoverApp.DL.Models
{
    public class SendRequest
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AidProvider")]
        public int AidProviderId { get; set; }
        public AidProvider AidProvider { get; set; }
        public Status Status { get; set; }
    }
}