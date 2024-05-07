using InterfacesLL;
using DTOs;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DesktopApplication
{
    public partial class Login : Form
    {
        private readonly IUserLL _userLL;
        private readonly IPasswordHashingLL _passwordHashingLL;
        public Login(IUserLL _userLL, IPasswordHashingLL passwordHashingLL)
        {
            InitializeComponent();
            this._userLL = _userLL;
            _passwordHashingLL = passwordHashingLL;
        }

        private void reveal_MouseUp_1(object sender, MouseEventArgs e)
        {
            passwordEntry.PasswordChar = '●';
        }

        private void reveal_MouseDown(object sender, MouseEventArgs e)
        {
            passwordEntry.PasswordChar = '\0';
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (usernameEntry.Text == "" & passwordEntry.Text == "")
            {
                MessageBox.Show("Enter your username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (passwordEntry.Text == "")
            {
                MessageBox.Show("Enter your password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (usernameEntry.Text == "")
            {
                MessageBox.Show("Enter your username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    LoginDTO user = _userLL.CheckUser(usernameEntry.Text, passwordEntry.Text);
                    if (user.Role == "admin" || user.Role == "customer") // make it admin only when ready
                    {

                        Menu menu = new Menu(this, _userLL, _passwordHashingLL);
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("You do not have access!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Your login details are incorrect!");
                }
            }
        }
    }
}
