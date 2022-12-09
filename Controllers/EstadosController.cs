using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCompraventa.Data;
using ApiCompraventa.DTOs;
using ApiCompraventa.Entidades;

namespace ApiCompraventa.Controllers
{
    [ApiController]
    [Route("api/estados")]
    public class EstadosController : ControllerBase
    {
        private readonly ILogger<EstadosController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EstadosController(ILogger<EstadosController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        //Search
        [HttpGet]
        public async Task<ActionResult<List<EstadoDTOs>>> GetProcedures()
        {
            var procedure = await _context.Estados.OrderBy(v => v.Id).ToListAsync();
            return _mapper.Map<List<EstadoDTOs>>(procedure);
        }

        //Search by parameter
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EstadoDTOs>> GetProcedure(int id)
        {
            var procedure = await _context.Estados.FirstOrDefaultAsync(v => v.Id == id);

            if (procedure == null)
            {
                return NotFound();
            }

            return _mapper.Map<EstadoDTOs>(procedure);
        }

        [HttpPost]
        public async Task<ActionResult<Estado>> PostProcedure([FromBody] EstadoDTOsCreation procedureCreationDTO)
        {
            var procedure = _mapper.Map<Estado>(procedureCreationDTO);

            _context.Add(procedure);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Estado>> PutProcedure(int id, Estado status)
        {
            if (id != status.Id)
            {
                return BadRequest("No coinciden los campos a editar");
            }

            var exist = await _context.Estados.AnyAsync(v => v.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            _context.Update(status);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcedure(int id)
        {
            Estado status = await _context.Estados.FirstOrDefaultAsync(v => v.Id == id);

            if (status == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(status);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
