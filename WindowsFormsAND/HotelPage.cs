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



        private void showRoomButton(object sender, EventArgs e)
        {
            using(var c = new SqlConnection())
            {

            }
            //useRoomRepo.GetAll(hotelName); 
            listViewHotels.Items.Clear();
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
                listViewHotels.Items.Add(item);
            }

            con.Close();
        }

        private void hotelNameLabel(object sender, EventArgs e)
        {
            
        }

        private void HotelPage_Shown(object sender, EventArgs e)
        {
            labelHotelName.Text ="Hotel "+ hotelName+" rooms";
        }

        private void addRoomButton(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RoomNumberTextBox.Text) || String.IsNullOrEmpty(PriceTextBox.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("field is empty");
            }
            else
            {
                useRoomRepo.CreateRoom(Convert.ToInt32(RoomNumberTextBox.Text), Convert.ToInt32(PriceTextBox.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), hotelName);
                MessageBox.Show("Room " + RoomNumberTextBox.Text + " add to hotel " + hotelName);
            }

        }

        private void deleteRoomButton(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RoomNumberTextBox.Text))
            {
              MessageBox.Show("Select please room number");
            }
            else
            {
                useRoomRepo.DeleteRoom(Convert.ToInt32(RoomNumberTextBox.Text));
                MessageBox.Show("Room " + RoomNumberTextBox.Text + " remove to hotel " + hotelName);
            }
            
        }

        private void updateRoomData(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RoomNumberTextBox.Text) || String.IsNullOrEmpty(PriceTextBox.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("field is empty");
            }
            else
            {
                useRoomRepo.UpdateRoom(Convert.ToInt32(RoomNumberTextBox.Text), Convert.ToInt32(PriceTextBox.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), hotelName);
                MessageBox.Show("Room " + RoomNumberTextBox.Text + " update in hotel " + hotelName);
            }
        }

        private void rezervedRoomButton(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBoxRoomNumberRez.Text) || String.IsNullOrEmpty(textBoxUserNameRez.Text))
            useRoomRepo.Rezerve(Convert.ToInt32(textBoxRoomNumberRez.Text), textBoxUserNameRez.Text, monthCalendarChangeDate.SelectionStart, monthCalendarChangeDate.SelectionEnd);
            MessageBox.Show("Room " + textBoxRoomNumberRez.Text + " rezerve for " + textBoxUserNameRez.Text + " from "+ monthCalendarChangeDate.SelectionStart + "to" + monthCalendarChangeDate.SelectionEnd);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
