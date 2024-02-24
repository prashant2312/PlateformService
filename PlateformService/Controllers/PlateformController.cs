using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlateformService.Data;
using PlateformService.Dtos;
using PlateformService.Models;

namespace PlateformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateformController : ControllerBase
    {
        private readonly IPlateformRepo _repository;
        private readonly IMapper _mapper;

        public PlateformController(IPlateformRepo repository,IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlateformReadDto>> GetPlateforms()
        {
            Console.WriteLine("-- Getting plateforms");
            var plateformItems=_repository.GetAllPlateforms();
            return Ok(_mapper.Map<IEnumerable<PlateformReadDto>>(plateformItems));
        }
        [HttpGet("{id}",Name = "GetPlateformById")]
        public ActionResult<PlateformReadDto> GetPlateformById(int id)
        {
            var plateformItems=_repository.GetPlateformById(id);
            if (plateformItems != null)
            {
                return Ok(_mapper.Map<PlateformReadDto>(plateformItems));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlateformReadDto> CreatePlateform(PlateformCreateDto plateformCreateDto)
        {
            var plateformModel = _mapper.Map<Plateform>(plateformCreateDto);
            _repository.CreatePlateform(plateformModel);
            _repository.SaveChanges();
            var plateformReadDTO = _mapper.Map<PlateformReadDto>(plateformModel);

            return CreatedAtRoute(nameof(GetPlateformById),new { Id=plateformReadDTO.Id},plateformReadDTO);
        }
    }
}
