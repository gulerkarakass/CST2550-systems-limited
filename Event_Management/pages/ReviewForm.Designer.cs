namespace Event_Management.pages
{
    partial class ReviewForm
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
            this.dataGridViewHiredVenues = new System.Windows.Forms.DataGridView();
            this.comboRating = new System.Windows.Forms.ComboBox();
            this.txtCreatedBy = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReview = new System.Windows.Forms.Button();
            this.dataGridVewReviews = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHiredVenues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVewReviews)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHiredVenues
            // 
            this.dataGridViewHiredVenues.AllowUserToAddRows = false;
            this.dataGridViewHiredVenues.AllowUserToDeleteRows = false;
            this.dataGridViewHiredVenues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHiredVenues.Location = new System.Drawing.Point(12, 365);
            this.dataGridViewHiredVenues.Name = "dataGridViewHiredVenues";
            this.dataGridViewHiredVenues.ReadOnly = true;
            this.dataGridViewHiredVenues.RowHeadersWidth = 51;
            this.dataGridViewHiredVenues.RowTemplate.Height = 24;
            this.dataGridViewHiredVenues.Size = new System.Drawing.Size(948, 256);
            this.dataGridViewHiredVenues.TabIndex = 1;
            // 
            // comboRating
            // 
            this.comboRating.FormattingEnabled = true;
            this.comboRating.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboRating.Location = new System.Drawing.Point(1401, 403);
            this.comboRating.Name = "comboRating";
            this.comboRating.Size = new System.Drawing.Size(46, 24);
            this.comboRating.TabIndex = 3;
            this.comboRating.Text = "5";
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Location = new System.Drawing.Point(1097, 365);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Size = new System.Drawing.Size(253, 22);
            this.txtCreatedBy.TabIndex = 4;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(1097, 433);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(253, 22);
            this.txtTitle.TabIndex = 5;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(1097, 473);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(350, 131);
            this.txtNote.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1004, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Created By";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1045, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1349, 411);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rating";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1026, 473);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Review";
            // 
            // btnReview
            // 
            this.btnReview.Location = new System.Drawing.Point(1318, 616);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(129, 34);
            this.btnReview.TabIndex = 11;
            this.btnReview.Text = "Submit";
            this.btnReview.UseVisualStyleBackColor = true;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // dataGridVewReviews
            // 
            this.dataGridVewReviews.AllowUserToAddRows = false;
            this.dataGridVewReviews.AllowUserToDeleteRows = false;
            this.dataGridVewReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVewReviews.Location = new System.Drawing.Point(12, 48);
            this.dataGridVewReviews.Name = "dataGridVewReviews";
            this.dataGridVewReviews.ReadOnly = true;
            this.dataGridVewReviews.RowHeadersWidth = 51;
            this.dataGridVewReviews.RowTemplate.Height = 24;
            this.dataGridVewReviews.Size = new System.Drawing.Size(1277, 273);
            this.dataGridVewReviews.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "List of Hired Venues By you";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(615, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Reviews";
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1470, 662);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridVewReviews);
            this.Controls.Add(this.btnReview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtCreatedBy);
            this.Controls.Add(this.comboRating);
            this.Controls.Add(this.dataGridViewHiredVenues);
            this.Name = "ReviewForm";
            this.Text = "ReviewForm";
            this.Load += new System.EventHandler(this.ReviewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHiredVenues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVewReviews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewHiredVenues;
        private System.Windows.Forms.ComboBox comboRating;
        private System.Windows.Forms.TextBox txtCreatedBy;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.DataGridView dataGridVewReviews;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}