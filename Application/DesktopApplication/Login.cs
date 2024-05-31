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
        private readonly IUserService _userService;
        private readonly IAlcoholService _alcoholService;
        private readonly ICommentsService _commentsService;
        private readonly IEventService _eventService;
        private readonly IReportService _reportService;
        private readonly IReservationService _reservationService;
        private readonly ISoftService _softService;

        public Login(IUserService _userService, IAlcoholService _alcoholService, ICommentsService _commentsService, IEventService eventService, IReportService reportService, 
                     IReservationService reservationService, ISoftService softService)
        {
            InitializeComponent();
            this._userService = _userService;
            this._alcoholService = _alcoholService;
            this._commentsService = _commentsService;
            this._eventService = eventService;
            this._reportService = reportService;
            this._reservationService = reservationService;
            this._softService = softService;
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
                    UserDTO user = _userService.CheckUser(usernameEntry.Text, passwordEntry.Text);

                    if (user.Role == "admin")
                    {

                        Menu menu = new Menu(this, _userService, _alcoholService, _commentsService, _eventService, _reportService, _reservationService, _softService);
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("You do not have access!");
                    }
                }
                catch (ApplicationException)
                {
                    MessageBox.Show("You are currently banned!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Your login details are incorrect!");
                }
            }
        }
    }
}
