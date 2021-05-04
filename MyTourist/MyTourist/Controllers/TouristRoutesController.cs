using MyTourist.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTourist.Dtos;
using MyTourist.Models;
using AutoMapper;
using System.Text.RegularExpressions;
using MyTourist.ResourceParamaters;

namespace FakexXie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private ITouristRouteRepository _touristRouteRepository;


        public readonly IMapper _mapper;
        public TouristRoutesController(ITouristRouteRepository touristRouteRepository, IMapper imapper)
        {

            _touristRouteRepository = touristRouteRepository;
            _mapper = imapper;
        }
        [HttpGet]
        [HttpHead]

        /**
         * [FromQuery(Name ="")]  字段不一样
         * FromQuery  FromBody
         * 
         * **/
        public IActionResult GetTouristRoutes(
            [FromQuery] TouristRouteResourceParamaters paramaters
            //上面的取代[FromQuery] string keyword, string rating
            )
        {
            // rating   lessThan  lagerThan  equalTo  lessThan3 equalTo5


            var touristRoutesFromRepo = _touristRouteRepository.GetTouristRoutes(paramaters.Keyword, paramaters.RatingOperator, paramaters.Ratingvalue);
            if (touristRoutesFromRepo == null || touristRoutesFromRepo.Count() <= 0)
            {

                return NotFound("没有旅游路线");
            }

            var touristRouteDto = _mapper.Map<IEnumerable<TouristTouteDto>>(touristRoutesFromRepo);
            return Ok(touristRouteDto);
        }


        [HttpGet("{touristRouteId}",Name = "GetTouristRoutesById")]
        [HttpHead]
        public IActionResult GetTouristRoutesById(Guid touristRouteId)
        {
            var touristRoutesFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);
            if (touristRoutesFromRepo == null)
            {
                return NotFound("没有旅游路线");
            }

            var touristTouteDto = _mapper.Map<TouristTouteDto>(touristRoutesFromRepo);
            return Ok(touristTouteDto);
        }

        [HttpPost]

        public IActionResult CreateTouristRoute([FromBody] TouristRouteForCreationDto touristRouteForCreationDto)
        {
            var touristRouteModel = _mapper.Map<TouristRoute>(touristRouteForCreationDto);
            _touristRouteRepository.AddTouristRoute(touristRouteModel);
            _touristRouteRepository.Save();
            var touristRouteToReturn = _mapper.Map<TouristTouteDto>(touristRouteModel);

            return CreatedAtRoute("GetTouristRoutesById",new { touristRouteId = touristRouteToReturn.Id},
                touristRouteToReturn);
        }
    }
}
