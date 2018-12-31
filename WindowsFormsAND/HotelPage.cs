using BusinessLayer;
using DataAccessLayer;
using System;
using System.Windows.Forms;

namespace WindowsFormsAND
{
    public partial class HotelPage : Form
    {
        
        private string hotelName;
       
        public HotelPage(string text)
        {
            InitializeComponent();
            hotelName = text;
        }
        RoomRepository useRoomRepo = new RoomRepository();
        RoomService useRoomService = new RoomService();

        private void showRoomButton(object sender, EventArgs e)
        {
            useRoomService.GetBookedDays(DateTime.Now, DateTime.Now, "kyiv", 123 );
            listViewHotels.Items.Clear();
            var rooms  = useRoomRepo.GetAll(hotelName);

            foreach (var h in rooms)
            {
                ListViewItem item = new ListViewItem(h.NumberRoom);
                item.SubItems.Add(h.Price);
                item.SubItems.Add(h.ComfortLevel);
                item.SubItems.Add(h.Capability);
                item.SubItems.Add(h.ReserveTo);
                item.SubItems.Add(h.UserName);

                listViewHotels.Items.Add(item);
            }


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
            if (String.IsNullOrEmpty(RoomNumberTextBox.Text) || String.IsNullOrEmpty(PriceTextBox.Text))
            {
                MessageBox.Show("field is empty");
            }
            else
            {
                useRoomRepo.UpdateRoom(Convert.ToInt32(RoomNumberTextBox.Text), Convert.ToInt32(PriceTextBox.Text), Convert.ToInt32(comfortLevelDropList.Text), Convert.ToInt32(capabilityDropList.Text), hotelName);
                MessageBox.Show("Room " + RoomNumberTextBox.Text + " update in hotel " + hotelName);
            }
        }

        private void rezervedRoomButton(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxRoomNumberRez.Text) || String.IsNullOrEmpty(textBoxUserNameRez.Text))
            {
                MessageBox.Show("field is empty");
            }
            else
            {
                useRoomRepo.Rezerve(Convert.ToInt32(textBoxRoomNumberRez.Text), textBoxUserNameRez.Text, monthCalendarChangeDate.SelectionStart.ToString("s"), monthCalendarChangeDate.SelectionEnd.ToString("s"));
                MessageBox.Show("Room " + textBoxRoomNumberRez.Text + " rezerve for " + textBoxUserNameRez.Text + " from " + monthCalendarChangeDate.SelectionStart + "to" + monthCalendarChangeDate.SelectionEnd);
            }
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
