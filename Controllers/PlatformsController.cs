using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;

namespace PlatformService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatfromReadDto>> GetPlatforms()
        {
            var platformItems = _platformRepo.GetAllPlatforms();
            
            return Ok(_mapper.Map<IEnumerable<PlatfromReadDto>>(platformItems));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatfromReadDto> GetPlatformById(Guid id)
        {
            try
            {
                var platformItem = _platformRepo.GetPlatformById(id);

                if(platformItem != null)
                {
                    return Ok(_mapper.Map<PlatfromReadDto>(platformItem));
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}