using DataAccessLayer;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest
{
    public class TestHotelRepository
    {
        [Fact]
        public void CanGetAllHotels()
        {

            List<Hotel> hotels = new List<Hotel>
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
        };

            var mockHotelRepository = new Mock<HotelRepository>();

            mockHotelRepository.Setup(mr => mr.GetAll()).Returns(hotels);

            var allHotels = mockHotelRepository.Object.GetAll();


            Assert.NotEmpty(allHotels);
            Assert.Equal(3, allHotels.Count);
        }


         [Fact]
         public void CanCreateHotel()
         {
            List<Hotel> hotels = new List<Hotel>
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
        };

            var mockHotelRepository = new Mock<HotelRepository>();

            mockHotelRepository.Setup(mr => mr.GetAll()).Returns(hotels);

            int productCount = mockHotelRepository.Object.GetAll().Count;
            Assert.Equal(3, productCount);

            mockHotelRepository.Object.CreateHotel("Maidan", "2001", "Praga", 1);

            productCount = mockHotelRepository.Object.GetAll().Count;
            Assert.Equal(4, productCount); 
       
        }

    }
}
