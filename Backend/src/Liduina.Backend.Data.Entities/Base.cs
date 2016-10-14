using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liduina.Backend.Data.Entities
{
    public class Base
    {
        public long Id { get; set; }

        public DateTime CreateOn { get; set; }

        public DateTime? LastModified { get; set; }
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted => DeletedOn.HasValue && DeletedOn.Value <= DateTime.Now;
    }
}
