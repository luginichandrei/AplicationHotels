
using System.Data.SqlClient;

namespace DALayer
{
    public class HotelRepository
    {
        SqlConnection con = new SqlConnection(@"Data Source=CH1649\SQLEXPRESS;Initial Catalog=TESTAND;Integrated Security=True");

        public void CreateHotel(string command) {
            con.Open();
            SqlCommand hotelId = new SqlCommand(command);

            con.Close();
        }

        public void DeleteHotel(string command)
        {
            con.Open();
            SqlCommand deleteHotel = new SqlCommand("DELETE FROM hotels WHERE Name='" + command + "'", con);
            deleteHotel.ExecuteNonQuery();
            con.Close();

        }

        public void EditHotel(string command)
        {
            con.Open();
            SqlCommand hotelId = new SqlCommand(command);

            con.Close();

        }



    }
}
