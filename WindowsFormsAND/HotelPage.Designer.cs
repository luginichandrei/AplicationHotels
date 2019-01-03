namespace WindowsFormsAND
{
    partial class HotelPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewHotels = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonRezerved = new System.Windows.Forms.Button();
            this.labelChangeHotelData = new System.Windows.Forms.Label();
            this.labelRoomNumber = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelComfortLebel = new System.Windows.Forms.Label();
            this.labelCapability = new System.Windows.Forms.Label();
            this.RoomNumberTextBox = new System.Windows.Forms.TextBox();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.labelRoomNumberRez = new System.Windows.Forms.Label();
            this.textBoxRoomNumberRez = new System.Windows.Forms.TextBox();
            this.labelChabgeDate = new System.Windows.Forms.Label();
            this.showRoomsButton = new System.Windows.Forms.Button();
            this.labelHotelName = new System.Windows.Forms.Label();
            this.buttonAddRoom = new System.Windows.Forms.Button();
            this.buttonUodateRoomData = new System.Windows.Forms.Button();
            this.buttonDeleteRoom = new System.Windows.Forms.Button();
            this.labelRoomRezerve = new System.Windows.Forms.Label();
            this.monthCalendarChangeDate = new System.Windows.Forms.MonthCalendar();
            this.labelUserNameRez = new System.Windows.Forms.Label();
            this.textBoxUserNameRez = new System.Windows.Forms.TextBox();
            this.comfortLevelDropList = new System.Windows.Forms.ComboBox();
            this.capabilityDropList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listViewHotels
            // 
            this.listViewHotels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewHotels.Location = new System.Drawing.Point(7, 53);
            this.listViewHotels.Name = "listViewHotels";
            this.listViewHotels.Size = new System.Drawing.Size(403, 406);
            this.listViewHotels.TabIndex = 0;
            this.listViewHotels.UseCompatibleStateImageBehavior = false;
            this.listViewHotels.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Number Room";
            this.columnHeader1.Width = 84;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Price";
            this.columnHeader2.Width = 38;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Comfort Level";
            this.columnHeader3.Width = 79;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Capability";
            this.columnHeader4.Width = 54;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Rezerved to";
            this.columnHeader5.Width = 72;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Rezerved by";
            this.columnHeader6.Width = 73;
            // 
            // buttonRezerved
            // 
            this.buttonRezerved.Location = new System.Drawing.Point(464, 435);
            this.buttonRezerved.Name = "buttonRezerved";
            this.buttonRezerved.Size = new System.Drawing.Size(140, 24);
            this.buttonRezerved.TabIndex = 3;
            this.buttonRezerved.Text = "rezerved";
            this.buttonRezerved.UseVisualStyleBackColor = true;
            this.buttonRezerved.Click += new System.EventHandler(this.rezervedRoomButton);
            // 
            // labelChangeHotelData
            // 
            this.labelChangeHotelData.AutoSize = true;
            this.labelChangeHotelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChangeHotelData.Location = new System.Drawing.Point(452, 9);
            this.labelChangeHotelData.Name = "labelChangeHotelData";
            this.labelChangeHotelData.Size = new System.Drawing.Size(208, 25);
            this.labelChangeHotelData.TabIndex = 4;
            this.labelChangeHotelData.Text = "Change Hotel data";
            // 
            // labelRoomNumber
            // 
            this.labelRoomNumber.AutoSize = true;
            this.labelRoomNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRoomNumber.Location = new System.Drawing.Point(425, 57);
            this.labelRoomNumber.Name = "labelRoomNumber";
            this.labelRoomNumber.Size = new System.Drawing.Size(121, 20);
            this.labelRoomNumber.TabIndex = 5;
            this.labelRoomNumber.Text = "Room number";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrice.Location = new System.Drawing.Point(426, 94);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(49, 20);
            this.labelPrice.TabIndex = 6;
            this.labelPrice.Text = "Price";
            // 
            // labelComfortLebel
            // 
            this.labelComfortLebel.AutoSize = true;
            this.labelComfortLebel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelComfortLebel.Location = new System.Drawing.Point(426, 133);
            this.labelComfortLebel.Name = "labelComfortLebel";
            this.labelComfortLebel.Size = new System.Drawing.Size(120, 20);
            this.labelComfortLebel.TabIndex = 7;
            this.labelComfortLebel.Text = "Comfort Level";
            // 
            // labelCapability
            // 
            this.labelCapability.AutoSize = true;
            this.labelCapability.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCapability.Location = new System.Drawing.Point(426, 177);
            this.labelCapability.Name = "labelCapability";
            this.labelCapability.Size = new System.Drawing.Size(87, 20);
            this.labelCapability.TabIndex = 8;
            this.labelCapability.Text = "Capability";
            // 
            // RoomNumberTextBox
            // 
            this.RoomNumberTextBox.Location = new System.Drawing.Point(552, 59);
            this.RoomNumberTextBox.Name = "RoomNumberTextBox";
            this.RoomNumberTextBox.Size = new System.Drawing.Size(108, 20);
            this.RoomNumberTextBox.TabIndex = 9;
            this.RoomNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(552, 94);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(108, 20);
            this.PriceTextBox.TabIndex = 10;
            this.PriceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // labelRoomNumberRez
            // 
            this.labelRoomNumberRez.AutoSize = true;
            this.labelRoomNumberRez.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRoomNumberRez.Location = new System.Drawing.Point(439, 306);
            this.labelRoomNumberRez.Name = "labelRoomNumberRez";
            this.labelRoomNumberRez.Size = new System.Drawing.Size(107, 16);
            this.labelRoomNumberRez.TabIndex = 13;
            this.labelRoomNumberRez.Text = "Room Number";
            // 
            // textBoxRoomNumberRez
            // 
            this.textBoxRoomNumberRez.Location = new System.Drawing.Point(548, 334);
            this.textBoxRoomNumberRez.Name = "textBoxRoomNumberRez";
            this.textBoxRoomNumberRez.Size = new System.Drawing.Size(56, 20);
            this.textBoxRoomNumberRez.TabIndex = 14;
            this.textBoxRoomNumberRez.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // labelChabgeDate
            // 
            this.labelChabgeDate.AutoSize = true;
            this.labelChabgeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChabgeDate.Location = new System.Drawing.Point(685, 273);
            this.labelChabgeDate.Name = "labelChabgeDate";
            this.labelChabgeDate.Size = new System.Drawing.Size(79, 13);
            this.labelChabgeDate.TabIndex = 13;
            this.labelChabgeDate.Text = "Change date";
            // 
            // showRoomsButton
            // 
            this.showRoomsButton.Location = new System.Drawing.Point(274, 18);
            this.showRoomsButton.Name = "showRoomsButton";
            this.showRoomsButton.Size = new System.Drawing.Size(75, 23);
            this.showRoomsButton.TabIndex = 15;
            this.showRoomsButton.Text = "Show rooms";
            this.showRoomsButton.UseVisualStyleBackColor = true;
            this.showRoomsButton.Click += new System.EventHandler(this.showRoomButton);
            // 
            // labelHotelName
            // 
            this.labelHotelName.AutoSize = true;
            this.labelHotelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHotelName.Location = new System.Drawing.Point(12, 18);
            this.labelHotelName.Name = "labelHotelName";
            this.labelHotelName.Size = new System.Drawing.Size(67, 25);
            this.labelHotelName.TabIndex = 16;
            this.labelHotelName.Text = "Hotel";
            // 
            // buttonAddRoom
            // 
            this.buttonAddRoom.Location = new System.Drawing.Point(675, 79);
            this.buttonAddRoom.Name = "buttonAddRoom";
            this.buttonAddRoom.Size = new System.Drawing.Size(100, 35);
            this.buttonAddRoom.TabIndex = 17;
            this.buttonAddRoom.Text = "Add room";
            this.buttonAddRoom.UseVisualStyleBackColor = true;
            this.buttonAddRoom.Click += new System.EventHandler(this.addRoomButton);
            // 
            // buttonUodateRoomData
            // 
            this.buttonUodateRoomData.Location = new System.Drawing.Point(675, 127);
            this.buttonUodateRoomData.Name = "buttonUodateRoomData";
            this.buttonUodateRoomData.Size = new System.Drawing.Size(100, 35);
            this.buttonUodateRoomData.TabIndex = 17;
            this.buttonUodateRoomData.Text = "Update room data";
            this.buttonUodateRoomData.UseVisualStyleBackColor = true;
            this.buttonUodateRoomData.Click += new System.EventHandler(this.updateRoomData);
            // 
            // buttonDeleteRoom
            // 
            this.buttonDeleteRoom.Location = new System.Drawing.Point(675, 177);
            this.buttonDeleteRoom.Name = "buttonDeleteRoom";
            this.buttonDeleteRoom.Size = new System.Drawing.Size(100, 35);
            this.buttonDeleteRoom.TabIndex = 17;
            this.buttonDeleteRoom.Text = "Delete room";
            this.buttonDeleteRoom.UseVisualStyleBackColor = true;
            this.buttonDeleteRoom.Click += new System.EventHandler(this.deleteRoomButton);
            // 
            // labelRoomRezerve
            // 
            this.labelRoomRezerve.AutoSize = true;
            this.labelRoomRezerve.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRoomRezerve.Location = new System.Drawing.Point(474, 250);
            this.labelRoomRezerve.Name = "labelRoomRezerve";
            this.labelRoomRezerve.Size = new System.Drawing.Size(141, 24);
            this.labelRoomRezerve.TabIndex = 18;
            this.labelRoomRezerve.Text = "Room rezerve";
            // 
            // monthCalendarChangeDate
            // 
            this.monthCalendarChangeDate.Location = new System.Drawing.Point(616, 297);
            this.monthCalendarChangeDate.MaxSelectionCount = 30;
            this.monthCalendarChangeDate.Name = "monthCalendarChangeDate";
            this.monthCalendarChangeDate.TabIndex = 19;
            // 
            // labelUserNameRez
            // 
            this.labelUserNameRez.AutoSize = true;
            this.labelUserNameRez.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserNameRez.Location = new System.Drawing.Point(439, 360);
            this.labelUserNameRez.Name = "labelUserNameRez";
            this.labelUserNameRez.Size = new System.Drawing.Size(86, 16);
            this.labelUserNameRez.TabIndex = 21;
            this.labelUserNameRez.Text = "User Name";
            // 
            // textBoxUserNameRez
            // 
            this.textBoxUserNameRez.Location = new System.Drawing.Point(505, 379);
            this.textBoxUserNameRez.Name = "textBoxUserNameRez";
            this.textBoxUserNameRez.Size = new System.Drawing.Size(99, 20);
            this.textBoxUserNameRez.TabIndex = 14;
            // 
            // comfortLevelDropList
            // 
            this.comfortLevelDropList.FormattingEnabled = true;
            this.comfortLevelDropList.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comfortLevelDropList.Location = new System.Drawing.Point(552, 133);
            this.comfortLevelDropList.Name = "comfortLevelDropList";
            this.comfortLevelDropList.Size = new System.Drawing.Size(108, 21);
            this.comfortLevelDropList.TabIndex = 22;
            // 
            // capabilityDropList
            // 
            this.capabilityDropList.FormattingEnabled = true;
            this.capabilityDropList.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.capabilityDropList.Location = new System.Drawing.Point(552, 179);
            this.capabilityDropList.Name = "capabilityDropList";
            this.capabilityDropList.Size = new System.Drawing.Size(108, 21);
            this.capabilityDropList.TabIndex = 23;
            // 
            // HotelPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(787, 471);
            this.Controls.Add(this.capabilityDropList);
            this.Controls.Add(this.comfortLevelDropList);
            this.Controls.Add(this.labelUserNameRez);
            this.Controls.Add(this.monthCalendarChangeDate);
            this.Controls.Add(this.labelRoomRezerve);
            this.Controls.Add(this.buttonDeleteRoom);
            this.Controls.Add(this.buttonUodateRoomData);
            this.Controls.Add(this.buttonAddRoom);
            this.Controls.Add(this.labelHotelName);
            this.Controls.Add(this.showRoomsButton);
            this.Controls.Add(this.textBoxUserNameRez);
            this.Controls.Add(this.textBoxRoomNumberRez);
            this.Controls.Add(this.labelChabgeDate);
            this.Controls.Add(this.labelRoomNumberRez);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.RoomNumberTextBox);
            this.Controls.Add(this.labelCapability);
            this.Controls.Add(this.labelComfortLebel);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelRoomNumber);
            this.Controls.Add(this.labelChangeHotelData);
            this.Controls.Add(this.buttonRezerved);
            this.Controls.Add(this.listViewHotels);
            this.Name = "HotelPage";
            this.Text = "HotelPage";
            this.Shown += new System.EventHandler(this.HotelPage_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewHotels;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buttonRezerved;
        private System.Windows.Forms.Label labelChangeHotelData;
        private System.Windows.Forms.Label labelRoomNumber;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelComfortLebel;
        private System.Windows.Forms.Label labelCapability;
        private System.Windows.Forms.TextBox RoomNumberTextBox;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.Label labelRoomNumberRez;
        private System.Windows.Forms.TextBox textBoxRoomNumberRez;
        private System.Windows.Forms.Label labelChabgeDate;
        private System.Windows.Forms.Button showRoomsButton;
        private System.Windows.Forms.Label labelHotelName;
        private System.Windows.Forms.Button buttonAddRoom;
        private System.Windows.Forms.Button buttonUodateRoomData;
        private System.Windows.Forms.Button buttonDeleteRoom;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label labelRoomRezerve;
        private System.Windows.Forms.MonthCalendar monthCalendarChangeDate;
        private System.Windows.Forms.Label labelUserNameRez;
        private System.Windows.Forms.TextBox textBoxUserNameRez;
        private System.Windows.Forms.ComboBox comfortLevelDropList;
        private System.Windows.Forms.ComboBox capabilityDropList;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}