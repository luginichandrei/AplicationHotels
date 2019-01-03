using System;
using System.Windows.Forms;
using BusinessLayer;
using DataAccessLayer;
using Models;

namespace WindowsFormsAND
{
    public partial class User : Form
    {
        HotelService hotelService = new HotelService(ContextResolver.GetContext());
        public User()
        {
            InitializeComponent();

        }
        private void showHotels_Click_1(object sender, EventArgs e)
        {
            listViewHotels.Items.Clear();
            var hotels = hotelService.GetAll();
            
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
            if (String.IsNullOrEmpty(textBoxName.Text) || String.IsNullOrEmpty(textBoxFoundationYear.Text) || String.IsNullOrEmpty(textBoxAddress.Text))
            {
                MessageBox.Show("field is empty");
            }
            else
            {
                var hotel = new Hotel()
                {
                    Name = textBoxName.Text,
                    FoundationYear = Convert.ToInt32(textBoxFoundationYear.Text),
                    Address = textBoxAddress.Text,
                    IsActive = 1,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow
                };   
                hotelService.Create(hotel);
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
                var idHotel = hotelService.FindByName(textBoxName.Text);
                hotelService.Delete(idHotel);
                MessageBox.Show("Hotel " + textBoxName.Text.ToUpper() + " delete");
            }
        }

        private void updateHotelButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName.Text) || String.IsNullOrEmpty(textBoxFoundationYear.Text) || String.IsNullOrEmpty(textBoxAddress.Text))
            {
                MessageBox.Show("field is empty");
            }
            else
            {
                var currentId =hotelService.FindByName(textBoxName.Text).Id;
                var hotel = new Hotel()
                {
                    Id = currentId,
                    Name = textBoxName.Text,
                    FoundationYear = Convert.ToInt32(textBoxFoundationYear.Text),
                    Address = textBoxAddress.Text,
                    IsActive = 1,
                    Modified = DateTime.UtcNow
                };
                hotelService.Update(hotel);
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
