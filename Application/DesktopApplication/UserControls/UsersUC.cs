using Classes;
using DesktopApplication.Forms;
using DesktopApplication.Forms.UserSubForms;
using InterfacesLL;
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
    public partial class UsersUC : UserControl
    {
        private readonly IUserService _userService;

        UserForm userForm;
        public Users user { get; set; }
        public UsersUC(Users user, UserForm userForm, IUserService userService)
        {
            InitializeComponent();
            this.user = user;
            this.userForm = userForm;
            this._userService = userService;
        }

        private void UsersUC_Load(object sender, EventArgs e)
        {
            lbEmail.Text = user.Email;
            lbFirstName.Text = user.FirstName;
            lbLastName.Text = user.LastName;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm(userForm, _userService, this.user) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None }; ;
            userForm.menu.ChangeShownForm(addUserForm);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                _userService.DeleteUser(user.Id);
                userForm.LoadUsers(_userService.GetFirstUsers(10));
                userForm.menu.ChangeShownForm(userForm);
            }
        }
    }
}
