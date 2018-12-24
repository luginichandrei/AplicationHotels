using DataAccessLayer;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsAND
{
    public partial class HotelPage : Form
    {

        private string hotelName;
        SqlConnection con = new SqlConnection(@"Data Source=CH1649\SQLEXPRESS;Initial Catalog=TESTAND;Integrated Security=True");
        public HotelPage(string text)
        {
            InitializeComponent();
            hotelName = text;
        }
        RoomRepository useRoomRepo = new RoomRepository();

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            con.Open();
            SqlCommand hotelId = new SqlCommand("SELECT id FROM hotels WHERE Name='" + hotelName + "'", con);
            int primaryKey = Convert.ToInt32(hotelId.ExecuteScalar());
            SqlCommand rooms = new SqlCommand("SELECT * FROM rooms WHERE Hotels_id='" + primaryKey + "'", con);
            SqlDataReader dr = rooms.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["Number"].ToString());
                item.SubItems.Add(dr["Price"].ToString());
                item.SubItems.Add(dr["Comfort_level"].ToString());
                item.SubItems.Add(dr["Capability"].ToString());

                listView1.Items.Add(item);
            }

            con.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

        private void HotelPage_Shown(object sender, EventArgs e)
        {
            label9.Text ="Hotel "+ hotelName+" data";
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            useRoomRepo.CreateRoom(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), hotelName);
            MessageBox.Show("Room "+ textBox1.Text + " add to hotel "+hotelName);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            useRoomRepo.DeleteRoom(Convert.ToInt32(textBox1.Text));
            MessageBox.Show("Room " + textBox1.Text + " remove to hotel " + hotelName);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            useRoomRepo.UpdateRoom(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), hotelName);
            MessageBox.Show("Room " + textBox1.Text + " update in hotel " + hotelName);
        }
    }
}
