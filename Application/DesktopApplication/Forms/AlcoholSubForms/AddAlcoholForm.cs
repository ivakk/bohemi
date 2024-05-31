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

namespace DesktopApplication.Forms.AlcoholSubForms
{
    public partial class AddAlcoholForm : Form
    {
        private readonly IAlcoholService _alcoholService;
        AlcoholForm alcoholForm;

        private int alcoholId;
        public AddAlcoholForm(AlcoholForm alcoholForm, IAlcoholService _alcoholService)
        {
            InitializeComponent();
            this.alcoholForm = alcoholForm;
            this._alcoholService = _alcoholService;
        }


        public void SetAlcoholId(int id)
        {
            if (id == 0)
            {
                alcoholId = 0;
                tbTitle.Text = "";
                tbDescription.Text = "";
                dtpDate.Value = DateTime.Now;
                pbPicture.Image = Properties.Resources.defaultPfp;
            }
            else
            {
                Alcohol curAlcohol = _alcoholService.GetAlcoholById(id);
                //eventId = curEvent.Id;
                //tbTitle.Text = curEvent.Title;
                //tbDescription.Text = curEvent.Description;
                //dtpDate.Value = curEvent.Day;
                //pbPicture.Image = ByteArrayToImage(curEvent.Picture);
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
        //            bool success = _alcoholService.UpdateAlcohol(events);
        //            if (success)
        //            {
        //                alcoholForm.menu.ChangeShownForm(alcoholForm);
        //                this.Hide();
        //                alcoholForm.dgvAlcohols.DataSource = _alcoholService.GetAlcoholsBySearch("");
        //            }
        //        }
        //    }
        //}

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
