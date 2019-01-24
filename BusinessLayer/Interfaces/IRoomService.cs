using Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IRoomService : IService<Room>
    {
        List<Room> FindByHotelId(int hotelId);

        Room FindByNumber(int number, int hotelId);

        List<TopRoom> GetRoomRating(DateTime startTime, DateTime endTime, int hotelId);

        IEnumerable<RoomsWithRezervation> GetHotelRoomsWithRezervation(int hotelId);
    }
}