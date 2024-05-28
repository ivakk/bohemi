using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;
using DesktopApplication.Forms;
using DesktopApplication.UserControls;
using InterfacesLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace DesktopApplication
{
    public partial class Menu : Form
    {
        public Login login;
        public Users loggedInUser = new Users();
        List <MenuButtonUC> menuButtons = new List <MenuButtonUC>();

        private UserForm userForm;

        private readonly IUserLL _userLL;

        public Menu(Login login, IUserLL userLL)
        {
            this.login = login;
            //this.loggedInUser = user;
            this._userLL = userLL;

            userForm = new UserForm(this, _userLL) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            InitializeComponent();
            
            LoadMenuButtons();
        }

        public void LoadMenuButtons()
        {
            menuButtons.Add(new MenuButtonUC("Users", userForm, this));
            flpMenu.Controls.Add(menuButtons[menuButtons.Count - 1]);
        }

        public void ChangeShownForm(Form form)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(form);
            form.Show();
        }
    }
}
