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
           var reservedStub = new List<RezervedDays>(){
                new RezervedDays(){ StartDate = new DateTime(2020,10,13), EndDate = new DateTime(2020,10,17) }
            };
            var mockRezervService = new Mock<RezervationService>(MockBehavior.Default, null) { CallBase = true };
            mockRezervService.Setup(x => x.GetRezervedDays(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<int>())).Returns(reservedStub);
            var bookedDays = mockRezervService.Object.GetBookedDays(new DateTime(2020,10,10), new DateTime(2020, 10, 20), 10);

            var data = new List<BookedDays>()
            {
                new BookedDays(){StartDate = new DateTime(2020,10,10), EndDate = new DateTime(2020,10,12), Status=PeriodWithStatus.FreePeriod},
                new BookedDays(){StartDate = new DateTime(2020,10,13), EndDate = new DateTime(2020,10,17), Status=PeriodWithStatus.ReservedPeriod},
                new BookedDays(){StartDate = new DateTime(2020,10,18), EndDate = new DateTime(2020,10,20), Status=PeriodWithStatus.FreePeriod}
            };

            Assert.Equal(bookedDays, data);

        }
    }
}