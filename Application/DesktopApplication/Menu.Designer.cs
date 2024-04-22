namespace DesktopApplication
{
    partial class Menu
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
            pictureBox1 = new PictureBox();
            pnlMenu = new Panel();
            flpMenu = new FlowLayoutPanel();
            pnlMain = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.MainBG1;
            pictureBox1.Location = new Point(-2, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1586, 863);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = SystemColors.ControlDarkDark;
            pnlMenu.BorderStyle = BorderStyle.Fixed3D;
            pnlMenu.Controls.Add(flpMenu);
            pnlMenu.Location = new Point(88, 36);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(309, 774);
            pnlMenu.TabIndex = 1;
            // 
            // flpMenu
            // 
            flpMenu.Location = new Point(15, 14);
            flpMenu.Name = "flpMenu";
            flpMenu.Size = new Size(273, 669);
            flpMenu.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = SystemColors.ControlDarkDark;
            pnlMain.BorderStyle = BorderStyle.Fixed3D;
            pnlMain.Location = new Point(432, 36);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1126, 774);
            pnlMain.TabIndex = 2;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(pnlMain);
            Controls.Add(pnlMenu);
            Controls.Add(pictureBox1);
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel pnlMenu;
        private FlowLayoutPanel flpMenu;
        public Panel pnlMain;
    }
}