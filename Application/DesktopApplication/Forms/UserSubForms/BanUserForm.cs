using Classes;
using InterfacesLL;
using LogicLayer;
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

        private readonly IUserService _userService;

        //In case it is in edit mode
        Users? user { get; set; }

        UserForm userForm;

        public BanUserForm(UserForm userForm, IUserService _userService)
        {
            this._userService = _userService;
            this.userForm = userForm;

            InitializeComponent();
        }

        private void btnUnban_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == null || tbReason.Text == null)
            {
                MessageBox.Show("All fields are mandatory!");
            }

            if (_userService.GetUserByUsername(tbUsername.Text) == null)
            {
                MessageBox.Show("No user exists with username \"" + tbUsername.Text + "\"!");
            }
            else if (_userService.IsUserBanned(_userService.GetUserByUsername(tbUsername.Text)) == false)
            {
                _userService.BanUser(_userService.GetUserByUsername(tbUsername.Text), tbReason.Text);
                MessageBox.Show("User \"" + tbUsername.Text + "\" has been banned successfully!");
                userForm.menu.ChangeShownForm(userForm);
                userForm.LoadUsers(_userService.GetAllUsers());
            }
            else if (_userService.IsUserBanned(_userService.GetUserByUsername(tbUsername.Text)) == true)
            {
                MessageBox.Show("User \"" + tbUsername.Text + "\" is already banned!");
            }
        }
    }
}
