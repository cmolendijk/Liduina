using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liduina.DL.Models
{
    public class SendAidRequest
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AidRequest")]
        public int AidRequestId { get; set; }
        public AidRequest AidRequest { get; set; }
        public ICollection<SendRequest> SendRequests { get; set; }
        public Status Status { get; set; }
    }
}
