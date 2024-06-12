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


        public ReportForm(Menu menu, IReportService reportService, ICommentsService commentsService, IUserService userService)
        {
            InitializeComponent();
            this._reportService = reportService;
            this._commentsService = commentsService;
            this._userService = userService;

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
            viewReportForm.SetReportId(report.Id);
            menu.pnlMain.Controls.Clear();
            this.menu.pnlMain.Controls.Add(viewReportForm);
            viewReportForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Report report = (Report)dgvReports.CurrentRow.DataBoundItem;
            _reportService.DeleteReport(report.Id);
            dgvReports.DataSource = _reportService.GetAllReports();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvReports.DataSource = _reportService.GetAllReports();
        }
    }
}
