using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liduina.Backend.Data.Entities;
using Liduina.Backend.Data.Repositories;
using Liduina.Backend.Logic.Helpers;
using Liduina.Backend.Logic.Services;
using Moq;
using Xunit;

namespace Liduina.Backend.Test.LogicUnitTests
{
    public class DevicesServiceTests
    {
        [Fact]
        public async Task Get_Device()
        {
            // Arrange
            var identifier = "01f3c7e693c6457e876bfcaec4b9ea53c067abde9eff4b258b45a5cae721b657";
            var repoMock = new Mock<GenericRepository<Device>>();
            repoMock.Setup(r => r.Find(d => d.Identifier.Equals(identifier))).Returns(Task.FromResult(new Device { Identifier = identifier}));
            var unitOfWorkMock = new Mock<UnitOfWork>();
            unitOfWorkMock.Setup(u => u.DeviceRepository).Returns(repoMock.Object);
            var service = new DeviceService(unitOfWorkMock.Object, AutoMapperConfiguration.GetMapper());

            // Act
            var device = await service.GetDevice(identifier);

            // Assert
            Assert.NotNull(device);
            Assert.Equal(identifier, device.Identifier);
        }
    }
}
