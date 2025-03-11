namespace Event_Management.pages
{
    partial class Profile
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnVenue = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.postVenue = new System.Windows.Forms.GroupBox();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.postVenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(171, 38);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Edit Profile";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnVenue
            // 
            this.btnVenue.Location = new System.Drawing.Point(246, 12);
            this.btnVenue.Name = "btnVenue";
            this.btnVenue.Size = new System.Drawing.Size(90, 38);
            this.btnVenue.TabIndex = 1;
            this.btnVenue.Text = "Venue";
            this.btnVenue.UseVisualStyleBackColor = true;
            this.btnVenue.Click += new System.EventHandler(this.btnVenue_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(698, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 38);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // postVenue
            // 
            this.postVenue.Controls.Add(this.comboCategory);
            this.postVenue.Controls.Add(this.txtCapacity);
            this.postVenue.Controls.Add(this.txtTitle);
            this.postVenue.Controls.Add(this.btnPost);
            this.postVenue.Controls.Add(this.label4);
            this.postVenue.Controls.Add(this.label3);
            this.postVenue.Controls.Add(this.label2);
            this.postVenue.Location = new System.Drawing.Point(63, 73);
            this.postVenue.Name = "postVenue";
            this.postVenue.Size = new System.Drawing.Size(357, 280);
            this.postVenue.TabIndex = 3;
            this.postVenue.TabStop = false;
            this.postVenue.Text = "Post a New Venue";
            // 
            // comboCategory
            // 
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Items.AddRange(new object[] {
            "Academic & Educational Events",
            "Social Events",
            "Cultural & Entertainment Events",
            "Business & Networking Events"});
            this.comboCategory.Location = new System.Drawing.Point(113, 29);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(220, 24);
            this.comboCategory.TabIndex = 8;
            this.comboCategory.Text = "--- Select Category ---";
            // 
            // txtCapacity
            // 
            this.txtCapacity.Location = new System.Drawing.Point(113, 129);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(65, 22);
            this.txtCapacity.TabIndex = 7;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(113, 77);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(100, 22);
            this.txtTitle.TabIndex = 6;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(77, 202);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(197, 30);
            this.btnPost.TabIndex = 4;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Capacity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Category";
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(485, 12);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(171, 38);
            this.btnDeleteAccount.TabIndex = 4;
            this.btnDeleteAccount.Text = "Delete Account";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(546, 123);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(168, 83);
            this.btnDisplay.TabIndex = 7;
            this.btnDisplay.Text = "Display Logged in User Details";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.btnDeleteAccount);
            this.Controls.Add(this.postVenue);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnVenue);
            this.Controls.Add(this.btnEdit);
            this.Name = "Profile";
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.Profile_Load);
            this.postVenue.ResumeLayout(false);
            this.postVenue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnVenue;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.GroupBox postVenue;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnDisplay;
    }
}