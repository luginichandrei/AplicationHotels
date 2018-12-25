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


        public void Rezerve(int roomNumber, string userName, DateTime start_date, DateTime end_date)
        {
            con.Open();
            SqlCommand roomId = new SqlCommand("SELECT id FROM rooms WHERE Number='" + roomNumber + "'", con);
            int room_Id = Convert.ToInt32(roomId.ExecuteScalar());
            SqlCommand userId = new SqlCommand("SELECT id FROM users WHERE Name='" + userName + "'", con);
            int user_Id = Convert.ToInt32(userId.ExecuteScalar());
            SqlCommand roomRezerv = new SqlCommand("UPDATE checkouts SET room_id='" + room_Id + "'," +
                "user_id='" + user_Id + "'," +
                "start_date='" + start_date + "'," +
                "end_date='" + end_date +                
                 "'", con);
            roomRezerv.ExecuteNonQuery();


        }

        //not work
        public List<List<String>> GetAll(string hotelName)
        {
            con.Open();
            SqlCommand hotelId = new SqlCommand("SELECT id FROM hotels WHERE Name='" + hotelName + "'", con);
            int primaryKey = Convert.ToInt32(hotelId.ExecuteScalar());
            SqlCommand rooms = new SqlCommand("SELECT * FROM rooms WHERE Hotels_id='" + primaryKey + "'", con);
            List<List<String>> result = new List<List<String>>();
            SqlDataReader dr = rooms.ExecuteReader();
            while (dr.Read())
            {
                var rec = new List<string>();
                for (int i = 0; i <= dr.FieldCount - 1; i++) 
                {
                    rec.Add(dr.GetString(i));
                }
                result.Add(rec);
            }

            con.Close();
            return result;
        }




    }
}
