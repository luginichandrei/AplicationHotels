using BusinessLayer;
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
        public void Test_GetRoomRating()
        {
            List<TopRoom> rooms = new List<TopRoom>() {
                
                new TopRoom
                {
                    HotelName="",
                    RoomNumber=103,
                    CountRezerve=3
                },
                new TopRoom
                {
                    HotelName="",
                    RoomNumber=101,
                    CountRezerve=2
                },
                new TopRoom
                {
                    HotelName="",
                    RoomNumber=102,
                    CountRezerve=1
                },
                new TopRoom
                {
                    HotelName="",
                    RoomNumber=104,
                    CountRezerve=4
                },
            };
            var mockRoomServise = new Mock<RoomService>();
            mockRoomServise.Setup(mr => mr.GetRoomRating(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(rooms);

            var room = mockRoomServise.Object.GetRoomRating(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>());

            Assert.Equal(rooms.OrderByDescending(x => x.CountRezerve).Take(10).ToList(), room);
        }

    }
}
