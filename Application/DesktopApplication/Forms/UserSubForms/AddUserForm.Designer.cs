namespace DesktopApplication.Forms.UserSubForms
{
    partial class AddUserForm
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
            label11 = new Label();
            tbUsername = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            dtpbirthday = new DateTimePicker();
            label3 = new Label();
            tbEmail = new TextBox();
            label4 = new Label();
            tbLastName = new TextBox();
            label2 = new Label();
            btnAdd = new Button();
            tbFirstName = new TextBox();
            label1 = new Label();
            tbPhoneNumber = new TextBox();
            label5 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightGray;
            groupBox1.Controls.Add(tbPhoneNumber);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(tbUsername);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(dtpbirthday);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbEmail);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbLastName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(tbFirstName);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 30F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(500, 590);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "ADD/EDIT USER";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14F);
            label11.Location = new Point(49, 131);
            label11.Name = "label11";
            label11.Size = new Size(97, 25);
            label11.TabIndex = 34;
            label11.Text = "Username";
            // 
            // tbUsername
            // 
            tbUsername.Font = new Font("Segoe UI", 14F);
            tbUsername.Location = new Point(51, 159);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(400, 32);
            tbUsername.TabIndex = 33;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14F);
            label10.Location = new Point(53, 545);
            label10.Name = "label10";
            label10.Size = new Size(0, 25);
            label10.TabIndex = 31;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F);
            label9.Location = new Point(53, 507);
            label9.Name = "label9";
            label9.Size = new Size(0, 25);
            label9.TabIndex = 29;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F);
            label8.Location = new Point(53, 465);
            label8.Name = "label8";
            label8.Size = new Size(0, 25);
            label8.TabIndex = 27;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(49, 465);
            label6.Name = "label6";
            label6.Size = new Size(86, 25);
            label6.TabIndex = 25;
            label6.Text = "Birthday:";
            // 
            // dtpbirthday
            // 
            dtpbirthday.Font = new Font("Segoe UI", 14F);
            dtpbirthday.Format = DateTimePickerFormat.Short;
            dtpbirthday.ImeMode = ImeMode.NoControl;
            dtpbirthday.Location = new Point(175, 465);
            dtpbirthday.Name = "dtpbirthday";
            dtpbirthday.Size = new Size(276, 32);
            dtpbirthday.TabIndex = 24;
            dtpbirthday.Value = new DateTime(2023, 11, 7, 12, 0, 0, 0);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(53, 350);
            label3.Name = "label3";
            label3.Size = new Size(0, 25);
            label3.TabIndex = 20;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 14F);
            tbEmail.Location = new Point(51, 348);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(400, 32);
            tbEmail.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(51, 320);
            label4.Name = "label4";
            label4.Size = new Size(128, 25);
            label4.TabIndex = 16;
            label4.Text = "Email address";
            // 
            // tbLastName
            // 
            tbLastName.Font = new Font("Segoe UI", 14F);
            tbLastName.Location = new Point(51, 285);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(400, 32);
            tbLastName.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(51, 257);
            label2.Name = "label2";
            label2.Size = new Size(100, 25);
            label2.TabIndex = 14;
            label2.Text = "Last Name";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(117, 54, 112);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnAdd.ForeColor = Color.WhiteSmoke;
            btnAdd.Location = new Point(314, 534);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(137, 43);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Add/Edit";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // tbFirstName
            // 
            tbFirstName.Font = new Font("Segoe UI", 14F);
            tbFirstName.Location = new Point(51, 222);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(400, 32);
            tbFirstName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(51, 194);
            label1.Name = "label1";
            label1.Size = new Size(102, 25);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            // 
            // tbPhoneNumber
            // 
            tbPhoneNumber.Font = new Font("Segoe UI", 14F);
            tbPhoneNumber.Location = new Point(51, 414);
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.Size = new Size(400, 32);
            tbPhoneNumber.TabIndex = 36;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(49, 386);
            label5.Name = "label5";
            label5.Size = new Size(140, 25);
            label5.TabIndex = 35;
            label5.Text = "Phone Number";
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1450, 1000);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddUserForm";
            Text = "AddUserForm";
            Load += AddUserForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnAdd;
        private TextBox tbFirstName;
        private Label label1;
        private TextBox tbEmail;
        private Label label4;
        private TextBox tbLastName;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpbirthday;
        private Label label6;
        private Label label8;
        private Label label10;
        private Label label9;
        private Label label11;
        private TextBox tbUsername;
        private TextBox tbPhoneNumber;
        private Label label5;
    }
}