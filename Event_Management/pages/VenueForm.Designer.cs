namespace Event_Management.pages
{
    partial class VenueForm
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
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnHire = new System.Windows.Forms.Button();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCreatedBy = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewAllVenues = new System.Windows.Forms.DataGridView();
            this.dataGridViewHiredVenues = new System.Windows.Forms.DataGridView();
            this.btnReview = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllVenues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHiredVenues)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(564, 27);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(72, 40);
            this.btnProfile.TabIndex = 0;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(721, 27);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(119, 40);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnHire
            // 
            this.btnHire.Location = new System.Drawing.Point(863, 506);
            this.btnHire.Name = "btnHire";
            this.btnHire.Size = new System.Drawing.Size(152, 44);
            this.btnHire.TabIndex = 2;
            this.btnHire.Text = "Hire";
            this.btnHire.UseVisualStyleBackColor = true;
            this.btnHire.Click += new System.EventHandler(this.btnHire_Click);
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.Location = new System.Drawing.Point(1094, 506);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(131, 44);
            this.btnCancelBooking.TabIndex = 3;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "List of all venues";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1013, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "List of hired venues";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(950, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Created By";
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Location = new System.Drawing.Point(1046, 421);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Size = new System.Drawing.Size(229, 22);
            this.txtCreatedBy.TabIndex = 9;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(1046, 463);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(88, 22);
            this.txtTitle.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(997, 469);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "title";
            // 
            // dataGridViewAllVenues
            // 
            this.dataGridViewAllVenues.AllowUserToAddRows = false;
            this.dataGridViewAllVenues.AllowUserToDeleteRows = false;
            this.dataGridViewAllVenues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllVenues.Location = new System.Drawing.Point(13, 154);
            this.dataGridViewAllVenues.Name = "dataGridViewAllVenues";
            this.dataGridViewAllVenues.ReadOnly = true;
            this.dataGridViewAllVenues.RowHeadersWidth = 51;
            this.dataGridViewAllVenues.RowTemplate.Height = 24;
            this.dataGridViewAllVenues.Size = new System.Drawing.Size(688, 407);
            this.dataGridViewAllVenues.TabIndex = 12;
            // 
            // dataGridViewHiredVenues
            // 
            this.dataGridViewHiredVenues.AllowUserToAddRows = false;
            this.dataGridViewHiredVenues.AllowUserToDeleteRows = false;
            this.dataGridViewHiredVenues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHiredVenues.Location = new System.Drawing.Point(806, 88);
            this.dataGridViewHiredVenues.Name = "dataGridViewHiredVenues";
            this.dataGridViewHiredVenues.ReadOnly = true;
            this.dataGridViewHiredVenues.RowHeadersWidth = 51;
            this.dataGridViewHiredVenues.RowTemplate.Height = 24;
            this.dataGridViewHiredVenues.Size = new System.Drawing.Size(563, 301);
            this.dataGridViewHiredVenues.TabIndex = 13;
            // 
            // btnReview
            // 
            this.btnReview.Location = new System.Drawing.Point(1272, 537);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(97, 53);
            this.btnReview.TabIndex = 14;
            this.btnReview.Text = "Review";
            this.btnReview.UseVisualStyleBackColor = true;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(129, 117);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(486, 22);
            this.txtSearch.TabIndex = 15;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Search veanue";
            // 
            // VenueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 602);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnReview);
            this.Controls.Add(this.dataGridViewHiredVenues);
            this.Controls.Add(this.dataGridViewAllVenues);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCreatedBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.btnHire);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnProfile);
            this.Name = "VenueForm";
            this.Text = "VenueForm";
            this.Load += new System.EventHandler(this.VenueForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllVenues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHiredVenues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnHire;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCreatedBy;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewAllVenues;
        private System.Windows.Forms.DataGridView dataGridViewHiredVenues;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label5;
    }
}