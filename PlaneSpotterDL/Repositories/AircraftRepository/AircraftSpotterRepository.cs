using Microsoft.EntityFrameworkCore;
using PlaneSpotterDL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterDL.Repositories.AircraftRepository
{
    /// <summary>
    /// Repository for Aircraft spotter db operations
    /// </summary>
    public class AircraftSpotterRepository : IAircraftSpotterRepository
    {
        private readonly DBContext _dbContext;

        public AircraftSpotterRepository(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Creates a new record in DB
        /// </summary>
        /// <param name="aircraftDetail"></param>
        /// <returns></returns>
        public async Task CreateSpotterRecord(AircraftSpotterDataModel aircraftDetail)
        {
            await _dbContext.Set<AircraftSpotterDataModel>().AddAsync(aircraftDetail);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a spotter record from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AircraftSpotterDataModel>> DeleteSpotterRecord(Guid id)
        {
            var existingRecord = await GetSpotterRecordById(id);
            _dbContext.Set<AircraftSpotterDataModel>().Remove(existingRecord);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Set<AircraftSpotterDataModel>().ToListAsync();
        }

        /// <summary>
        /// Get all spotter details from DB
        /// </summary>
        /// <param name="searchKeyword"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AircraftSpotterDataModel>> GetAllSpotterRecords(string searchKeyword)
        {
            return searchKeyword != string.Empty ? 
                await _dbContext.Set<AircraftSpotterDataModel>().Where(x => x.Make == searchKeyword || x.Model == searchKeyword || x.Registration == searchKeyword).ToListAsync()
                   : await _dbContext.Set<AircraftSpotterDataModel>().ToListAsync();
        }

        /// <summary>
        /// Get a spotter record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AircraftSpotterDataModel> GetSpotterRecordById(Guid id)
        {
            return await _dbContext.Set<AircraftSpotterDataModel>().FirstOrDefaultAsync(x => x.RecordId == id);
        }


        /// <summary>
        /// Edit a spotter record in the db
        /// </summary>
        /// <param name="aircraftDetail"></param>
        /// <returns></returns>
        public async Task UpdateSpotterRecord(AircraftSpotterDataModel aircraftDetail)
        {
            _dbContext.Set<AircraftSpotterDataModel>().Update(aircraftDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}
