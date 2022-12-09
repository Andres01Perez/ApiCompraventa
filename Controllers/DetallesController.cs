using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCompraventa.Data;
using ApiCompraventa.DTOs;
using ApiCompraventa.Entidades;

namespace ApiCompraventa.Controllers
{
    [ApiController]
    [Route("api/detalles")]
    public class DetallesController : ControllerBase
    {
        private readonly ILogger<DetallesController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DetallesController(ILogger<DetallesController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Detalles>>> Get()
        {
            return await _context.Detalless.ToListAsync();
            //200 
        }

        //Search by parameter
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DetallesDTOs>> GetDetail(int id)
        {
            var detail = await _context.Detalless.FirstOrDefaultAsync(v => v.Id == id);

            if (detail == null)
            {
                return NotFound();
            }

            return _mapper.Map<DetallesDTOs>(detail);
        }

        [HttpPost]
        public async Task<ActionResult<Detalles>> PostDetail([FromBody] DetallesDTOsCreation detailCreationDTO)
        {
            var detail = _mapper.Map<Detalles>(detailCreationDTO);

            _context.Add(detail);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Detalles>> PutDetail(int id, Detalles detail)
        {
            if (id != detail.Id)
            {
                return BadRequest("No coinciden los campos a editar");
            }

            var exist = await _context.Detalless.AnyAsync(v => v.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            _context.Update(detail);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetail(int id)
        {
            Detalles detail = await _context.Detalless.FirstOrDefaultAsync(v => v.Id == id);

            if (detail == null)
            {
                return NotFound();
            }

            _context.Detalless.Remove(detail);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
