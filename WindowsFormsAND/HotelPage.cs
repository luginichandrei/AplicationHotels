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

        private void showRoomButton(object sender, EventArgs e)
        {
            using(var c = new SqlConnection())
            {

            }
            //useRoomRepo.GetAll(hotelName); 
            listView1.Items.Clear();
            con.Open();
            SqlCommand hotelId = new SqlCommand("SELECT id FROM hotels WHERE Name=@hotelName", con);
            hotelId.Parameters.Add(new SqlParameter("hotelName", hotelName));
            int primaryKey = Convert.ToInt32(hotelId.ExecuteScalar());
            SqlCommand rooms = new SqlCommand("SELECT * FROM rooms WHERE Hotels_id='" + primaryKey + "'", con);

            SqlDataReader dr = rooms.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["Number"].ToString());
                item.SubItems.Add(dr["Price"].ToString());
                item.SubItems.Add(dr["Comfort_level"].ToString());
                item.SubItems.Add(dr["Capability"].ToString());
                SqlCommand rezerv= new SqlCommand("SELECT end_date FROM checkouts WHERE room_id='" + 1 + "'", con);
                item.SubItems.Add(rezerv.ToString());
                listView1.Items.Add(item);
            }

            con.Close();
        }

        private void HotelPage_Shown(object sender, EventArgs e)
        {
            label9.Text ="Hotel "+ hotelName+" rooms";
        }

        private void addRoomButton(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("field is empty");
            }
            else
            {
                useRoomRepo.CreateRoom(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), hotelName);
                MessageBox.Show("Room " + textBox1.Text + " add to hotel " + hotelName);
            }

        }

        private void deleteRoomButton(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
              MessageBox.Show("Select please room number");
            }
            else
            {
                useRoomRepo.DeleteRoom(Convert.ToInt32(textBox1.Text));
                MessageBox.Show("Room " + textBox1.Text + " remove to hotel " + hotelName);
            }
            
        }

        private void updateRoomData(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("field is empty");
            }
            else
            {
                useRoomRepo.UpdateRoom(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), hotelName);
                MessageBox.Show("Room " + textBox1.Text + " update in hotel " + hotelName);
            }
        }

        private void rezervedRoomButton(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text))
            useRoomRepo.Rezerve(Convert.ToInt32(textBox5.Text), textBox6.Text, monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd);
            MessageBox.Show("Room " + textBox5.Text + " rezerve for " + textBox6.Text + " from "+ monthCalendar1.SelectionStart + "to" + monthCalendar1.SelectionEnd);
        }

        private void roomNomber_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void price_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comfort_level_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void capability_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void roomNumberRezerv_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
