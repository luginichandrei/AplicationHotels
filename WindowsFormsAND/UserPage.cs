using System;
using System.Windows.Forms;
using DataAccessLayer;

namespace WindowsFormsAND
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }
        HotelRepository useHotelRepo = new HotelRepository();
      
        private void showHotels_Click_1(object sender, EventArgs e)
        {
            listViewHotels.Items.Clear();
            var hotels = useHotelRepo.GetAll();
            
            foreach (var h in hotels){
                ListViewItem item = new ListViewItem(h.Name);
                item.SubItems.Add(h.FoundationYear.ToString());
                item.SubItems.Add(h.Address);
                item.SubItems.Add(h.IsActive.ToString());

                listViewHotels.Items.Add(item);
            }
        }

        private void addHotelButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxSelectHotel.Text) || String.IsNullOrEmpty(textBoxFoundationYear.Text) || String.IsNullOrEmpty(textBoxAddress.Text))
            {
                MessageBox.Show("field is empty");
            }
            else
            {
                useHotelRepo.CreateHotel(textBoxName.Text, textBoxFoundationYear.Text, textBoxAddress.Text);
                MessageBox.Show("Hotel add");   
            }
                
        }

        private void deleteHotelButton_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("field |Hotel name| is empty");
            }
            else
            {
                useHotelRepo.DeleteHotel(textBoxName.Text);
                MessageBox.Show("Hotel " + textBoxName.Text.ToUpper() + " delete");
            }
        }

        private void updateHotelButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxSelectHotel.Text) || String.IsNullOrEmpty(textBoxFoundationYear.Text) || String.IsNullOrEmpty(textBoxAddress.Text))
            {
                MessageBox.Show("field is empty");
            }
            else
            {
                useHotelRepo.UpdateHotel(textBoxName.Text, textBoxFoundationYear.Text, textBoxAddress.Text);
                MessageBox.Show("Hotel " + textBoxName.Text.ToUpper() + " Update");
            }
            
        }

        private void editHotelButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxSelectHotel.Text))
            {
                MessageBox.Show("Enter please hotel name");
            }
            else
            {
                this.Hide();
                HotelPage hp = new HotelPage(textBoxSelectHotel.Text);
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
