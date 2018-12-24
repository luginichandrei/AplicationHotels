using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataAccessLayer;

namespace WindowsFormsAND
{
    public partial class User : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=CH1649\SQLEXPRESS;Initial Catalog=TESTAND;Integrated Security=True");
        public User()
        {
            InitializeComponent();
        }
        HotelRepository useHotelRepo = new HotelRepository();
       
        
        private void User_Shown(object sender, EventArgs e)
        {
           
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            con.Open();
            var hotels = new SqlCommand("SELECT * FROM hotels", con);
            SqlDataReader dr = hotels.ExecuteReader();
            while (dr.Read()){
                ListViewItem item = new ListViewItem(dr["Name"].ToString());
                item.SubItems.Add(dr["Foundation_year"].ToString());
                item.SubItems.Add(dr["Adress"].ToString());
                item.SubItems.Add(dr["Is_active"].ToString());

                listView1.Items.Add(item);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            useHotelRepo.CreateHotel(textBox1.Text, textBox2.Text, textBox3.Text);
            MessageBox.Show("Hotel add");    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            useHotelRepo.DeleteHotel(textBox1.Text);
            MessageBox.Show("Hotel " + textBox1.Text.ToUpper() + " delete");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            useHotelRepo.UpdateHotel(textBox1.Text, textBox2.Text, textBox3.Text);
            MessageBox.Show("Hotel " + textBox1.Text.ToUpper() + " Update");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            HotelPage hp = new HotelPage(textBox4.Text);
            hp.Show();
        }
    }
}
