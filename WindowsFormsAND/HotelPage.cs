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
            //useRoomRepo.GetAll(hotelName); 
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
                SqlCommand rezerv= new SqlCommand("SELECT end_date FROM checkouts WHERE room_id='" + 1 + "'", con);
                item.SubItems.Add(rezerv.ToString());
                listView1.Items.Add(item);
            }

            con.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

        private void HotelPage_Shown(object sender, EventArgs e)
        {
            label9.Text ="Hotel "+ hotelName+" rooms";
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text))
            useRoomRepo.Rezerve(Convert.ToInt32(textBox5.Text), textBox6.Text, monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd);
            MessageBox.Show("Room " + textBox5.Text + " rezerve for " + textBox6.Text + " from "+ monthCalendar1.SelectionStart + "to" + monthCalendar1.SelectionEnd);
        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
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
