namespace DesktopApplication.Forms.AlcoholSubForms
{
    partial class AddAlcoholForm
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
            nudPercentage = new NumericUpDown();
            label4 = new Label();
            nudPrice = new NumericUpDown();
            label1 = new Label();
            nudAge = new NumericUpDown();
            label3 = new Label();
            nudSize = new NumericUpDown();
            label2 = new Label();
            btnRemovePfp = new Button();
            tbName = new TextBox();
            btnUploadPfp = new Button();
            label9 = new Label();
            pbPicture = new PictureBox();
            ProfilePicture = new Label();
            btnAdd = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPercentage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightGray;
            groupBox1.Controls.Add(nudPercentage);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(nudPrice);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(nudAge);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(nudSize);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnRemovePfp);
            groupBox1.Controls.Add(tbName);
            groupBox1.Controls.Add(btnUploadPfp);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(pbPicture);
            groupBox1.Controls.Add(ProfilePicture);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Font = new Font("Segoe UI", 30F);
            groupBox1.Location = new Point(461, 67);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(480, 676);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "ADD/EDIT AN ALCOHOL";
            // 
            // nudPercentage
            // 
            nudPercentage.Font = new Font("Segoe UI", 14F);
            nudPercentage.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudPercentage.Location = new Point(38, 241);
            nudPercentage.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudPercentage.Name = "nudPercentage";
            nudPercentage.Size = new Size(174, 32);
            nudPercentage.TabIndex = 65;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(38, 213);
            label4.Name = "label4";
            label4.Size = new Size(119, 25);
            label4.TabIndex = 64;
            label4.Text = "Percentage *";
            // 
            // nudPrice
            // 
            nudPrice.Font = new Font("Segoe UI", 14F);
            nudPrice.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudPrice.Location = new Point(264, 241);
            nudPrice.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(174, 32);
            nudPrice.TabIndex = 63;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(264, 213);
            label1.Name = "label1";
            label1.Size = new Size(67, 25);
            label1.TabIndex = 62;
            label1.Text = "Price *";
            // 
            // nudAge
            // 
            nudAge.Font = new Font("Segoe UI", 14F);
            nudAge.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudAge.Location = new Point(264, 168);
            nudAge.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudAge.Name = "nudAge";
            nudAge.Size = new Size(174, 32);
            nudAge.TabIndex = 61;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(264, 140);
            label3.Name = "label3";
            label3.Size = new Size(119, 25);
            label3.TabIndex = 60;
            label3.Text = "Age (years) *";
            // 
            // nudSize
            // 
            nudSize.Font = new Font("Segoe UI", 14F);
            nudSize.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudSize.Location = new Point(38, 168);
            nudSize.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudSize.Name = "nudSize";
            nudSize.Size = new Size(174, 32);
            nudSize.TabIndex = 59;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(38, 140);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 58;
            label2.Text = "Size (ml) *";
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
            // tbName
            // 
            tbName.Font = new Font("Segoe UI", 14F);
            tbName.Location = new Point(38, 102);
            tbName.Multiline = true;
            tbName.Name = "tbName";
            tbName.Size = new Size(400, 33);
            tbName.TabIndex = 42;
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
            label9.Size = new Size(75, 25);
            label9.TabIndex = 41;
            label9.Text = "Name *";
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
            // AddAlcoholForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1450, 1000);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddAlcoholForm";
            Text = "AddMovieForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPercentage).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnAdd;
        private TextBox tbName;
        private Label label9;
        private Button btnRemovePfp;
        private Button btnUploadPfp;
        private PictureBox pbPicture;
        private Label ProfilePicture;
        private Label label2;
        private NumericUpDown nudSize;
        private NumericUpDown nudAge;
        private Label label3;
        private NumericUpDown nudPercentage;
        private Label label4;
        private NumericUpDown nudPrice;
        private Label label1;
    }
}