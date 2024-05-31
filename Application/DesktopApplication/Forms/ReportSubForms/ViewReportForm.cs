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
        public ViewReportForm(ReportForm reportForm, IReportService _reportService, ICommentsService _commentsService, IUserService _userService)
        {
            InitializeComponent();
            this.reportForm = reportForm;
            this._reportService = _reportService;
            this._commentsService = _commentsService;
            this._userService = _userService;
        }


        public void SetMovieId(int id)
        {
            if (id == 0)
            {
                reportId = 0;
                tbTitle.Text = "";
                tbDescription.Text = "";
                dtpDate.Value = DateTime.Now;
                pbPicture.Image = Properties.Resources.defaultPfp;
            }
            else
            {
                Report curReport = _reportService.GetReportById(id);
                //eventId = curEvent.Id;
                //tbTitle.Text = curEvent.Title;
                //tbDescription.Text = curEvent.Description;
                //dtpDate.Value = curEvent.Day;
            }
        }
        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (tbTitle.Text == "" || tbDescription.Text == "" || dtpDate.Text == "" || pbPicture == null)
        //    {
        //        MessageBox.Show("All fields are required!");
        //    }
        //    else
        //    {
        //        EventDTO events = new EventDTO(eventId, tbTitle.Text, tbDescription.Text,
        //            dtpDate.Value, ImageToByteArray(pbPicture));
        //        if (eventId == 0)
        //        {
        //            bool success = _eventLL.CreateEvent(events);
        //            if (success)
        //            {
        //                eventForm.menu.ChangeShownForm(eventForm);
        //                this.Hide();
        //                eventForm.dgvEvents.DataSource = _eventLL.GetEventsBySearch("");
        //            }
        //        }
        //        else
        //        {
        //            bool success = _eventLL.UpdateEvent(events);
        //            if (success)
        //            {
        //                eventForm.menu.ChangeShownForm(eventForm);
        //                this.Hide();
        //                eventForm.dgvEvents.DataSource = _eventLL.GetEventsBySearch("");
        //            }
        //        }
        //    }
        //}
    }
}
