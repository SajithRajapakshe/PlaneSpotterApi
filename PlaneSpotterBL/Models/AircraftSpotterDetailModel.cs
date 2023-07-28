using Microsoft.AspNetCore.Http;
using PlaneSpotterBL.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PlaneSpotterBL.Models
{
    /// <summary>
    /// Base Business model for setting / getting aircraft details
    /// </summary>
    public class AircraftSpotterDetailModel
    {
        public Guid RecordId { get; set; }
        [Required]
        [StringLength(128)]
        public string Make { get; set; }

        [Required]
        [StringLength(128)]
        public string Model { get; set; }

        [Required]
        [RegistrationNumberValidator]
        public string Registration { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [SpottedDateValidator]
        public DateTime SpottedDate { get; set; }

        public string FilePath { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
