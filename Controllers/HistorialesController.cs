using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCompraventa.Data;
using ApiCompraventa.DTOs;
using ApiCompraventa.Entidades;

namespace ApiCompraventa.Controllers
{
    [ApiController]
    [Route("api/historiales")]
    public class HistorialesController : ControllerBase
    {
        private readonly ILogger<HistorialesController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HistorialesController(ILogger<HistorialesController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        //Search
        [HttpGet]
        public async Task<ActionResult<List<HistorialDTOs>>> GetHistories()
        {
            var history = await _context.Historiales.OrderBy(v => v.Id).ToListAsync();
            return _mapper.Map<List<HistorialDTOs>>(history);
        }

        //Search by parameter
        [HttpGet("{id:int}")]
        public async Task<ActionResult<HistorialDTOs>> GetHistory(int id)
        {
            var history = await _context.Historiales.FirstOrDefaultAsync(v => v.Id == id);

            if (history == null)
            {
                return NotFound();
            }

            return _mapper.Map<HistorialDTOs>(history);
        }

        [HttpPost]
        public async Task<ActionResult<Historial>> PostHistory([FromBody] HistorialDTOsCreation historyCreationDTO)
        {
            var history = _mapper.Map<Historial>(historyCreationDTO);

            _context.Add(history);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Historial>> PutHistory(int id, Historial history)
        {
            if (id != history.Id)
            {
                return BadRequest("No coinciden los campos a editar");
            }

            var exist = await _context.Historiales.AnyAsync(v => v.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            _context.Update(history);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistory(int id)
        {
            Historial history = await _context.Historiales.FirstOrDefaultAsync(v => v.Id == id);

            if (history == null)
            {
                return NotFound();
            }

            _context.Historiales.Remove(history);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
