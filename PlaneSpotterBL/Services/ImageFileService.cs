using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterBL.Services
{
    /// <summary>
    /// Image file service
    /// </summary>
    public class ImageFileService : IImageFileService
    {
        /// <summary>
        /// Converts the form file into base 64 string
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public string ConvertImageFileToBase64(IFormFile image)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                image.CopyToAsync(ms);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}
