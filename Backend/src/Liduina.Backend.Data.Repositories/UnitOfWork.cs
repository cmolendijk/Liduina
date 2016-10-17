using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liduina.Backend.Data.Entities;
using Liduina.Backend.Data.Providers;

namespace Liduina.Backend.Data.Repositories
{
    public class UnitOfWork
    {
        private readonly LiduinaContext _context;

        public UnitOfWork(LiduinaContext liduinaContext)
        {
            _context = liduinaContext;
        }

        private GenericRepository<Device> _deviceRepository;

        public virtual GenericRepository<Device> DeviceRepository
        {
            get
            {
                if(_deviceRepository == null)
                    _deviceRepository = new GenericRepository<Device>(_context);
                return _deviceRepository;
            }
        }
    }
}
