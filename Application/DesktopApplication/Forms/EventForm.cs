using LogicLayer;
using Classes;
using DesktopApplication.Forms.EventSubForms;
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

namespace DesktopApplication.Forms
{
    public partial class EventForm : Form
    {
        public Menu menu;
        AddEventForm addEventForm;

        private readonly IEventService _eventService;


        public EventForm(Menu menu, IEventService eventService)
        {
            InitializeComponent();
            _eventService = eventService;

            addEventForm = new EventSubForms.AddEventForm(this, _eventService) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            this.menu = menu;
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            dgvEvents.DataSource = _eventService.GetFirstEvents(10);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvEvents.DataSource = _eventService.GetEventsBySearch(tbSearch.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Event events = (Event)dgvEvents.CurrentRow.DataBoundItem;
            addEventForm.SetEventId(events.Id);
            menu.pnlMain.Controls.Clear();
            this.menu.pnlMain.Controls.Add(addEventForm);
            addEventForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Event events = (Event)dgvEvents.CurrentRow.DataBoundItem;
            _eventService.DeleteEvent(events.Id);
            dgvEvents.DataSource = _eventService.GetFirstEvents(10);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addEventForm.SetEventId(0);
            menu.pnlMain.Controls.Clear();
            this.menu.pnlMain.Controls.Add(addEventForm);
            addEventForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvEvents.DataSource = _eventService.GetFirstEvents(10);
        }
    }
}
