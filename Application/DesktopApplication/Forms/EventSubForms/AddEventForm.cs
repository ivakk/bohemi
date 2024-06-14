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

namespace DesktopApplication.Forms.EventSubForms
{
    public partial class AddEventForm : Form
    {
        private readonly IEventService _eventService;
        EventForm eventForm;

        private int eventId;
        public AddEventForm(EventForm eventForm, IEventService _eventService)
        {
            InitializeComponent();
            this.eventForm = eventForm;
            this._eventService = _eventService;
        }


        public void SetEventId(int id)
        {
            if (id == 0)
            {
                eventId = 0;
                tbTitle.Text = "";
                tbDescription.Text = "";
                dtpDate.Value = DateTime.Now;
                pbPicture.Image = Properties.Resources.defaultPfp;
            }
            else
            {
                Event curEvent = _eventService.GetEventById(id);
                eventId = curEvent.Id;
                tbTitle.Text = curEvent.Title;
                tbDescription.Text = curEvent.Description;
                dtpDate.Value = curEvent.Day;
                pbPicture.Image = ByteArrayToImage(curEvent.Picture);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbTitle.Text == "" || tbDescription.Text == "" || dtpDate.Text == "" || pbPicture == null)
            {
                MessageBox.Show("All fields are required!");
            }
            else
            {
                EventDTO events = new EventDTO(eventId, tbTitle.Text, tbDescription.Text,
                    dtpDate.Value, ImageToByteArray(pbPicture));
                if (eventId == 0)
                {
                    bool success = _eventService.CreateEvent(events);
                    if (success)
                    {
                        eventForm.menu.ChangeShownForm(eventForm);
                        this.Hide();
                        eventForm.dgvEvents.DataSource = _eventService.GetFirstEvents(10);
                    }
                }
                else
                {
                    bool success = _eventService.UpdateEvent(events);
                    if (success)
                    {
                        eventForm.menu.ChangeShownForm(eventForm);
                        this.Hide();
                        eventForm.dgvEvents.DataSource = _eventService.GetFirstEvents(10);
                    }
                }
            }
        }

        private byte[] ImageToByteArray(PictureBox picBox)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap bmpImage = new Bitmap(picBox.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;
            try
            {
                using (MemoryStream ms = new MemoryStream(byteArray))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Failed to convert byte array to image: " + ex.Message);
                return null;
            }
        }

        private void btnUploadPfp_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images files (*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbPicture.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void btnRemovePfp_Click(object sender, EventArgs e)
        {
            pbPicture.Image = Properties.Resources.defaultPfp;
        }
    }
}
