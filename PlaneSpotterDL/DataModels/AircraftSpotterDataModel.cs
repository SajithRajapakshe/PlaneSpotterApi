using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterDL.DataModels
{
    /// <summary>
    /// Date model for Aircraft Spotter
    /// </summary>
    public class AircraftSpotterDataModel
    {
        [Key]
        public Guid RecordId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Location { get; set; }
        public DateTime SpottedDate { get; set; }
        public string? FilePath { get; set; }
    }
}
