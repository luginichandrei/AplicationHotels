using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Models;
using System.Configuration;

namespace DataAccessLayer
{
    public class RoomRepository
    {
        public void CreateRoom(int number, int price, int level, int capability, string hotelName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var addRooms = "INSERT INTO rooms VALUES(@number, @price, @level, @capability, @primaryKey";
                con.Open();
                using (var addRoom = new SqlCommand(addRooms, con))
                {
                    using (SqlCommand hotelId = new SqlCommand("SELECT id FROM hotels WHERE Name=@hotelName", con))
                    {
                        hotelId.Parameters.Add(new SqlParameter("hotelName", hotelName));
                        int primaryKey = Convert.ToInt32(hotelId.ExecuteScalar());
                        addRoom.Parameters.Add(new SqlParameter("price", price));
                        addRoom.Parameters.Add(new SqlParameter("level", level));
                        addRoom.Parameters.Add(new SqlParameter("capability", capability));
                        addRoom.Parameters.Add(new SqlParameter("primaryKey", primaryKey));
                        addRoom.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteRoom(int roomNumber)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var deleteRooms = "DELETE FROM rooms WHERE Number=@roomNumber";
                con.Open();
                using (var deleteRoom = new SqlCommand(deleteRooms, con))
                {
                    deleteRoom.Parameters.Add(new SqlParameter("roomNumber", roomNumber));
                    deleteRoom.ExecuteNonQuery();
                }
            }
        }

        public void UpdateRoom(int number, int price, int level, int capability, string hotelName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var updateRooms = @"UPDATE rooms SET Number = @number,
                Price=@price, 
                Comfort_level=@level,
                Capability=@capability
                WHERE Number=@number
                AND Hotels_id=@primaryKey";
                con.Open();
                using (var updateRoom = new SqlCommand(updateRooms, con))
                {
                    using (var hotelId = new SqlCommand("SELECT id FROM hotels WHERE Name=@hotelName", con))
                    {
                        hotelId.Parameters.Add(new SqlParameter("hotelName", hotelName));
                        int primaryKey = Convert.ToInt32(hotelId.ExecuteScalar());
                        updateRoom.Parameters.Add(new SqlParameter("number", number));
                        updateRoom.Parameters.Add(new SqlParameter("price", price));
                        updateRoom.Parameters.Add(new SqlParameter("capability", capability));
                        updateRoom.Parameters.Add(new SqlParameter("level", level));
                        updateRoom.Parameters.Add(new SqlParameter("primaryKey", primaryKey));
                        updateRoom.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Rezerve(int roomNumber, string userName, string start_date, string end_date)

        {
            var connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var roomRezervs = "INSERT INTO checkouts VALUES((SELECT id FROM users WHERE Name=@userName), " +
                    "(SELECT id FROM rooms WHERE Number=@roomNumber), @start_date,@end_date)";
                con.Open();
                using (var roomRezerv = new SqlCommand(roomRezervs, con))
                {
                    roomRezerv.Parameters.Add(new SqlParameter("roomNumber", roomNumber));
                    roomRezerv.Parameters.Add(new SqlParameter("userName", userName));
                    roomRezerv.Parameters.Add(new SqlParameter("start_date", start_date));
                    roomRezerv.Parameters.Add(new SqlParameter("end_date", end_date));

                    roomRezerv.ExecuteNonQuery();
                }
            }
        }


        public List<RoomsList> GetAll(string hotelName)
        {
            var result = new List<RoomsList>();
            var connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                var getList = @"SELECT  rooms.Number, rooms.Capability, rooms.Comfort_level, rooms.Price, checkouts.end_date, users.Name
                                FROM hotels
                                LEFT JOIN rooms ON Hotels_id=hotels.id
                                LEFT JOIN checkouts ON checkouts.room_id=rooms.id
                                LEFT JOIN users ON checkouts.user_id=users.id
                                where hotels.Name=@hotelName";
                con.Open();
                using (var hotels = new SqlCommand(getList, con))
                {
                    hotels.Parameters.Add(new SqlParameter("hotelName", hotelName));
                    SqlDataReader dr = hotels.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new RoomsList();
                        item.NumberRoom = dr["Number"].ToString();
                        item.Price = dr["Price"].ToString();
                        item.ComfortLevel = dr["Comfort_level"].ToString();
                        item.Capability = dr["Capability"].ToString();
                        item.ReserveTo = dr["end_date"].ToString();
                        item.UserName = dr["Name"].ToString();
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public List<RezervedDays> GetRezervedDays(string hotelName, int roomNumber)
        {
            var result = new List<RezervedDays>();

            var connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                var getList = @"SELECT   checkouts.start_date, checkouts.end_date
                                FROM hotels
                                LEFT JOIN rooms ON Hotels_id=hotels.id
                                LEFT JOIN checkouts ON checkouts.room_id=rooms.id
                                LEFT JOIN users ON checkouts.user_id=users.id
                                where hotels.Name=@hotelName and rooms.Number=@roomNumber";
                con.Open();
                using (var hotels = new SqlCommand(getList, con))
                {
                    hotels.Parameters.Add(new SqlParameter("hotelName", hotelName));
                    hotels.Parameters.Add(new SqlParameter("roomNumber", roomNumber));
                    SqlDataReader dr = hotels.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new RezervedDays();
                        item.StartDate = DateTime.Parse(dr["start_date"].ToString());
                        item.EndDate = DateTime.Parse(dr["end_date"].ToString());
                        result.Add(item);
                    }
                }
            }
            return result;

        }
    }
}
