using BusinessLayer;
using DataAccessLayer;
using Models;
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

        private void showRoomButton(object sender, EventArgs e)
        {
            using (var ctx = ContextResolver.GetContext())
            {
                var roomService = new RoomService(ctx);

                listViewHotels.Items.Clear();
                var rooms = roomService.GetAll();
                foreach (var h in rooms)
                {
                    ListViewItem item = new ListViewItem(h.Number.ToString());
                    item.SubItems.Add(h.Price.ToString());
                    item.SubItems.Add(h.ComfortLevel.ToString());
                    item.SubItems.Add(h.Capability.ToString());
                    listViewHotels.Items.Add(item);
                }
            }
        }
        
        private void HotelPage_Shown(object sender, EventArgs e)
        {
            labelHotelName.Text ="Hotel "+ hotelName+" rooms";
        }

        private void addRoomButton(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RoomNumberTextBox.Text) || String.IsNullOrEmpty(PriceTextBox.Text) || String.IsNullOrEmpty(comfortLevelDropList.Text) || String.IsNullOrEmpty(capabilityDropList.Text))
            {
                MessageBox.Show("field is empty");
            }
            else
            {
                using (var ctx = ContextResolver.GetContext())
                {
                    var roomService = new RoomService(ctx);

                    //var hotelid = roomService.FindByName(hotelName);
                    var room = new Room
                    {
                        Number = Convert.ToInt32(RoomNumberTextBox.Text),
                        Price = Convert.ToInt32(PriceTextBox.Text),
                        ComfortLevel = Convert.ToInt32(comfortLevelDropList.Text),
                        Capability = Convert.ToInt32(capabilityDropList.Text),
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow,
                        //HotelId = hotelid.Id
                    };
                    roomService.Create(room);
                    MessageBox.Show("Room " + RoomNumberTextBox.Text + " add to hotel " + hotelName);
                }
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
                using (var ctx = ContextResolver.GetContext())
                {
                    var roomService = new RoomService(ctx);

                    var idRoom = roomService.FindByNumber(Convert.ToInt32(RoomNumberTextBox.Text));
                    roomService.Delete(idRoom);
                    MessageBox.Show("Room " + RoomNumberTextBox.Text + " remove to hotel " + hotelName);
                }
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
                using (var ctx = ContextResolver.GetContext())
                {
                    var roomService = new RoomService(ctx);

                    //var hotelid = roomService.FindByName(hotelName);
                    var currentId = roomService.FindByNumber(Convert.ToInt32(RoomNumberTextBox.Text)).Id;
                    var room = new Room()
                    {
                        Id = currentId,
                        Number = Convert.ToInt32(RoomNumberTextBox.Text),
                        Price = Convert.ToInt32(PriceTextBox.Text),
                        ComfortLevel = Convert.ToInt32(comfortLevelDropList.Text),
                        Capability = Convert.ToInt32(capabilityDropList.Text),
                        Modified = DateTime.UtcNow,
                       // HotelId = hotelid.Id
                    };
                    roomService.Update(room);
                    MessageBox.Show("Room " + RoomNumberTextBox.Text + " update in hotel " + hotelName);
                }
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
                using (var ctx = ContextResolver.GetContext())
                {
                    var roomService = new RoomService(ctx);

                    var roomId = roomService.FindByNumber(Convert.ToInt32(textBoxRoomNumberRez.Text)).Id;
                    //var userId = roomService.FindUser(textBoxUserNameRez.Text).Id;
                    var rezerve = new Rezervation()
                    {
                        Checkin = monthCalendarChangeDate.SelectionStart,
                        Checkout = monthCalendarChangeDate.SelectionEnd,
                        RoomId = roomId,
                        //UserId = userId
                    };
                    //roomService.AddRezerve(rezerve);
                    MessageBox.Show("Room " + textBoxRoomNumberRez.Text + " rezerve for " + textBoxUserNameRez.Text + " from " + monthCalendarChangeDate.SelectionStart + "to" + monthCalendarChangeDate.SelectionEnd);
                }
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
