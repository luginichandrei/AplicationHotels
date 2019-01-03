using BusinessLayer;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTest
{
    public class Test_RoomService
    {
        [Fact]
        public void CanGetAllHotels()
        {
            var data = new List<Room>
        {
            new Room {
                Number = 100,
                ComfortLevel = 1,
                Capability = 3
            },
            new Room {
                Number = 100,
                ComfortLevel = 1,
                Capability = 3
            },
            new Room {
                Number = 100,
                ComfortLevel = 1,
                Capability = 3
            },
        }.AsQueryable();

            var mockSet = new Mock<DbSet<Room>>();
            mockSet.As<IQueryable<Room>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockHotelContext = new Mock<ClientDbContext>();
            mockHotelContext.Setup(mr => mr.Rooms).Returns(mockSet.Object);

            var service = new RoomService(mockHotelContext.Object);
            var hotels = service.GetAll();

            Assert.Equal(3, hotels.ToList().Count());
        }

        [Fact]
        public void CanCreateRoom()
        {
            var data = new Room
            {
                Id=1,
                Number = 100,
                ComfortLevel = 1,
                Capability = 3,
                Price=111,
                Created=DateTime.UtcNow,
                Modified= DateTime.UtcNow,
                HotelId=1
            };

            var mockSet = new Mock<DbSet<Room>>();

            var mockContext = new Mock<ClientDbContext>();
            mockContext.Setup(m => m.Rooms).Returns(mockSet.Object);

            var service = new RoomService(mockContext.Object);
            service.Create(data);

            mockSet.Verify(m => m.Add(It.IsAny<Room>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
