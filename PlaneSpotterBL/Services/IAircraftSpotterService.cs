using PlaneSpotterBL.Models;
using PlaneSpotterDL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterBL.Services
{
    public interface IAircraftSpotterService
    {
        Task CreateSpotterRecord(AircraftSpotterDetailModel aircraftDetail);
        Task<IEnumerable<AircraftSpotterDetailModel>> DeleteSpotterRecord(Guid id);
        Task UpdateSpotterRecord(AircraftSpotterDetailModel aircraftDetail);
        Task<AircraftSpotterDetailModel> GetSpotterRecordById(Guid id);
        Task<IEnumerable<AircraftSpotterDetailModel>> GetAllSpotterRecords(string searchKeyword);
    }
}
