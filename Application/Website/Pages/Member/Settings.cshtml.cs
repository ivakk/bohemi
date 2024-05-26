using Classes;
using DTOs;
using InterfacesLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Website.Pages.Member
{
    [Authorize]
    public class SettingsModel : PageModel
    {
        [BindProperty]
        public UpdateUserDTO UpdateUserDTO { get; set; }
        [BindProperty]
        public Users? LoggedInUser { get; set; }
        public bool IsLoggedIn { get; set; }
        public IFormFile UploadedPicture { get; set; }
        public string Message { get; set; }

        private string updatedFirstName;
        private string updatedLastName;
        private string updatedUsername;
        private string updatedEmail;
        private string updatedPhoneNumber;


        private readonly IUserLL _userLL;
        private readonly IPasswordHashingLL _passwordHashingLL;

        public SettingsModel(IUserLL userLL, IPasswordHashingLL passwordHashingLL)
        {
            _userLL = userLL;
            _passwordHashingLL = passwordHashingLL;
        }
        public void OnGet(int id)
        {
            //Checks whether there is a user currently logged in
            if (User.FindFirst("id") != null)
            {
                IsLoggedIn = true;
                LoggedInUser = _userLL.GetUserById(int.Parse(User.FindFirst("id").Value));
            }
        }
        public IActionResult OnPostUploadPicture()
        {
            if (UploadedPicture != null && UploadedPicture.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var extension = Path.GetExtension(UploadedPicture.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    Message = "Invalid file format. Only JPG and PNG are allowed.";
                    return Page();
                }

                byte[] pictureBytes;
                using (var memoryStream = new MemoryStream())
                {
                    UploadedPicture.CopyToAsync(memoryStream);
                    pictureBytes = memoryStream.ToArray();
                }

                LoggedInUser = _userLL.GetUserById(int.Parse(User.FindFirst("id").Value));
                UpdateUserDTO updateUser = _userLL.GetUserForUpdateDTO(LoggedInUser.Id);
                _userLL.UpdateUser(new UpdateUserDTO(LoggedInUser.Id, pictureBytes, LoggedInUser.FirstName, LoggedInUser.LastName, LoggedInUser.Birthday, LoggedInUser.Username,
                    LoggedInUser.Email, updateUser.PasswordHash, updateUser.PasswordSalt, LoggedInUser.PhoneNumber, LoggedInUser.Role));
                Message = "File uploaded and processed successfully.";


                return RedirectToPage(new { id = LoggedInUser.Id });
            }
            return RedirectToPage(new {id = LoggedInUser.Id});
        }
        public IActionResult OnPostDetails()
        {
            if (UpdateUserDTO.Password != null && UpdateUserDTO.Password.Length >= 8 && UpdateUserDTO.Password != UpdateUserDTO.ConfirmPassword)
            {
                ViewData["Error"] = "Passwords don't match!";
                return Page();
            }
            else
            {
                LoggedInUser = _userLL.GetUserById(int.Parse(User.FindFirst("id").Value));
                
                System.Diagnostics.Debug.WriteLine(LoggedInUser.LastName);

                if (UpdateUserDTO.Password != null && UpdateUserDTO.Password.Length >= 8)
                {
                    UpdateUserDTO.PasswordSalt = _passwordHashingLL.PassSalt(10);
                    UpdateUserDTO.PasswordHash = _passwordHashingLL.PassHash(UpdateUserDTO.Password, UpdateUserDTO.PasswordSalt);
                }
                else
                {
                    UpdateUserDTO.PasswordSalt = _userLL.GetUserForUpdateDTO(LoggedInUser.Id).PasswordSalt;
                    UpdateUserDTO.PasswordHash = _userLL.GetUserForUpdateDTO(LoggedInUser.Id).PasswordHash;
                }

                if (UpdateUserDTO.FirstName != null && UpdateUserDTO.FirstName.Length > 0)
                {
                    updatedFirstName = UpdateUserDTO.FirstName;
                }
                else
                {
                    updatedFirstName = LoggedInUser.FirstName;
                }

                if (UpdateUserDTO.LastName != null && UpdateUserDTO.LastName.Length > 0)
                {
                    updatedLastName = UpdateUserDTO.LastName;
                }
                else
                {
                    updatedLastName = LoggedInUser.LastName;
                }

                if (UpdateUserDTO.Username != null && UpdateUserDTO.Username.Length >= 3)
                {
                    updatedUsername = UpdateUserDTO.Username;
                }
                else
                {
                    updatedUsername = LoggedInUser.Username;
                }

                if (UpdateUserDTO.Email != null && UpdateUserDTO.Email.Length > 0)
                {
                    updatedEmail = UpdateUserDTO.Email;
                }
                else
                {
                    updatedEmail = LoggedInUser.Email;
                }

                if (UpdateUserDTO.PhoneNumber != null && UpdateUserDTO.PhoneNumber.Length > 0)
                {
                    updatedPhoneNumber = UpdateUserDTO.PhoneNumber;
                }
                else
                {
                    updatedPhoneNumber = LoggedInUser.PhoneNumber;
                }

                UpdateUserDTO userUpdate = _userLL.GetUserForUpdateDTO(LoggedInUser.Id);
                UpdateUserDTO updateUser = new UpdateUserDTO(LoggedInUser.Id,
                                        LoggedInUser.ProfilePicture,
                                        updatedFirstName,
                                        updatedLastName,
                                        LoggedInUser.Birthday,
                                        updatedUsername,
                                        updatedEmail,
                                        userUpdate.PasswordHash,
                                        userUpdate.PasswordSalt,
                                        updatedPhoneNumber,
                                        LoggedInUser.Role);
                _userLL.UpdateUser(updateUser);
                return RedirectToPage(new { id = LoggedInUser.Id });
            }
        }
        public IActionResult OnGetUserImage()
        {
            if (User.FindFirst("id") != null)
            {
                IsLoggedIn = true;
                LoggedInUser = _userLL.GetUserById(int.Parse(User.FindFirst("id").Value));
            }
            if (LoggedInUser.ProfilePicture != null && LoggedInUser.ProfilePicture.Length > 0)
            {
                // Assume JPEG for simplicity. You might need to store the image format or detect it dynamically.
                return File(LoggedInUser.ProfilePicture, "image/jpeg");
            }
            return NotFound();
        }
    }
}
