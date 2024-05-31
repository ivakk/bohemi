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

        private readonly IEventService _eventLL;


        public EventForm(Menu menu, IEventService eventLL)
        {
            InitializeComponent();
            _eventLL = eventLL;

            addEventForm = new EventSubForms.AddEventForm(this, _eventLL) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            this.menu = menu;
        }

        private void MovieForm_Load(object sender, EventArgs e)
        {
            dgvEvents.DataSource = _eventLL.GetAllEvents();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvEvents.DataSource = _eventLL.GetEventsBySearch(tbSearch.Text);
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
            _eventLL.DeleteEvent(events.Id);
            dgvEvents.DataSource = _eventLL.GetAllEvents();
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
            dgvEvents.DataSource = _eventLL.GetEventsBySearch("");
        }
    }
}
