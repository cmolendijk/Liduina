using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liduina.Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Liduina.Backend.Data.Providers
{
    public class LiduinaContext : DbContext
    {
        public virtual DbSet<Device> Devices { get; set; }
    }
}
