using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsAND
{
    public partial class User : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=CH1649\SQLEXPRESS;Initial Catalog=TESTAND;Integrated Security=True");
               
        public User()
        {
            
            InitializeComponent();
        }              

        private void button4_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            con.Open();
            SqlCommand hotels = new SqlCommand("SELECT * FROM hotels", con);
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
            //con.Close();
            con.Open();
            SqlCommand addHotels = new SqlCommand("INSERT INTO hotels VALUES('"+textBox1.Text+"','"+ textBox2.Text+"','"+textBox3.Text+"',1)", con);
            addHotels.ExecuteNonQuery();
            MessageBox.Show("Hotel add");          
            con.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.Open();            
            SqlCommand deleteHotel = new SqlCommand("DELETE FROM hotels WHERE Name='" + textBox1.Text + "'", con);
            deleteHotel.ExecuteNonQuery();
            MessageBox.Show("Hotel " + textBox1.Text.ToUpper() + " delete");
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand updateHotel = new SqlCommand("UPDATE hotels SET Name='" + textBox1.Text + "'," +
                "Foundation_year='" + textBox2.Text + "'," +
                "Adress='" + textBox3.Text + "',"+

                "Is_active='"+ 1 + "'WHERE Name='" + textBox1.Text + "'", con);

            updateHotel.ExecuteNonQuery();
            MessageBox.Show("Hotel " + textBox1.Text.ToUpper() + " Update");
            con.Close();
        }
    }
}
