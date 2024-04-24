namespace DesktopApplication.Forms.UserSubForms
{
    partial class UnbanUserForm
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
            label3 = new Label();
            btnUnban = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightGray;
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(tbUsername);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnUnban);
            groupBox1.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(249, 150);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(520, 231);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "UNBAN USER";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(51, 80);
            label11.Name = "label11";
            label11.Size = new Size(97, 25);
            label11.TabIndex = 34;
            label11.Text = "Username";
            // 
            // tbUsername
            // 
            tbUsername.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbUsername.Location = new Point(53, 108);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(400, 32);
            tbUsername.TabIndex = 33;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(53, 545);
            label10.Name = "label10";
            label10.Size = new Size(0, 25);
            label10.TabIndex = 31;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(53, 507);
            label9.Name = "label9";
            label9.Size = new Size(0, 25);
            label9.TabIndex = 29;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(53, 465);
            label8.Name = "label8";
            label8.Size = new Size(0, 25);
            label8.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(53, 350);
            label3.Name = "label3";
            label3.Size = new Size(0, 25);
            label3.TabIndex = 20;
            // 
            // btnUnban
            // 
            btnUnban.BackColor = Color.FromArgb(117, 54, 112);
            btnUnban.FlatStyle = FlatStyle.Flat;
            btnUnban.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnUnban.ForeColor = Color.WhiteSmoke;
            btnUnban.Location = new Point(316, 146);
            btnUnban.Name = "btnUnban";
            btnUnban.Size = new Size(137, 43);
            btnUnban.TabIndex = 13;
            btnUnban.Text = "Unban";
            btnUnban.UseVisualStyleBackColor = false;
            btnUnban.Click += btnUnban_Click;
            // 
            // UnbanUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1450, 1000);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UnbanUserForm";
            Text = "UnbanUserForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnUnban;
        private Label label3;
        private Label label8;
        private Label label10;
        private Label label9;
        private Label label11;
        private TextBox tbUsername;
    }
}