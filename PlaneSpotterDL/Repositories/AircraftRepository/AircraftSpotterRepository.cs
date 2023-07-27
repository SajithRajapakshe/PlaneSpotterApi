using Microsoft.EntityFrameworkCore;
using PlaneSpotterDL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterDL.Repositories.AircraftRepository
{
    public class AircraftSpotterRepository : IAircraftSpotterRepository
    {
        private readonly DBContext _dbContext;

        public AircraftSpotterRepository(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task CreateSpotterRecord(AircraftSpotterDataModel aircraftDetail)
        {
            await _dbContext.Set<AircraftSpotterDataModel>().AddAsync(aircraftDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AircraftSpotterDataModel>> DeleteSpotterRecord(Guid id)
        {
            var existingRecord = await GetSpotterRecordById(id);
            _dbContext.Set<AircraftSpotterDataModel>().Remove(existingRecord);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Set<AircraftSpotterDataModel>().ToListAsync();
        }

        public async Task<IEnumerable<AircraftSpotterDataModel>> GetAllSpotterRecords(string searchKeyword)
        {
            return searchKeyword != string.Empty ? 
                await _dbContext.Set<AircraftSpotterDataModel>().Where(x => x.Make == searchKeyword || x.Model == searchKeyword || x.Registration == searchKeyword).ToListAsync()
                   : await _dbContext.Set<AircraftSpotterDataModel>().ToListAsync();
        }

        public async Task<AircraftSpotterDataModel> GetSpotterRecordById(Guid id)
        {
            return await _dbContext.Set<AircraftSpotterDataModel>().FirstOrDefaultAsync(x => x.RecordId == id);
        }

        public async Task UpdateSpotterRecord(AircraftSpotterDataModel aircraftDetail)
        {
            _dbContext.Set<AircraftSpotterDataModel>().Update(aircraftDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}
