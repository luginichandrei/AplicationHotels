using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Models;
using System.Configuration;

namespace DataAccessLayer
{
    public class HotelRepository 
    {
        public void CreateHotel(string name, string year, string address, int active = 1)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var addHotels ="INSERT INTO hotels VALUES(@name, @year, @address, @active)";
                con.Open();
                using (var addhotel = new SqlCommand(addHotels, con))
                {
                    addhotel.Parameters.Add(new SqlParameter("name", name));
                    addhotel.Parameters.Add(new SqlParameter("year", year));
                    addhotel.Parameters.Add(new SqlParameter("address", address));
                    addhotel.Parameters.Add(new SqlParameter("active", active));
                    addhotel.ExecuteNonQuery();  
                }
            }
        }

        public void DeleteHotel(string command)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var deleteHotels = "DELETE FROM hotels WHERE Name=@command";
                con.Open();
                using (var deleteHotel = new SqlCommand(deleteHotels, con))
                {
                        deleteHotel.Parameters.Add(new SqlParameter("command", command));
                        deleteHotel.ExecuteNonQuery();
                }
            }
        }

        public void UpdateHotel(string name, string year, string address, int active=1)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                var updateHotels = "UPDATE hotels SET Name=@name,Foundation_year=@year, Adress=@address,Is_active=@active WHERE Name=@name";
                using (var updateHotel = new SqlCommand(updateHotels, con))
                {
                    updateHotel.Parameters.Add(new SqlParameter("name", name));
                    updateHotel.Parameters.Add(new SqlParameter("year", year));
                    updateHotel.Parameters.Add(new SqlParameter("address", address));
                    updateHotel.Parameters.Add(new SqlParameter("active", active));
                    updateHotel.ExecuteNonQuery();
                }
            }
        }


        
        public virtual List<Hotel> GetAll()
        {
            List<Hotel> result = new List<Hotel>();
            var connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var hotels = new SqlCommand("SELECT * FROM hotels", con))
                {
                    SqlDataReader dr = hotels.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new Hotel();
                        
                        item.NameHotel = dr["Name"].ToString();
                        item.FoundationYear = dr["Foundation_year"].ToString();
                        item.Address = dr["Adress"].ToString();
                        item.IsActive = dr["Is_active"].ToString();
                        result.Add(item);
                    }

                }
            }

            return  result;
        }

    }
}
