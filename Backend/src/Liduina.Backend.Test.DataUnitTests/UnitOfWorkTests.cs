using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liduina.Backend.Data.Repositories;
using Xunit;

namespace Liduina.Backend.Test.DataUnitTests
{
    public class UnitOfWorkTests
    {
        [Fact]
        public void Get_Device_Repository()
        {
            // Arange
            var unitOfWork = new UnitOfWork(null);

            // Act
            var repo = unitOfWork.DeviceRepository;

            // Assert
            Assert.NotNull(repo);
        }

        [Fact]
        public void Get_Single_Device_Repository()
        {
            // Arange
            var unitOfWork = new UnitOfWork(null);

            // Act
            var repo1 = unitOfWork.DeviceRepository;
            var repo2 = unitOfWork.DeviceRepository;

            // Assert
            Assert.Same(repo1, repo2);
        }
    }
}
