namespace DesktopApplication.Forms
{
    partial class UserForm
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
            btnUnbanLoad = new Button();
            btnBanLoad = new Button();
            btnAdd = new Button();
            lblBrand = new Label();
            btnSearch = new Button();
            tbSearch = new TextBox();
            flpUsers = new FlowLayoutPanel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightGray;
            groupBox1.Controls.Add(btnUnbanLoad);
            groupBox1.Controls.Add(btnBanLoad);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(lblBrand);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(tbSearch);
            groupBox1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1102, 195);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "SEARCH";
            // 
            // btnUnbanLoad
            // 
            btnUnbanLoad.BackColor = Color.Gold;
            btnUnbanLoad.FlatStyle = FlatStyle.Flat;
            btnUnbanLoad.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnUnbanLoad.ForeColor = Color.Black;
            btnUnbanLoad.Location = new Point(408, 122);
            btnUnbanLoad.Name = "btnUnbanLoad";
            btnUnbanLoad.Size = new Size(188, 43);
            btnUnbanLoad.TabIndex = 13;
            btnUnbanLoad.Text = "Unban a User";
            btnUnbanLoad.UseVisualStyleBackColor = false;
            btnUnbanLoad.Click += btnUnbanLoad_Click;
            // 
            // btnBanLoad
            // 
            btnBanLoad.BackColor = Color.Gold;
            btnBanLoad.FlatStyle = FlatStyle.Flat;
            btnBanLoad.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnBanLoad.ForeColor = Color.Black;
            btnBanLoad.Location = new Point(215, 122);
            btnBanLoad.Name = "btnBanLoad";
            btnBanLoad.Size = new Size(154, 43);
            btnBanLoad.TabIndex = 12;
            btnBanLoad.Text = "Ban a User";
            btnBanLoad.UseVisualStyleBackColor = false;
            btnBanLoad.Click += button1_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Gold;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnAdd.ForeColor = Color.Black;
            btnAdd.Location = new Point(26, 122);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(154, 43);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Add User";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblBrand.Location = new Point(230, 123);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(0, 37);
            lblBrand.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Gold;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(959, 57);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(137, 43);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // tbSearch
            // 
            tbSearch.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            tbSearch.Location = new Point(26, 55);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(927, 43);
            tbSearch.TabIndex = 1;
            // 
            // flpUsers
            // 
            flpUsers.Location = new Point(88, 233);
            flpUsers.Name = "flpUsers";
            flpUsers.Size = new Size(939, 517);
            flpUsers.TabIndex = 15;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1126, 774);
            Controls.Add(flpUsers);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserForm";
            Text = "Users";
            Load += UsersForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button btnAdd;
        private Label lblBrand;
        private Button btnSearch;
        private TextBox tbSearch;
        private FlowLayoutPanel flpUsers;
        private Button btnUnbanLoad;
        private Button btnBanLoad;
        private VScrollBar vScrollBar1;
    }
}