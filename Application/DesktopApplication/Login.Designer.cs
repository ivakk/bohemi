namespace DesktopApplication
{
    partial class Login
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
            usernameEntry = new TextBox();
            passwordEntry = new TextBox();
            reveal = new PictureBox();
            buttonSubmit = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reveal).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Desktop;
            pictureBox1.Location = new Point(0, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(801, 453);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // usernameEntry
            // 
            usernameEntry.Location = new Point(282, 249);
            usernameEntry.Name = "usernameEntry";
            usernameEntry.Size = new Size(232, 23);
            usernameEntry.TabIndex = 1;
            // 
            // passwordEntry
            // 
            passwordEntry.Location = new Point(282, 330);
            passwordEntry.Name = "passwordEntry";
            passwordEntry.PasswordChar = '●';
            passwordEntry.Size = new Size(232, 23);
            passwordEntry.TabIndex = 2;
            // 
            // reveal
            // 
            reveal.Image = Properties.Resources.show;
            reveal.Location = new Point(518, 330);
            reveal.Name = "reveal";
            reveal.Size = new Size(25, 23);
            reveal.TabIndex = 8;
            reveal.TabStop = false;
            reveal.MouseDown += reveal_MouseDown;
            reveal.MouseUp += reveal_MouseUp_1;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Location = new Point(350, 359);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(100, 41);
            buttonSubmit.TabIndex = 9;
            buttonSubmit.Text = "Login";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSubmit);
            Controls.Add(reveal);
            Controls.Add(passwordEntry);
            Controls.Add(usernameEntry);
            Controls.Add(pictureBox1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)reveal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox usernameEntry;
        private TextBox passwordEntry;
        private PictureBox reveal;
        private Button buttonSubmit;
    }
}