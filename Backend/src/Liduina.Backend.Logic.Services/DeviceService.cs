using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Liduina.Backend.Data.Repositories;
using Liduina.Backend.Logic.Models;

namespace Liduina.Backend.Logic.Services
{
    public class DeviceService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeviceService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeviceModel> GetDevice(string identifier)
        {
            var device = await _unitOfWork.DeviceRepository.Find(d => d.Identifier.Equals(identifier));

            if (device == null)
                return null;

            return _mapper.Map<DeviceModel>(device);
        }
    }
}
