using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class HotelRepository 
    {
        SqlConnection con = new SqlConnection(@"Data Source=CH1649\SQLEXPRESS;Initial Catalog=TESTAND;Integrated Security=True");

        public void CreateHotel(string name, string year, string address, int active = 1)
        {
            con.Open();
            SqlCommand addHotels = new SqlCommand("INSERT INTO hotels VALUES('" + 
                name + "','" +
                year + "','" +
                address + "','" + 
                active+ "')",con);
            addHotels.ExecuteNonQuery();            
            con.Close();
        }

        public void DeleteHotel(string command)
        {
            con.Open();
            SqlCommand deleteHotel = new SqlCommand("DELETE FROM hotels WHERE Name='" + command + "'", con);
            deleteHotel.ExecuteNonQuery();
            con.Close();

        }

        public void UpdateHotel(string name, string year, string address, int active=1)
        {
            con.Open();
            SqlCommand updateHotel = new SqlCommand("UPDATE hotels SET Name='" + name + "'," +
                "Foundation_year='" + year + "'," +
                "Adress='" + address + "'," +
                "Is_active='" + active +
                "' WHERE Name='" + name + "'", con);
            updateHotel.ExecuteNonQuery();
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
