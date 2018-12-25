namespace WindowsFormsAND
{
    partial class User
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
            this.UserPage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Foundation_year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Active = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAddHotel = new System.Windows.Forms.Button();
            this.buttonDeleteHotel = new System.Windows.Forms.Button();
            this.buttonUpdateHotelData = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxFoundationYear = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelFoundationYear = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelHotelInfo = new System.Windows.Forms.Label();
            this.labelChangeHotelData = new System.Windows.Forms.Label();
            this.labelActive = new System.Windows.Forms.Label();
            this.checkBoxYes = new System.Windows.Forms.CheckBox();
            this.checkBoxNo = new System.Windows.Forms.CheckBox();
            this.buttonShowHotels = new System.Windows.Forms.Button();
            this.textBoxSelectHotel = new System.Windows.Forms.TextBox();
            this.labelSelectHotel = new System.Windows.Forms.Label();
            this.buttonEditHotelInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewHotels
            // 
            this.listViewHotels.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listViewHotels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserPage,
            this.Foundation_year,
            this.Address,
            this.Active});
            this.listViewHotels.Location = new System.Drawing.Point(12, 43);
            this.listViewHotels.Name = "listViewHotels";
            this.listViewHotels.Size = new System.Drawing.Size(512, 381);
            this.listViewHotels.TabIndex = 0;
            this.listViewHotels.UseCompatibleStateImageBehavior = false;
            this.listViewHotels.View = System.Windows.Forms.View.Details;
            // 
            // UserPage
            // 
            this.UserPage.Name = "UserPage";
            this.UserPage.Text = "Name";
            this.UserPage.Width = 103;
            // 
            // Foundation_year
            // 
            this.Foundation_year.Text = "Foundation year";
            this.Foundation_year.Width = 96;
            // 
            // Address
            // 
            this.Address.Text = "Address";
            this.Address.Width = 219;
            // 
            // Active
            // 
            this.Active.Text = "Active";
            this.Active.Width = 182;
            // 
            // buttonAddHotel
            // 
            this.buttonAddHotel.Location = new System.Drawing.Point(530, 255);
            this.buttonAddHotel.Name = "buttonAddHotel";
            this.buttonAddHotel.Size = new System.Drawing.Size(82, 48);
            this.buttonAddHotel.TabIndex = 1;
            this.buttonAddHotel.Text = "Add  Hotel";
            this.buttonAddHotel.UseVisualStyleBackColor = true;
            this.buttonAddHotel.Click += new System.EventHandler(this.addHotelButton_Click);
            // 
            // buttonDeleteHotel
            // 
            this.buttonDeleteHotel.Location = new System.Drawing.Point(721, 255);
            this.buttonDeleteHotel.Name = "buttonDeleteHotel";
            this.buttonDeleteHotel.Size = new System.Drawing.Size(76, 47);
            this.buttonDeleteHotel.TabIndex = 2;
            this.buttonDeleteHotel.Text = "Delete Hotel";
            this.buttonDeleteHotel.UseVisualStyleBackColor = true;
            this.buttonDeleteHotel.Click += new System.EventHandler(this.deleteHotelButton_Click_1);
            // 
            // buttonUpdateHotelData
            // 
            this.buttonUpdateHotelData.Location = new System.Drawing.Point(613, 255);
            this.buttonUpdateHotelData.Name = "buttonUpdateHotelData";
            this.buttonUpdateHotelData.Size = new System.Drawing.Size(108, 47);
            this.buttonUpdateHotelData.TabIndex = 3;
            this.buttonUpdateHotelData.Text = "Update Hotel Data";
            this.buttonUpdateHotelData.UseVisualStyleBackColor = true;
            this.buttonUpdateHotelData.Click += new System.EventHandler(this.updateHotelButton_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(588, 70);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(176, 20);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameHotel_textBox_KeyPress);
            // 
            // textBoxFoundationYear
            // 
            this.textBoxFoundationYear.Location = new System.Drawing.Point(588, 121);
            this.textBoxFoundationYear.Name = "textBoxFoundationYear";
            this.textBoxFoundationYear.Size = new System.Drawing.Size(176, 20);
            this.textBoxFoundationYear.TabIndex = 5;
            this.textBoxFoundationYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hotelFoundationYear_textBox_KeyPress);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(588, 163);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(176, 20);
            this.textBoxAddress.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(541, 51);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(49, 16);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Name";
            // 
            // labelFoundationYear
            // 
            this.labelFoundationYear.AutoSize = true;
            this.labelFoundationYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFoundationYear.Location = new System.Drawing.Point(541, 102);
            this.labelFoundationYear.Name = "labelFoundationYear";
            this.labelFoundationYear.Size = new System.Drawing.Size(122, 16);
            this.labelFoundationYear.TabIndex = 6;
            this.labelFoundationYear.Text = "Foundation Year";
            this.labelFoundationYear.UseWaitCursor = true;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAddress.Location = new System.Drawing.Point(541, 144);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(66, 16);
            this.labelAddress.TabIndex = 6;
            this.labelAddress.Text = "Address";
            // 
            // labelHotelInfo
            // 
            this.labelHotelInfo.AutoSize = true;
            this.labelHotelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHotelInfo.Location = new System.Drawing.Point(169, 9);
            this.labelHotelInfo.Name = "labelHotelInfo";
            this.labelHotelInfo.Size = new System.Drawing.Size(113, 25);
            this.labelHotelInfo.TabIndex = 7;
            this.labelHotelInfo.Text = "Hotel Info";
            // 
            // labelChangeHotelData
            // 
            this.labelChangeHotelData.AutoSize = true;
            this.labelChangeHotelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChangeHotelData.Location = new System.Drawing.Point(556, 9);
            this.labelChangeHotelData.Name = "labelChangeHotelData";
            this.labelChangeHotelData.Size = new System.Drawing.Size(208, 25);
            this.labelChangeHotelData.TabIndex = 7;
            this.labelChangeHotelData.Text = "Change Hotel data";
            // 
            // labelActive
            // 
            this.labelActive.AutoSize = true;
            this.labelActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelActive.Location = new System.Drawing.Point(537, 202);
            this.labelActive.Name = "labelActive";
            this.labelActive.Size = new System.Drawing.Size(51, 16);
            this.labelActive.TabIndex = 6;
            this.labelActive.Text = "Active";
            // 
            // checkBoxYes
            // 
            this.checkBoxYes.AutoSize = true;
            this.checkBoxYes.Location = new System.Drawing.Point(588, 221);
            this.checkBoxYes.Name = "checkBoxYes";
            this.checkBoxYes.Size = new System.Drawing.Size(42, 17);
            this.checkBoxYes.TabIndex = 8;
            this.checkBoxYes.Text = "yes";
            this.checkBoxYes.UseVisualStyleBackColor = true;
            // 
            // checkBoxNo
            // 
            this.checkBoxNo.AutoSize = true;
            this.checkBoxNo.Location = new System.Drawing.Point(670, 221);
            this.checkBoxNo.Name = "checkBoxNo";
            this.checkBoxNo.Size = new System.Drawing.Size(38, 17);
            this.checkBoxNo.TabIndex = 9;
            this.checkBoxNo.Text = "no";
            this.checkBoxNo.UseVisualStyleBackColor = true;
            // 
            // buttonShowHotels
            // 
            this.buttonShowHotels.Location = new System.Drawing.Point(351, 12);
            this.buttonShowHotels.Name = "buttonShowHotels";
            this.buttonShowHotels.Size = new System.Drawing.Size(75, 23);
            this.buttonShowHotels.TabIndex = 10;
            this.buttonShowHotels.Text = "Show hotels";
            this.buttonShowHotels.UseVisualStyleBackColor = true;
            this.buttonShowHotels.Click += new System.EventHandler(this.showHotels_Click_1);
            // 
            // textBoxSelectHotel
            // 
            this.textBoxSelectHotel.Location = new System.Drawing.Point(588, 338);
            this.textBoxSelectHotel.Name = "textBoxSelectHotel";
            this.textBoxSelectHotel.Size = new System.Drawing.Size(176, 20);
            this.textBoxSelectHotel.TabIndex = 5;
            this.textBoxSelectHotel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.selectHoteLTextBox_KeyPress);
            // 
            // labelSelectHotel
            // 
            this.labelSelectHotel.AutoSize = true;
            this.labelSelectHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSelectHotel.Location = new System.Drawing.Point(530, 319);
            this.labelSelectHotel.Name = "labelSelectHotel";
            this.labelSelectHotel.Size = new System.Drawing.Size(93, 16);
            this.labelSelectHotel.TabIndex = 6;
            this.labelSelectHotel.Text = "Select Hotel";
            // 
            // buttonEditHotelInfo
            // 
            this.buttonEditHotelInfo.Location = new System.Drawing.Point(670, 364);
            this.buttonEditHotelInfo.Name = "buttonEditHotelInfo";
            this.buttonEditHotelInfo.Size = new System.Drawing.Size(127, 34);
            this.buttonEditHotelInfo.TabIndex = 11;
            this.buttonEditHotelInfo.Text = "Edit Hotel Information";
            this.buttonEditHotelInfo.UseVisualStyleBackColor = true;
            this.buttonEditHotelInfo.Click += new System.EventHandler(this.editHotelButton_Click);
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonEditHotelInfo);
            this.Controls.Add(this.buttonShowHotels);
            this.Controls.Add(this.checkBoxNo);
            this.Controls.Add(this.checkBoxYes);
            this.Controls.Add(this.labelChangeHotelData);
            this.Controls.Add(this.labelHotelInfo);
            this.Controls.Add(this.labelActive);
            this.Controls.Add(this.labelSelectHotel);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelFoundationYear);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxSelectHotel);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxFoundationYear);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonUpdateHotelData);
            this.Controls.Add(this.buttonDeleteHotel);
            this.Controls.Add(this.buttonAddHotel);
            this.Controls.Add(this.listViewHotels);
            //this.Name = "User";
            this.Text = "UserPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewHotels;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Foundation_year;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.ColumnHeader Active;
        private System.Windows.Forms.Button buttonAddHotel;
        private System.Windows.Forms.Button buttonDeleteHotel;
        private System.Windows.Forms.Button buttonUpdateHotelData;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxFoundationYear;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelFoundationYear;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelHotelInfo;
        private System.Windows.Forms.Label labelChangeHotelData;
        private System.Windows.Forms.Label labelActive;
        private System.Windows.Forms.CheckBox checkBoxYes;
        private System.Windows.Forms.CheckBox checkBoxNo;
        private System.Windows.Forms.Button buttonShowHotels;
        private System.Windows.Forms.ColumnHeader UserPage;
        private System.Windows.Forms.TextBox textBoxSelectHotel;
        private System.Windows.Forms.Label labelSelectHotel;
        private System.Windows.Forms.Button buttonEditHotelInfo;
    }
}