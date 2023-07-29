using Microsoft.AspNetCore.Mvc;
using PlaneSpotterBL.Models;
using PlaneSpotterBL.Services;
using System;

namespace PlaneSpotterApi.Controllers
{
    [ApiController]
    public class AircraftSpotterController : ControllerBase
    {

        private readonly IAircraftSpotterService _service;
        private readonly IImageFileService _imageFileService;

        /// <summary>
        /// Injecting dependencies of separate services
        /// </summary>
        /// <param name="service"></param>
        /// <param name="imageFileService"></param>
        public AircraftSpotterController(IAircraftSpotterService service, IImageFileService imageFileService)
        {
            _service = service;
            _imageFileService = imageFileService;
        }

        /// <summary>
        /// Api function to Get the list of aircraft spotters with/without search term
        /// </summary>
        /// <param name="searchKeyword"></param>
        /// <returns></returns>
        [Route("getAllAircraftSpotters")]
        [HttpGet]
        public async Task<IEnumerable<AircraftSpotterDetailModel>> GetAllAircraftSpotters(string searchKeyword = "")
        {
            return await _service.GetAllSpotterRecords(searchKeyword);
        }

        /// <summary>
        /// Api function to creating a new spotter record
        /// </summary>
        /// <param name="aircraftSpotterDetail"></param>
        /// <returns></returns>
        [Route("createNewSpotter")]
        [HttpPost]
        public async Task CreateNewSpotter([FromForm] AircraftSpotterDetailModel aircraftSpotterDetail)
        {
            if (aircraftSpotterDetail.FormFile != null)
            {
                var base64Image = _imageFileService.ConvertImageFileToBase64(aircraftSpotterDetail.FormFile);
                aircraftSpotterDetail.FilePath = base64Image;
            }
            await _service.CreateSpotterRecord(aircraftSpotterDetail);
        }

        /// <summary>
        /// Api function to get aircraft spotter by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("getAircraftSpotterById")]
        [HttpGet]
        public async Task<AircraftSpotterDetailModel> GetAircraftSpotterById(Guid id)
        {
            return await _service.GetSpotterRecordById(id);
        }

        /// <summary>
        /// Api function to update aircraft spotter
        /// </summary>
        /// <param name="aircraftSpotterDetail"></param>
        /// <returns></returns>
        [Route("updateAircraftSpotter")]
        [HttpPost]
        public async Task UpdateAircraftSpotter([FromForm] AircraftSpotterDetailModel aircraftSpotterDetail)
        {
            if (aircraftSpotterDetail.FormFile != null)
            {
                var base64Image = _imageFileService.ConvertImageFileToBase64(aircraftSpotterDetail.FormFile);
                aircraftSpotterDetail.FilePath = base64Image;
            }
            await _service.UpdateSpotterRecord(aircraftSpotterDetail);
        }

        /// <summary>
        /// Api function to delete aircraft spotter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("deleteAircraftSpotter")]
        [HttpPost]
        public async Task<IEnumerable<AircraftSpotterDetailModel>> DeleteAircraftSpotter(Guid id)
        {
            return await _service.DeleteSpotterRecord(id);
        }
    }
}