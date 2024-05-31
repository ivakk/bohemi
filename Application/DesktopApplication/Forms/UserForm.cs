using DesktopApplication.UserControls;
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
using DesktopApplication.Forms.UserSubForms;
using Classes;
using System.Diagnostics;

namespace DesktopApplication.Forms
{
    public partial class UserForm : Form
    {
        public Menu menu;
        AddUserForm addUserForm;
        BanUserForm banUserForm;
        UnbanUserForm unbanUserForm;


        private readonly IUserService _userService;

        public UserForm(Menu menu, IUserService userService)
        {
            InitializeComponent();
            this.menu = menu;
            this._userService = userService;
            addUserForm = new AddUserForm(this, _userService) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            banUserForm = new BanUserForm(this, _userService) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            unbanUserForm = new UnbanUserForm(this, _userService) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            menu.pnlMain.Controls.Clear();
            this.menu.pnlMain.Controls.Add(addUserForm);
            addUserForm.Show();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadUsers(_userService.GetFirst10Users());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers(_userService.GetUsersBySearch(tbSearch.Text));
        }

        public void LoadUsers(List<Users> users)
        {
            flpUsers.Controls.Clear();
            foreach (Users user in users)
            {
                UsersUC userControl = new UsersUC(user, this, this._userService);
                flpUsers.Controls.Add(userControl);
                userControl.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu.ChangeShownForm(banUserForm);
        }

        private void btnUnbanLoad_Click(object sender, EventArgs e)
        {
            menu.ChangeShownForm(unbanUserForm);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.flpUsers.Top = -this.vScrollBar1.Value;
        }
    }
}
