using AutoMapper;
using PlaneSpotterBL.Models;
using PlaneSpotterDL;
using PlaneSpotterDL.DataModels;
using PlaneSpotterDL.Repositories.AircraftRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterBL.Services
{
    /// <summary>
    /// Service class for aircraft spotter service 
    /// </summary>
    public class AircraftSpotterService : IAircraftSpotterService
    {
        /// <summary>
        /// Inject the required interfaces to de-couple dependencies - Constructor injection.
        /// </summary>
        public readonly IAircraftSpotterRepository _aircraftSpotterRepository;
        private readonly IMapper _mapper;
        public AircraftSpotterService(IAircraftSpotterRepository aircraftSpotterRepository, IMapper mapper)
        {
            _aircraftSpotterRepository = aircraftSpotterRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Creating new spotter record in DB
        /// </summary>
        /// <param name="aircraftDetail"></param>
        /// <returns></returns>
        public async Task CreateSpotterRecord(AircraftSpotterDetailModel aircraftDetail)
        {
            var dataModel = _mapper.Map<AircraftSpotterDataModel>(aircraftDetail);
            dataModel.RecordId = Constants.GetRandomRecordId();
            await _aircraftSpotterRepository.CreateSpotterRecord(dataModel);
        }

        /// <summary>
        /// Deleting spotter record from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AircraftSpotterDetailModel>> DeleteSpotterRecord(Guid id)
        {
            var result = await _aircraftSpotterRepository.DeleteSpotterRecord(id);
            var mappedResult = _mapper.ProjectTo<AircraftSpotterDetailModel>(result.AsQueryable()).ToList();

            return mappedResult;
        }

        /// <summary>
        /// Updating an existing record in the DB
        /// </summary>
        /// <param name="aircraftDetail"></param>
        /// <returns></returns>
        public async Task UpdateSpotterRecord(AircraftSpotterDetailModel aircraftDetail)
        {
            var dataModel = _mapper.Map<AircraftSpotterDataModel>(aircraftDetail);
            await _aircraftSpotterRepository.UpdateSpotterRecord(dataModel);
        }

        /// <summary>
        /// Getting the spotter based on spotter id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AircraftSpotterDetailModel> GetSpotterRecordById(Guid id)
        {
            return _mapper.Map<AircraftSpotterDetailModel>(await _aircraftSpotterRepository.GetSpotterRecordById(id));
        }

        /// <summary>
        /// Getting all spotters from the DB
        /// </summary>
        /// <param name="searchKeyword"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AircraftSpotterDetailModel>> GetAllSpotterRecords(string searchKeyword)
        {
            var result = await _aircraftSpotterRepository.GetAllSpotterRecords(searchKeyword);
            var mappedResult = _mapper.ProjectTo<AircraftSpotterDetailModel>(result.AsQueryable()).ToList();

            return mappedResult;
        }
    }
}
