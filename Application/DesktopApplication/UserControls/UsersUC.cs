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
        private readonly IUserLL _userLL;
        private readonly IPasswordHashingLL _passwordHashingLL;

        UserForm userForm;
        public Users user { get; set; }
        public UsersUC(Users user, UserForm userForm, IUserLL userLL, IPasswordHashingLL passwordHashingLL)
        {
            InitializeComponent();
            this.user = user;
            this.userForm = userForm;
            this._userLL = userLL;
            this._passwordHashingLL = passwordHashingLL;
        }

        private void UsersUC_Load(object sender, EventArgs e)
        {
            lbEmail.Text = user.Email;
            lbFirstName.Text = user.FirstName;
            lbLastName.Text = user.LastName;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm(userForm, _userLL, _passwordHashingLL, this.user) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None }; ;
            userForm.menu.ChangeShownForm(addUserForm);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                _userLL.DeleteUser(user.Id);
                userForm.LoadUsers(_userLL.GetAllUsers());
                userForm.menu.ChangeShownForm(userForm);
            }
        }
    }
}
