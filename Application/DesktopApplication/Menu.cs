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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace DesktopApplication
{
    public partial class Menu : Form
    {
        public Login login;
        public Users loggedInUser = new Users();
        List <MenuButtonUC> menuButtons = new List <MenuButtonUC>();

        private UserForm userForm;

        public Menu(Users user, Login login)
        {
            InitializeComponent();
            this.login = login;
            this.loggedInUser = user;

            LoadMenuButtons();
        }

        public void LoadMenuButtons()
        {
            menuButtons.Add(new MenuButtonUC("Users", userForm, this));
            flpMenu.Controls.Add(menuButtons[menuButtons.Count - 1]);
        }

    }
}
