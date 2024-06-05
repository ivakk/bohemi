using Classes;
using DesktopApplication.Properties;
using DTOs;
using InterfacesLL;
using LogicLayer;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApplication.Forms.UserSubForms
{
    public partial class AddUserForm : Form
    {

        private readonly IUserService _userService;

        //In case it is in edit mode
        Users? user { get; set; }
        private Image originalImage;

        UserForm userForm;

        public AddUserForm(UserForm userForm, IUserService _userService)
        {
            this._userService = _userService;

            this.userForm = userForm;
            InitializeComponent();
        }

        public AddUserForm(UserForm userForm, IUserService _userService, Users user)
        {
            this._userService = _userService;

            this.userForm = userForm;
            this.user = user;
            InitializeComponent();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            if (user != null)
            {
                tbUsername.Text = user.Username;
                tbFirstName.Text = user.FirstName;
                tbLastName.Text = user.LastName;
                tbEmail.Text = user.Email;
                dtpbirthday.Value = user.Birthday;
                tbPhoneNumber.Text = user.PhoneNumber;
                if (user.ProfilePicture != null && user.ProfilePicture.Length > 0)
                {
                    pbPfp.Image = ByteArrayToImage(user.ProfilePicture);
                }
                else
                {
                    pbPfp.Image = Properties.Resources.defaultPfp;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbFirstName.Text == "" || tbLastName.Text == "" || tbUsername.Text == "" || tbEmail.Text == "" || dtpbirthday.Text == "")
            {
                MessageBox.Show("All fields are mandatory!");
            }
            else
            {
                if (!_userService.IsEmail(tbEmail.Text))
                {
                    MessageBox.Show("Enter a valid email address!");
                }
                else if (tbPhoneNumber.Text != "" && !_userService.IsPhoneNumber(tbPhoneNumber.Text))
                {
                    MessageBox.Show("Enter a valid phone number!");
                }
                else if (user == null)
                {
                    try
                    {
                        RegisterDTO user = new RegisterDTO(0,
                        tbFirstName.Text,
                        tbLastName.Text,
                        dtpbirthday.Value,
                        tbUsername.Text,
                        tbEmail.Text,
                        "password",
                        tbPhoneNumber.Text,
                        "admin");
                        bool success = _userService.CreateUser(user);
                        if (success)
                        {
                            userForm.menu.ChangeShownForm(userForm);
                        }
                    }
                    catch (ApplicationException)
                    {
                        MessageBox.Show("The username \"" + tbUsername.Text + "\" is already in use by another user!");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("The email address \"" + tbEmail.Text + "\" is already in use by another user!");
                    }
                }
                else if (user != null)
                {
                    try
                    {
                        UpdateUserDTO updatedUser = new UpdateUserDTO(user.Id,
                        ImageToByteArray(pbPfp),
                        tbFirstName.Text,
                        tbLastName.Text,
                        dtpbirthday.Value,
                        tbUsername.Text,
                        tbEmail.Text,
                        "oaijsnfoiahnofsafgnasaosnfoaiosabfnaofsn",
                        tbPhoneNumber.Text,
                        user.Role);

                        bool success = _userService.UpdateUser(updatedUser);
                        if (success)
                        {
                            userForm.menu.ChangeShownForm(userForm);
                        }
                    }
                    catch (ApplicationException)
                    {
                        MessageBox.Show("The username \"" + tbUsername.Text + "\" is already in use by another user!");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("The email address \"" + tbEmail.Text + "\" is already in use by another user!");
                    }
                }
                userForm.LoadUsers(_userService.GetFirstUsers(10));
            }
        }

        private void btnUploadPfp_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images files (*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalImage = Image.FromFile(openFileDialog.FileName);
                pbPfp.Image = new Bitmap(originalImage);
                pbPfp.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private byte[] ImageToByteArray(PictureBox picBox)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                originalImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
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
                return Properties.Resources.defaultPfp;
            }
        }

        private void btnRemovePfp_Click(object sender, EventArgs e)
        {
            pbPfp.Image = Properties.Resources.defaultPfp;
        }
    }
}
