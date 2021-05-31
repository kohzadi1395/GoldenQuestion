using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces.General;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class Utilities : IUtilities
    {
        private readonly string[] _acceptedFileTypes = {".jpg", ".jpeg", ".png", ".gif"};

        public Guid CurrentUser { get; set; }

        public async Task<SavedFile> GetImage(string fileName, IFormFile picture, string folderName = "")
        {
            if (picture == null
                || picture.Length == 0
                || picture.Length == 0
                || picture.Length > 10 * 1024 * 1024
                || _acceptedFileTypes.All(s => s != Path.GetExtension(picture.FileName).ToLower()))
                return null;

            //var resourcesFolderName = Path.Combine("Resources", "Images");
            //if (string.IsNullOrEmpty(folderName) == false)
            //    resourcesFolderName = Path.Combine(resourcesFolderName, folderName);
            //var uploadFilesPath = Path.Combine(Directory.GetCurrentDirectory(), resourcesFolderName);

            //if (!Directory.Exists(uploadFilesPath))
            //    Directory.CreateDirectory(uploadFilesPath);

            //fileName += Path.GetExtension(picture.FileName);
            //var filePath = Path.Combine(uploadFilesPath, fileName);
            //await using (var stream = new FileStream(filePath, FileMode.Create))
            //{
            //    await picture.CopyToAsync(stream);
            //}
            await using var memoryStream = new MemoryStream();
            await picture.CopyToAsync(memoryStream);

            return new SavedFile
            {
                File = memoryStream.ToArray(),
                FilePath = ""
            };
        }

        public Guid GetCurrentUser(Guid UserId)
        {
            CurrentUser = UserId;
            return CurrentUser;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                    RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}