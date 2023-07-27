using Microsoft.AspNetCore.Mvc;
using PlaneSpotterBL.Models;
using PlaneSpotterBL.Services;
using System;

namespace PlaneSpotterApi.Controllers
{
    [ApiController]
    public class AircraftSpotterController : ControllerBase
    {
        private readonly ILogger<AircraftSpotterController> _logger;
        private readonly IAircraftSpotterService _service;

        public AircraftSpotterController(ILogger<AircraftSpotterController> logger, IAircraftSpotterService service)
        {
            _logger = logger;
            _service = service;
        }


        [Route("getAllAircraftSpotters")]
        [HttpGet]
        public async Task<IEnumerable<AircraftSpotterDetailModel>> GetAllAircraftSpotters(string searchKeyword = "")
        {
            return await _service.GetAllSpotterRecords(searchKeyword);
        }


        [Route("createNewSpotter")]
        [HttpPost]
        public async Task CreateNewSpotter([FromForm] AircraftSpotterDetailModel aircraftSpotterDetail)
        {
            await _service.CreateSpotterRecord(aircraftSpotterDetail);
        }


        [Route("getAircraftSpotterById")]
        [HttpGet]
        public async Task<AircraftSpotterDetailModel> GetAircraftSpotterById(Guid id)
        {
            return await _service.GetSpotterRecordById(id);
        }

        [Route("updateAircraftSpotter")]
        [HttpPost]
        public async Task UpdateAircraftSpotter([FromForm] AircraftSpotterDetailModel aircraftSpotterDetail)
        {
            await _service.UpdateSpotterRecord(aircraftSpotterDetail);
        }

        [Route("deleteAircraftSpotter")]
        [HttpPost]
        public async Task<IEnumerable<AircraftSpotterDetailModel>> DeleteAircraftSpotter(Guid id)
        {
            return await _service.DeleteSpotterRecord(id);
        }
    }
}