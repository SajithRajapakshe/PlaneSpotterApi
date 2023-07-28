using Microsoft.AspNetCore.Http;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterBL.Services
{
    /// <summary>
    /// Interface for image file service
    /// </summary>
    public interface IImageFileService
    {
        string ConvertImageFileToBase64(IFormFile image);
    }
}
