using AutoMapper;
using PlaneSpotterBL.Models;
using PlaneSpotterDL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterBL.Mappers
{
    /// <summary>
    /// Mapping of objects between business and data models
    /// </summary>
    public class ObjectMapper : Profile
    {
        public ObjectMapper()
        {
            //Two way mapping of Data Model and Business Model
            CreateMap<AircraftSpotterDetailModel, AircraftSpotterDataModel>().ReverseMap();
        }
    }
}
