﻿using DataAccessLayer;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class XUinitTests
    {
		[Fact]
        public void Test_HotelRepository()
        {


            List<Hotel> hotels = new List<Hotel>
        {
            new Hotel {
                NameHotel = "Kyiv",
                FoundationYear = "1955",
                Address = "Chernivtsi",
                IsActive ="1"
            },
            new Hotel {
                NameHotel = "Bukovina",
                FoundationYear = "1965",
                Address = "Kyiv",
                IsActive = "1"
            },
            new Hotel {
                NameHotel = "Maidan",
                FoundationYear = "2001",
                Address = "Praga",
                IsActive = "1"
            }
        };

            var mockHotelRepository = new Mock<HotelRepository>();

            mockHotelRepository.Setup(mr => mr.GetAll()).Returns(hotels);

            var allHotels = mockHotelRepository.Object.GetAll();


            Assert.NotEmpty(allHotels);
            Assert.Equal(3, allHotels.Count);

        }


    }
}


        //    [Fact]
        //    public void Test_GetMaxAge()
        //    {
        //        var serviceStub = new Mock<UsersManager>();
        //        serviceStub.Setup(x => x.GetFromDB()).Returns(
        //            new System.Collections.Generic.List<User>()
        //            {
        //                new User(){ Age = 1},
        //                new User(){ Age = 4},
        //                new User(){ Age = 3},
        //            });
        //        var oldest = serviceStub.Object.OldestUser();

        //        Assert.Equal(4, oldest);
        //    }
    

