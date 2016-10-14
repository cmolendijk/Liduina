using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Liduina.Backend.Data.Entities;
using Liduina.Backend.Logic.Models;

namespace Liduina.Backend.Logic.Helpers
{
    public static class AutoMapperConfiguration
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Device, DeviceModel>();
                cfg.CreateMap<DeviceModel, Device>();
            });
            return config.CreateMapper();
        }
    }
}
