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
    public partial class BanUserForm : Form
    {

        private readonly IUserLL _userLL;

        //In case it is in edit mode
        Users? user { get; set; }

        UserForm userForm;

        public BanUserForm(UserForm userForm, IUserLL userLL)
        {
            this._userLL = userLL;
            this.userForm = userForm;

            InitializeComponent();
        }

        private void btnUnban_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == null || tbReason.Text == null)
            {
                MessageBox.Show("All fields are mandatory!");
            }

            if (_userLL.GetUserByUsername(tbUsername.Text) == null)
            {
                MessageBox.Show("No user exists with username \"" + tbUsername.Text + "\"!");
            }
            else if (_userLL.IsUserBanned(_userLL.GetUserByUsername(tbUsername.Text)) == false)
            {
                _userLL.BanUser(_userLL.GetUserByUsername(tbUsername.Text), tbReason.Text);
                MessageBox.Show("User \"" + tbUsername.Text + "\" has been banned successfully!");
                userForm.menu.ChangeShownForm(userForm);
                userForm.LoadUsers(_userLL.GetAllUsers());
            }
            else if (_userLL.IsUserBanned(_userLL.GetUserByUsername(tbUsername.Text)) == true)
            {
                MessageBox.Show("User \"" + tbUsername.Text + "\" is already banned!");
            }
        }
    }
}
