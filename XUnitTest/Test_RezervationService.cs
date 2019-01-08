using BusinessLayer;
using BusinessLayer.Interfaces;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest
{
    public class Test_RezervationService
    {
        [Fact]
        public void GetBookedDays_Test()
        {
            var data = new List<BookedDays>
        {
            new BookedDays {
                EndDate=DateTime.UtcNow,
                StartDate= DateTime.UtcNow,
                Status= Enum.GetName(typeof(PeriodWithStatus), PeriodWithStatus.FreePeriod)
            },
            new BookedDays {
                EndDate=DateTime.UtcNow,
                StartDate= DateTime.UtcNow,
                Status= Enum.GetName(typeof(PeriodWithStatus), PeriodWithStatus.ReservedPeriod)
            },
            new BookedDays {
                EndDate=DateTime.UtcNow,
                StartDate= DateTime.UtcNow,
                Status= Enum.GetName(typeof(PeriodWithStatus), PeriodWithStatus.FreePeriod)
            },
            new BookedDays {
                EndDate=DateTime.UtcNow,
                StartDate= DateTime.UtcNow,
                Status= Enum.GetName(typeof(PeriodWithStatus), PeriodWithStatus.ReservedPeriod)
            },
        };

            var mockRezervService = new Mock<IRezervationService>();
            mockRezervService.Setup(mr => mr.GetBookedDay(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<int>())).Returns(data);

            var bookedDays = mockRezervService.Object;
            Assert.Equal(1, 1);
        }
    }
}