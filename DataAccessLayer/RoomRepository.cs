using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class RoomRepository
    {
        SqlConnection con = new SqlConnection(@"Data Source=CH1649\SQLEXPRESS;Initial Catalog=TESTAND;Integrated Security=True");

        public void CreateRoom(int number, int price, int level, int capability, string hotelName)
        {
            con.Open();
            SqlCommand hotelId = new SqlCommand("SELECT id FROM hotels WHERE Name='" + hotelName + "'", con);
            int primaryKey = Convert.ToInt32(hotelId.ExecuteScalar());
            SqlCommand addRoom = new SqlCommand("INSERT INTO rooms VALUES('" +
                number + "','" +
                price + "','" +
                level + "','" +
                capability + "','" +
                primaryKey + "')", con);
            addRoom.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteRoom(int roomNumber)
        {
            con.Open();
            SqlCommand deleteRoom = new SqlCommand("DELETE FROM rooms WHERE Number='" + roomNumber + "'", con);
            deleteRoom.ExecuteNonQuery();
            con.Close();

        }

        public void UpdateRoom(int number, int price, int level, int capability, string hotelName)
        {
            con.Open();
            SqlCommand hotelId = new SqlCommand("SELECT id FROM hotels WHERE Name='" + hotelName + "'", con);
            int primaryKey = Convert.ToInt32(hotelId.ExecuteScalar());
            SqlCommand updateRoom = new SqlCommand("UPDATE rooms SET Number='" + number + "'," +
                "Price='" + price + "'," +
                "Comfort_level='" + level + "'," +
                "Capability='" + capability +
                "' WHERE Number='" + number + 
                "'AND Hotels_id='" + primaryKey + "'", con);
            updateRoom.ExecuteNonQuery();
            con.Close();
        }


        //not work
        public SqlDataReader GetAll()
        {
            con.Open();
            var hotels = new SqlCommand("SELECT * FROM hotels", con);
            SqlDataReader result = hotels.ExecuteReader();
            con.Close();
            return result;
        }




    }
}
