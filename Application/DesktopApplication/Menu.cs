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
        private EventForm eventForm;
        private ReportForm reportForm;
        private AlcoholForm alcoholForm;

        private readonly IUserService _userService;
        private readonly IAlcoholService _alcoholService;
        private readonly ICommentsService _commentsService;
        private readonly IEventService _eventService;
        private readonly IReportService _reportService;
        private readonly ISoftService _softService;

        public Menu(Login login, IUserService userService, IAlcoholService alcoholService, ICommentsService commentsService, IEventService eventService, IReportService reportService, 
                    ISoftService softService)
        {
            this.login = login;
            //this.loggedInUser = user;
            this._userService = userService;
            this._alcoholService = alcoholService;
            this._commentsService = commentsService;
            this._eventService = eventService;
            this._reportService = reportService;
            this._softService = softService;

            userForm = new UserForm(this, _userService) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            eventForm = new EventForm(this, _eventService) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            reportForm = new ReportForm(this, _reportService, _commentsService, _userService) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            alcoholForm = new AlcoholForm(this, _alcoholService) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            InitializeComponent();
            
            LoadMenuButtons();
        }

        public void LoadMenuButtons()
        {
            menuButtons.Add(new MenuButtonUC("Users", userForm, this));
            menuButtons.Add(new MenuButtonUC("Events", eventForm, this));
            menuButtons.Add(new MenuButtonUC("Reports", reportForm, this));
            menuButtons.Add(new MenuButtonUC("Alcohols", alcoholForm, this));
            menuButtons.Add(new MenuButtonUC("Softs", alcoholForm, this));
            foreach (MenuButtonUC button in menuButtons)
            {
                flpMenu.Controls.Add(button);
            }
        }

        public void ChangeShownForm(Form form)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(form);
            form.Show();
        }
    }
}
