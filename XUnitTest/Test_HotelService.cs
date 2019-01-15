using BusinessLayer;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTest
{
    public class TestHotelRepository
    {
        [Fact]
        public void CanGetAllHotels()
        {
            var data = new List<Hotel>
        {
            new Hotel {
                Name = "Kyiv",
                FoundationYear = 1955,
                Address = "Chernivtsi",
                IsActive =1
            },
            new Hotel {
                Name = "Bukovina",
                FoundationYear = 1965,
                Address = "Kyiv",
                IsActive = 1
            },
            new Hotel {
                Name = "Maidan",
                FoundationYear = 2001,
                Address = "Praga",
                IsActive = 1
            }
        }.AsQueryable();

            var mockSet = new Mock<DbSet<Hotel>>();
            mockSet.As<IQueryable<Hotel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockHotelContext = new Mock<ClientDbContext>();
            mockHotelContext.Setup(mr => mr.Hotels).Returns(mockSet.Object);

            var service = new HotelService(mockHotelContext.Object);
            var hotels = service.GetAll();

            Assert.Equal(3, hotels.ToList().Count());
        }

        [Fact]
        public void CanCreateHotel()
        {
            var data = new Hotel
            {
                Name = "Maidan",
                FoundationYear = 2001,
                Address = "Praga",
                IsActive = 1
            };

            var mockSet = new Mock<DbSet<Hotel>>();

            var mockContext = new Mock<ClientDbContext>();
            mockContext.Setup(m => m.Hotels).Returns(mockSet.Object);

            var service = new HotelService(mockContext.Object);
            service.Create(data);

            mockSet.Verify(m => m.Add(It.IsAny<Hotel>()), Times.Once());
        }
    }
}