﻿using Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{


    public class RoomService
    {
        public List<BookedDays> GetBookedDays( DateTime startTime, DateTime endTime, List<RezervedDays> rezervedDays)
        {
            var result = new List<BookedDays>();
            var sd = startTime;
            
                foreach (var rd in rezervedDays)
                {
                       result.Add(
                       new BookedDays(){
                       StartDate = sd,
                       EndDate = rd.StartDate.AddDays(-1),
                       Status = "Free period"});

                       result.Add(
                       new BookedDays() { 
                       StartDate = rd.StartDate,
                       EndDate = rd.EndDate,
                       Status = "Rezerved period"});
                sd = rd.EndDate.AddDays(1);
                }
            return result;
        }

        public List<TopRoom> GetRoomRating(DateTime startTime, DateTime endTime, List<RoomRating> rooms)
        {
            var result = new List<TopRoom>();
            foreach(var ms in rooms)
            {
                var total = 0;
                foreach(var c in ms.Days)
                {
                    var cd = (int)(c.EndDate - c.StartDate).TotalDays;
                    total += cd;
                }
                result.Add(new TopRoom() {
                    RoomNumber = ms.RoomNumber,
                    HotelName = ms.HotelName,
                    CountDay = total
                });
            }
            return result;
        }
    }
}