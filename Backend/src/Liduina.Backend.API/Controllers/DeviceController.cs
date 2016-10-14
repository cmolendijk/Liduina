using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liduina.Backend.Logic.Models;
using Liduina.Backend.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Liduina.Backend.API.Controllers
{
    [Route("api/[controller]")]
    public class DeviceController : Controller
    {
        private readonly DeviceService _deviceService;

        public DeviceController(DeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<DeviceModel> Get(string identifier)
        {
            return await _deviceService.GetDevice(identifier);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
