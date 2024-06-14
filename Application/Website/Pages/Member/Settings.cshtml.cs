using Classes;
using CustomExceptions;
using DTOs;
using InterfacesLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Linq;

namespace Website.Pages.Member
{
    [Authorize]
    public class SettingsModel : PageModel
    {
        [BindProperty]
        public UpdateUserDTO? UpdateUserDTO { get; set; }
        [BindProperty]
        public Users? LoggedInUser { get; set; }
        public bool IsLoggedIn { get; set; }
        public IFormFile? UploadedPicture { get; set; }

        private string? updatedFirstName;
        private string? updatedLastName;
        private string? updatedUsername;
        private string? updatedEmail;
        private string? updatedPhoneNumber;
        private string? updatedPassword;


        private readonly IUserService _userService;

        public SettingsModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet(int id)
        {
            //Checks whether there is a user currently logged in
            if (User.FindFirst("id") != null)
            {
                IsLoggedIn = true;
                LoggedInUser = _userService.GetUserById(int.Parse(User.FindFirst("id").Value));
                if (_userService.IsUserBanned(_userService.GetUserById(int.Parse(User.FindFirst("id").Value))))
                {
                    RedirectToPage("/Logout");
                }
            }
        }
        public IActionResult OnPostUploadPicture()
        {
            if (UploadedPicture != null && UploadedPicture.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var extension = Path.GetExtension(UploadedPicture.FileName).ToLowerInvariant();
                LoggedInUser = _userService.GetUserById(int.Parse(User.FindFirst("id").Value));

                if (!allowedExtensions.Contains(extension))
                {
                    ViewData["Error"] = "Invalid file format. Only JPG and PNG are allowed.";
                    return RedirectToPage(new { id = LoggedInUser.Id });
                }

                byte[] pictureBytes;
                using (var memoryStream = new MemoryStream())
                {
                    UploadedPicture.CopyToAsync(memoryStream);
                    pictureBytes = memoryStream.ToArray();
                }

                

                _userService.UpdateUser(new UpdateUserDTO(LoggedInUser.Id, pictureBytes, LoggedInUser.FirstName, LoggedInUser.LastName, LoggedInUser.Birthday, LoggedInUser.Username,
                    LoggedInUser.Email, "oaijsnfoiahnofsafgnasaosnfoaiosabfnaofsn", LoggedInUser.PhoneNumber, LoggedInUser.Role));


                return RedirectToPage(new { id = LoggedInUser.Id });
            }
            return RedirectToPage(new {id = LoggedInUser.Id});
        }
        public IActionResult OnPostDetails()
        {

            try 
            {
                if (UpdateUserDTO.Password != null && UpdateUserDTO.Password.Length >= 8 && UpdateUserDTO.Password != UpdateUserDTO.ConfirmPassword)
                {
                    ViewData["Error"] = "Passwords don't match!";
                    return Page();
                }
                else
                {
                    LoggedInUser = _userService.GetUserById(int.Parse(User.FindFirst("id").Value));

                    if (UpdateUserDTO.Password != null && UpdateUserDTO.Password.Length >= 8)
                    {
                        updatedPassword = UpdateUserDTO.Password;
                    }
                    else
                    {
                        updatedPassword = "oaijsnfoiahnofsafgnasaosnfoaiosabfnaofsn";
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

                    UpdateUserDTO updateUser = new UpdateUserDTO(LoggedInUser.Id,
                                            LoggedInUser.ProfilePicture,
                                            updatedFirstName,
                                            updatedLastName,
                                            LoggedInUser.Birthday,
                                            updatedUsername,
                                            updatedEmail,
                                            updatedPassword,
                                            updatedPhoneNumber,
                                            LoggedInUser.Role);
                    
                    bool success = _userService.UpdateUser(updateUser);

                    if (success)
                    {
                        return RedirectToPage(new { id = LoggedInUser.Id });
                    }
                    else
                    {
                        return RedirectToPage(new { id = LoggedInUser.Id });
                    }
                }
            }
            catch (UsernameUsedException)
            {
                ViewData["Error"] = "Username is already in use!";
                return Page();
            }
            catch (EmailUsedException)
            {
                ViewData["Error"] = "Email address is already in use!";
                return Page();
            }
            catch (Exception)
            {
                ViewData["Error"] = "Something went wrong!";
                return Page();
            }

        }
        public IActionResult OnGetUserImage()
        {
            if (User.FindFirst("id") != null)
            {
                IsLoggedIn = true;
                LoggedInUser = _userService.GetUserById(int.Parse(User.FindFirst("id").Value));
            }
            if (LoggedInUser.ProfilePicture != null && LoggedInUser.ProfilePicture.Length > 0)
            {
                return File(LoggedInUser.ProfilePicture, "image/jpeg");
            }
            return NotFound();
        }
    }
}
