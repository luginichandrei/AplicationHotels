﻿using System;
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
      
        private void showHotels_Click_1(object sender, EventArgs e)
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

        private void addHotelButton_Click(object sender, EventArgs e)
        {
            useHotelRepo.CreateHotel(textBox1.Text, textBox2.Text, textBox3.Text);
            MessageBox.Show("Hotel add");    
        }

        private void deleteHotelButton_Click_1(object sender, EventArgs e)
        {
            useHotelRepo.DeleteHotel(textBox1.Text);
            MessageBox.Show("Hotel " + textBox1.Text.ToUpper() + " delete");
        }

        private void updateHotelButton_Click(object sender, EventArgs e)
        {
            useHotelRepo.UpdateHotel(textBox1.Text, textBox2.Text, textBox3.Text);
            MessageBox.Show("Hotel " + textBox1.Text.ToUpper() + " Update");
        }

        private void editHotelButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Enter please hotel name");
            }
            else
            {
                this.Hide();
                HotelPage hp = new HotelPage(textBox4.Text);
                hp.Show();
            }
        }

        private void hotelFoundationYear_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void nameHotel_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void selectHoteLTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
