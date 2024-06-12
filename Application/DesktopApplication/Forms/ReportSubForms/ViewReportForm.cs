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
using Microsoft.Extensions.Logging;
using DTOs;
using Microsoft.VisualBasic.ApplicationServices;

namespace DesktopApplication.Forms.ReportSubForms
{
    public partial class ViewReportForm : Form
    {
        private readonly IReportService _reportService;
        private readonly ICommentsService _commentsService;
        private readonly IUserService _userService;
        ReportForm reportForm;

        private int reportId;
        Report curReport;
        public ViewReportForm(ReportForm reportForm, IReportService _reportService, ICommentsService _commentsService, IUserService _userService)
        {
            InitializeComponent();
            this.reportForm = reportForm;
            this._reportService = _reportService;
            this._commentsService = _commentsService;
            this._userService = _userService;
        }


        public void SetReportId(int id)
        {
            curReport = _reportService.GetReportById(id);
            reportId = curReport.Id;
            tbReported.Text = _commentsService.GetCommentById(curReport.CommentId).Username;
            tbComment.Text = _commentsService.GetCommentById(curReport.CommentId).Information;
            tbReporter.Text = _userService.GetUserById(curReport.ReporterId).Username;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool success = _reportService.UpdateReport(new ReportDTO(reportId, curReport.CommentId, curReport.ReporterId, true));
            if (success)
            {
                reportForm.menu.ChangeShownForm(reportForm);
                this.Hide();
                reportForm.dgvReports.DataSource = _reportService.GetAllReports();
            }
        }
    }
}
