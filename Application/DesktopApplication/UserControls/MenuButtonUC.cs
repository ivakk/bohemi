using DesktopApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApplication.UserControls
{
    public partial class MenuButtonUC : UserControl
    {
        public string ButtonText;
        public Form AssosiatedForm;
        private Menu menu;

        public MenuButtonUC(string buttonText, Form assosiatedForm, Menu menu)
        {
            InitializeComponent();
            ButtonText = buttonText;
            AssosiatedForm = assosiatedForm;
            this.menu = menu;
            Button.Text = buttonText;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            menu.pnlMain.Controls.Clear();
            this.menu.pnlMain.Controls.Add(AssosiatedForm);
            AssosiatedForm.Show();
        }
    }
}
