using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MindBetter.API.Dtos;
using MindBetter.Infrastructure.Data.Services;

namespace MindBetter.API.Controllers
{
    [ApiController]
    [Route("api/nmphos")]
    public class NonProfitsController : ControllerBase
    {
        private readonly INonProfitRepository _nonProfitRepository;
        private readonly IMapper _mapper;

        public NonProfitsController(INonProfitRepository nonProfitRepository,
            IMapper mapper)
        {
            _nonProfitRepository = nonProfitRepository ?? throw new ArgumentNullException(nameof(nonProfitRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NonProfitDto>>> GetNonProfits()
        {
            var nonProfitEntities = await _nonProfitRepository.GetNonProfitsAsync();
            var dtos = _mapper.Map<IEnumerable<NonProfitDto>>(nonProfitEntities);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NonProfitDto>> GetNonProfit(int id)
        {
            if (!await _nonProfitRepository.NonProfitExistsAsync(id))
            {
                return NotFound();
            }

            var nonProfit = await _nonProfitRepository.GetNonProfitAsync(id);
            var dto = _mapper.Map<NonProfitDto>(nonProfit);

            return Ok(dto);
        }
    }
}
