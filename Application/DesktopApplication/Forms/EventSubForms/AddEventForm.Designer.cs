namespace DesktopApplication.Forms.EventSubForms
{
    partial class AddEventForm
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            btnRemovePfp = new Button();
            dtpDate = new DateTimePicker();
            tbTitle = new TextBox();
            btnUploadPfp = new Button();
            label9 = new Label();
            pbPicture = new PictureBox();
            ProfilePicture = new Label();
            btnAdd = new Button();
            label5 = new Label();
            tbDescription = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightGray;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnRemovePfp);
            groupBox1.Controls.Add(dtpDate);
            groupBox1.Controls.Add(tbTitle);
            groupBox1.Controls.Add(btnUploadPfp);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(pbPicture);
            groupBox1.Controls.Add(ProfilePicture);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tbDescription);
            groupBox1.Font = new Font("Segoe UI", 30F);
            groupBox1.Location = new Point(472, 91);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(481, 654);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "ADD/EDIT AN EVENT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(38, 268);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 56;
            label1.Text = "Date *";
            // 
            // btnRemovePfp
            // 
            btnRemovePfp.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRemovePfp.Location = new Point(331, 509);
            btnRemovePfp.Name = "btnRemovePfp";
            btnRemovePfp.Size = new Size(75, 23);
            btnRemovePfp.TabIndex = 55;
            btnRemovePfp.Text = "Remove";
            btnRemovePfp.UseVisualStyleBackColor = true;
            btnRemovePfp.Click += btnRemovePfp_Click;
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Segoe UI", 14F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.ImeMode = ImeMode.NoControl;
            dtpDate.Location = new Point(38, 296);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(400, 32);
            dtpDate.TabIndex = 51;
            dtpDate.Value = new DateTime(2023, 11, 7, 12, 0, 0, 0);
            // 
            // tbTitle
            // 
            tbTitle.Font = new Font("Segoe UI", 14F);
            tbTitle.Location = new Point(38, 102);
            tbTitle.Multiline = true;
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(400, 33);
            tbTitle.TabIndex = 42;
            // 
            // btnUploadPfp
            // 
            btnUploadPfp.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUploadPfp.Location = new Point(331, 480);
            btnUploadPfp.Name = "btnUploadPfp";
            btnUploadPfp.Size = new Size(75, 23);
            btnUploadPfp.TabIndex = 54;
            btnUploadPfp.Text = "Upload";
            btnUploadPfp.UseVisualStyleBackColor = true;
            btnUploadPfp.Click += btnUploadPfp_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F);
            label9.Location = new Point(38, 74);
            label9.Name = "label9";
            label9.Size = new Size(61, 25);
            label9.TabIndex = 41;
            label9.Text = "Title *";
            // 
            // pbPicture
            // 
            pbPicture.BorderStyle = BorderStyle.FixedSingle;
            pbPicture.Location = new Point(119, 361);
            pbPicture.Name = "pbPicture";
            pbPicture.Size = new Size(200, 200);
            pbPicture.SizeMode = PictureBoxSizeMode.Zoom;
            pbPicture.TabIndex = 53;
            pbPicture.TabStop = false;
            // 
            // ProfilePicture
            // 
            ProfilePicture.AutoSize = true;
            ProfilePicture.Font = new Font("Segoe UI", 14F);
            ProfilePicture.Location = new Point(38, 361);
            ProfilePicture.Name = "ProfilePicture";
            ProfilePicture.Size = new Size(75, 25);
            ProfilePicture.TabIndex = 52;
            ProfilePicture.Text = "Picture:";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Gold;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnAdd.ForeColor = Color.Black;
            btnAdd.Location = new Point(301, 588);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(137, 43);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(38, 140);
            label5.Name = "label5";
            label5.Size = new Size(121, 25);
            label5.TabIndex = 10;
            label5.Text = "Description *";
            // 
            // tbDescription
            // 
            tbDescription.Font = new Font("Segoe UI", 14F);
            tbDescription.Location = new Point(38, 168);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(400, 97);
            tbDescription.TabIndex = 9;
            // 
            // AddEventForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1450, 1000);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddEventForm";
            Text = "AddMovieForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label5;
        private TextBox tbDescription;
        private Button btnAdd;
        private TextBox tbTitle;
        private Label label9;
        private Label label1;
        private Button btnRemovePfp;
        private DateTimePicker dtpDate;
        private Button btnUploadPfp;
        private PictureBox pbPicture;
        private Label ProfilePicture;
    }
}