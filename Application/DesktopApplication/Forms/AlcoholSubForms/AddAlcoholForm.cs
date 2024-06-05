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
                tbName.Text = "";
                nudAge.Text = "";
                nudPercentage.Text = "";
                nudPrice.Text = "";
                nudSize.Text = "";
                pbPicture.Image = Properties.Resources.defaultPfp;
            }
            else
            {
                Alcohol curAlcohol = _alcoholService.GetAlcoholById(id);
                tbName.Text = curAlcohol.Name;
                nudAge.Text = curAlcohol.Age.ToString();
                nudPercentage.Text = curAlcohol.Percentage.ToString();
                nudPrice.Text = curAlcohol.Price.ToString();
                nudSize.Text = curAlcohol.Size.ToString();
                pbPicture.Image = ByteArrayToImage(curAlcohol.Picture);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || nudAge.Text == "" || nudPercentage.Text == "" || nudPrice.Text == "" || nudSize.Text == "" || pbPicture == null)
            {
                MessageBox.Show("All fields are required!");
            }
            else
            {
                AlcoholDTO alcohol = new AlcoholDTO(alcoholId, ImageToByteArray(pbPicture), tbName.Text, Convert.ToInt32(nudSize.Value),
                    Convert.ToDecimal(nudPrice.Value), Convert.ToInt32(nudPercentage.Value), Convert.ToInt32(nudAge.Value));
                if (alcoholId == 0)
                {
                    bool success = _alcoholService.CreateAlcohol(alcohol);
                    try
                    {
                        if (success)
                        {
                            alcoholForm.menu.ChangeShownForm(alcoholForm);
                            this.Hide();
                            alcoholForm.dgvAlcohols.DataSource = _alcoholService.GetAlcoholsBySearch("");
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }
                else
                {
                    bool success = _alcoholService.UpdateAlcohol(alcohol);
                    if (success)
                    {
                        alcoholForm.menu.ChangeShownForm(alcoholForm);
                        this.Hide();
                        alcoholForm.dgvAlcohols.DataSource = _alcoholService.GetAlcoholsBySearch("");
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
