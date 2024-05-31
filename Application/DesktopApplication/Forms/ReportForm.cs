using LogicLayer;
using Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfacesLL;
using DataAccessLayer;
using Microsoft.VisualBasic.Devices;
using DesktopApplication.Forms.ReportSubForms;

namespace DesktopApplication.Forms
{
    public partial class ReportForm : Form
    {
        public Menu menu;
        ViewReportForm viewReportForm;

        private readonly IReportService _reportService;
        private readonly ICommentsService _commentsService;
        private readonly IUserService _userService;


        public ReportForm(Menu menu, IReportService _reportService, ICommentsService _commentsService, IUserService _userService)
        {
            InitializeComponent();
            this._reportService = _reportService;
            this._commentsService = _commentsService;
            this._userService = _userService;

            viewReportForm = new ReportSubForms.ViewReportForm(this, _reportService, _commentsService, _userService) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            this.menu = menu;
        }

        private void MovieForm_Load(object sender, EventArgs e)
        {
            dgvReports.DataSource = _reportService.GetAllReports();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Report report = (Report)dgvReports.CurrentRow.DataBoundItem;
            //viewReportForm.SetMovieId(events.Id);
            menu.pnlMain.Controls.Clear();
            this.menu.pnlMain.Controls.Add(viewReportForm);
            viewReportForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Event events = (Event)dgvReports.CurrentRow.DataBoundItem;
            _reportService.DeleteReport(events.Id);
            dgvReports.DataSource = _reportService.GetAllReports();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //viewReportForm.SetMovieId(0);
            menu.pnlMain.Controls.Clear();
            this.menu.pnlMain.Controls.Add(viewReportForm);
            viewReportForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvReports.DataSource = _reportService.GetAllReports();
        }
    }
}
