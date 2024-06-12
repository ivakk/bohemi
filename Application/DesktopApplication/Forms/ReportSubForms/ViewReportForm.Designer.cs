namespace DesktopApplication.Forms.ReportSubForms
{
    partial class ViewReportForm
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
            tbReporter = new TextBox();
            label1 = new Label();
            tbReported = new TextBox();
            label9 = new Label();
            btnHandle = new Button();
            label5 = new Label();
            tbComment = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightGray;
            groupBox1.Controls.Add(tbReporter);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tbReported);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(btnHandle);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tbComment);
            groupBox1.Font = new Font("Segoe UI", 30F);
            groupBox1.Location = new Point(472, 91);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(481, 403);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "VIEW REPORT";
            // 
            // tbReporter
            // 
            tbReporter.Font = new Font("Segoe UI", 14F);
            tbReporter.Location = new Point(38, 295);
            tbReporter.Multiline = true;
            tbReporter.Name = "tbReporter";
            tbReporter.ReadOnly = true;
            tbReporter.Size = new Size(400, 33);
            tbReporter.TabIndex = 44;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(38, 267);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 43;
            label1.Text = "Reporter";
            // 
            // tbReported
            // 
            tbReported.Font = new Font("Segoe UI", 14F);
            tbReported.Location = new Point(38, 102);
            tbReported.Multiline = true;
            tbReported.Name = "tbReported";
            tbReported.ReadOnly = true;
            tbReported.Size = new Size(400, 33);
            tbReported.TabIndex = 42;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F);
            label9.Location = new Point(38, 74);
            label9.Name = "label9";
            label9.Size = new Size(129, 25);
            label9.TabIndex = 41;
            label9.Text = "Reported user";
            // 
            // btnHandle
            // 
            btnHandle.BackColor = Color.Gold;
            btnHandle.FlatStyle = FlatStyle.Flat;
            btnHandle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnHandle.ForeColor = Color.Black;
            btnHandle.Location = new Point(301, 354);
            btnHandle.Name = "btnHandle";
            btnHandle.Size = new Size(137, 43);
            btnHandle.TabIndex = 13;
            btnHandle.Text = "Handle";
            btnHandle.UseVisualStyleBackColor = false;
            btnHandle.Click += btnAdd_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(38, 140);
            label5.Name = "label5";
            label5.Size = new Size(94, 25);
            label5.TabIndex = 10;
            label5.Text = "Comment";
            // 
            // tbComment
            // 
            tbComment.Font = new Font("Segoe UI", 14F);
            tbComment.Location = new Point(38, 168);
            tbComment.Multiline = true;
            tbComment.Name = "tbComment";
            tbComment.ReadOnly = true;
            tbComment.Size = new Size(400, 97);
            tbComment.TabIndex = 9;
            // 
            // ViewReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1450, 1000);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ViewReportForm";
            Text = "AddMovieForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label5;
        private TextBox tbComment;
        private Button btnHandle;
        private TextBox tbReported;
        private Label label9;
        private TextBox tbReporter;
        private Label label1;
    }
}