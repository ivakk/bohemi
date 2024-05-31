using Classes;
using InterfacesLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApplication.Forms.UserSubForms
{
    public partial class UnbanUserForm : Form
    {

        private readonly IUserService _userLL;

        UserForm userForm;

        public UnbanUserForm(UserForm userForm, IUserService userLL)
        {
            InitializeComponent();
            this._userLL = userLL;
            this.userForm = userForm;
        }

        private void btnUnban_Click(object sender, EventArgs e)
        {
            Users user = _userLL.GetUserByUsername(tbUsername.Text);
            if (tbUsername.Text == null)
            {
                MessageBox.Show("Username field is mandatory!");
            }

            if (_userLL.GetUserByUsername(tbUsername.Text) == null)
            {
                MessageBox.Show("No user exists with username " + tbUsername.Text + "!");
            }
            else if (_userLL.IsUserBanned(_userLL.GetUserByUsername(tbUsername.Text)) == false)
            {
                MessageBox.Show("User \"" + tbUsername.Text + "\" is not currently banned!");
                MessageBox.Show(user.Id.ToString());
            }
            else if (_userLL.IsUserBanned(_userLL.GetUserByUsername(tbUsername.Text)) == true)
            {
                _userLL.UnbanUser(_userLL.GetUserByUsername(tbUsername.Text));
                MessageBox.Show("User \"" + tbUsername.Text + "\" has been unbanned successfully!");
                MessageBox.Show(user.Id.ToString());
                userForm.LoadUsers(_userLL.GetAllUsers());
            }
        }
    }
}
