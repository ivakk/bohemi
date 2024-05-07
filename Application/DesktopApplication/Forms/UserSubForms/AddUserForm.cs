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

        private readonly IUserLL _userLL;
        private readonly IPasswordHashingLL _passwordHashingLL;

        //In case it is in edit mode
        Users? user { get; set; }
        RegisterDTO newUser { get; set; }
        UpdateUserDTO updateUser { get; set; }

        UserForm userForm;

        public AddUserForm(UserForm userForm, IUserLL userLL, IPasswordHashingLL passwordHashingLL)
        {
            this._userLL = userLL;
            this._passwordHashingLL = passwordHashingLL;

            this.userForm = userForm;
            InitializeComponent();
        }

        public AddUserForm(UserForm userForm, IUserLL userLL, IPasswordHashingLL passwordHashingLL, Users user)
        {
            this._userLL = userLL;
            this._passwordHashingLL = passwordHashingLL;

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
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbFirstName.Text == null || tbLastName.Text == null || tbUsername.Text == null || tbEmail.Text == null || dtpbirthday.Text == null)
            {
                MessageBox.Show("All fields are mandatory!");
            }
            else
            {
                if (!_userLL.IsEmail(tbEmail.Text))
                {
                    MessageBox.Show("Enter a valid email address!");
                }
                else if (tbPhoneNumber.Text != "" && !_userLL.IsPhoneNumber(tbPhoneNumber.Text))
                {
                    MessageBox.Show("Enter a valid phone number!");
                }
                else if (user == null)
                {
                    string passwordSalt = _passwordHashingLL.PassSalt(10);
                    string passwordHash = _passwordHashingLL.PassHash("password", passwordSalt);


                    if (_userLL.IsUsernameUsed(tbUsername.Text) == true)
                    {
                        MessageBox.Show("The username \"" + tbUsername.Text + "\" is already in use by another user!");
                    }
                    else if (_userLL.IsEmailUsed(tbEmail.Text) == true)
                    {
                        MessageBox.Show("The email address \"" + tbEmail.Text + "\" is already in use by another user!");
                    }
                    else if (_userLL.IsUsernameUsed(tbUsername.Text) == false)
                    {
                        RegisterDTO user = new RegisterDTO(0,
                        tbFirstName.Text,
                        tbLastName.Text,
                        dtpbirthday.Value,
                        tbUsername.Text,
                        tbEmail.Text,
                        passwordHash,
                        passwordSalt,
                        tbPhoneNumber.Text,
                        "admin");
                        bool success = _userLL.CreateUser(user);
                        if (success)
                        {
                            userForm.menu.ChangeShownForm(userForm);
                        }
                    }
                }
                else if (user != null)
                {
                    if (_userLL.IsUsernameUsed(tbUsername.Text) == true && tbUsername.Text != user.Username)
                    {
                        MessageBox.Show("The username \"" + tbUsername.Text + "\" is already in use by another user!");
                    }
                    else if (_userLL.IsEmailUsed(tbEmail.Text) == true && tbEmail.Text != user.Email)
                    {
                        MessageBox.Show("The email address \"" + tbEmail.Text + "\" is already in use by another user!");
                    }
                    else
                    {
                        updateUser = _userLL.GetUserForUpdateDTO(user.Id);
                        UpdateUserDTO updatedUser = new UpdateUserDTO(updateUser.Id,
                        ImageToByteArray(pbPfp),
                        tbFirstName.Text,
                        tbLastName.Text,
                        dtpbirthday.Value,
                        tbUsername.Text,
                        tbEmail.Text,
                        updateUser.PasswordHash,
                        updateUser.PasswordSalt,
                        updateUser.PhoneNumber,
                        updateUser.Role);

                        bool success = _userLL.UpdateUser(updatedUser);
                        if (success)
                        {
                            userForm.menu.ChangeShownForm(userForm);
                        }
                    }
                }
                userForm.LoadUsers(_userLL.GetAllUsers());
            }
        }

        private void btnUploadPfp_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images files (*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbPfp.Image = new Bitmap(openFileDialog.FileName);
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

        private void btnRemovePfp_Click(object sender, EventArgs e)
        {
            pbPfp.Image = Properties.Resources.defaultPfp;
        }
    }
}
