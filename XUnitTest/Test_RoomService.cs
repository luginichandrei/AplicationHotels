using BusinessLayer;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Id = 1,
                Number = 100,
                ComfortLevel = 1,
                Capability = 3,
                Price = 111,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                HotelId = 1
            };

            var mockSet = new Mock<DbSet<Room>>();

            var mockContext = new Mock<ClientDbContext>();
            mockContext.Setup(m => m.Rooms).Returns(mockSet.Object);

            var service = new RoomService(mockContext.Object);
            service.Create(data);

            mockSet.Verify(m => m.Add(It.IsAny<Room>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void GetRoomRating()
        {
            var roomRatingStub = new List<RoomRating>()
            {
                new RoomRating(){ RoomNumber= 100, HotelName= "HotHotel", Days=new DateTime() },
                new RoomRating(){ RoomNumber= 100, HotelName= "HotHotel", Days=new DateTime() },
                new RoomRating(){ RoomNumber= 100, HotelName= "HotHotel", Days=new DateTime() },
                new RoomRating(){ RoomNumber= 101, HotelName= "HotHotel", Days=new DateTime() },
                new RoomRating(){ RoomNumber= 101, HotelName= "HotHotel", Days=new DateTime() },
                new RoomRating(){ RoomNumber= 102, HotelName= "HotHotel", Days=new DateTime() }
            };
            var mockRoomService = new Mock<RoomService>(MockBehavior.Default, null) { CallBase = true };
            mockRoomService.Setup(x => x.GetHotelRooms(It.IsAny<int>())).Returns(roomRatingStub);
            var roomsRatingResult = mockRoomService.Object.GetRoomRating(new DateTime(), new DateTime(), 10);

            var trueData = new List<TopRoom>()
            {
                new TopRoom(){HotelName="HotHotel", RoomNumber=100, CountRezerve=3},
                new TopRoom(){HotelName="HotHotel", RoomNumber=101, CountRezerve=2},
                new TopRoom(){HotelName="HotHotel", RoomNumber=102, CountRezerve=1},
            };

            Assert.Equal(trueData.First(), roomsRatingResult.First());
        }
    }
}