using System;
using System.Threading.Tasks;
using Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces.General
{
    public interface IUtilities
    {
        Guid CurrentUser { get; set; }
        Task<SavedFile> GetImage(string fileName, IFormFile picture, string folderName = "");
    }
}