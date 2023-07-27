using PlaneSpotterDL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterDL.Repositories.AircraftRepository
{
    public interface IAircraftSpotterRepository
    {
        Task CreateSpotterRecord(AircraftSpotterDataModel aircraftDetail);
        Task<IEnumerable<AircraftSpotterDataModel>> DeleteSpotterRecord(Guid id);
        Task<IEnumerable<AircraftSpotterDataModel>> GetAllSpotterRecords(string searchKeyword);
        Task UpdateSpotterRecord(AircraftSpotterDataModel aircraftDetail);
        Task<AircraftSpotterDataModel> GetSpotterRecordById(Guid id);
    }
}
