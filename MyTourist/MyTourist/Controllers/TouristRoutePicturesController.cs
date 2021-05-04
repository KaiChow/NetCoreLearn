using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTourist.Dtos;
using MyTourist.Models;
using MyTourist.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTourist.Controllers
{
    [Route("api/touristRoutes/{touristRouteId}/pictures")]
    [ApiController]
    public class TouristRoutePicturesController : ControllerBase
    {
        private ITouristRouteRepository _touristRouteRepository;


        public readonly IMapper _mapper;
        public TouristRoutePicturesController(ITouristRouteRepository touristRouteRepository, IMapper imapper)
        {

            _touristRouteRepository = touristRouteRepository ?? throw new ArgumentNullException(nameof(touristRouteRepository));
            _mapper = imapper ?? throw new ArgumentNullException(nameof(imapper));
        }

        [HttpGet]
        public IActionResult GetPictureListForTouristRoute(Guid touristRouteId)
        {

            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }

            var pictureFromRepo = _touristRouteRepository.GetPicturesByTouristRouteId(touristRouteId);

            if (pictureFromRepo == null || pictureFromRepo.Count() <= 0)
            {
                return NotFound("照片不存在不存在");
            }
            return Ok(_mapper.Map<IEnumerable<TouristRoutePictureDto>>(pictureFromRepo));
        }
        [HttpGet("{pictureId}", Name = "GetPicture")]
        public IActionResult GetPicture(Guid touristRouteId, int pictureId)
        {

            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }

            var pictureFronRepo = _touristRouteRepository.GetPicture(pictureId);


            if (pictureFronRepo == null)
            {

                {
                    return NotFound("图片不存在");
                }
            }

            return Ok(_mapper.Map<TouristRoutePictureDto>(pictureFronRepo));
        }


        [HttpPost]
        public IActionResult CreateTouristRoutePicture(
            [FromRoute] Guid touristRouteId,
            [FromBody] TouristRoutePictureForCreationDto touristRoutePictureForCreationDto
            )
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }

            var pictureModel = _mapper.Map<TouristRoutePicture>(touristRoutePictureForCreationDto);

            _touristRouteRepository.AddTouristRoutePicture(touristRouteId, pictureModel);
            _touristRouteRepository.Save();

            var pictureToReturn = _mapper.Map<TouristRoutePictureDto>(pictureModel);


            return CreatedAtRoute(
                "GetPicture",
                new
                {
                    touristRouteId = pictureModel.TouristRouteId,
                    pictureId = pictureModel.Id
                },
                pictureToReturn

               );
        }

    }
}
