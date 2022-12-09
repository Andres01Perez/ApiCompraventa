using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCompraventa.Data;
using ApiCompraventa.DTOs;
using ApiCompraventa.Entidades;

namespace ApiCompraventa.Controllers
{
    [ApiController]
    [Route("api/marcas")]
    public class MarcasController : ControllerBase
    {
        private readonly ILogger<MarcasController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MarcasController(ILogger<MarcasController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MarcaDTOs>>> GetBrands()
        {
            var brand = await _context.Marcas.OrderBy(b => b.nombre).ToListAsync();
            return _mapper.Map<List<MarcaDTOs>>(brand);
        }

        //Search by parameter
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MarcaDTOs>> GetBrand(int id)
        {
            var brand = await _context.Marcas.FirstOrDefaultAsync(v => v.Id == id);

            if (brand == null)
            {
                return NotFound();
            }

            return _mapper.Map<MarcaDTOs>(brand);
        }

        [HttpPost]
        public async Task<ActionResult<Marca>> PostBrand([FromBody] MarcaDTOsCreation brandCreationDTO)
        {
            var brand = _mapper.Map<Marca>(brandCreationDTO);

            _context.Add(brand);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Marca>> PutBrand(int id, Marca marca)
        {
            if (id != marca.Id)
            {
                return BadRequest("No coinciden los campos a editar");
            }

            var exist = await _context.Marcas.AnyAsync(v => v.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            _context.Update(marca);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            Marca marca = await _context.Marcas.FirstOrDefaultAsync(v => v.Id == id);

            if (marca == null)
            {
                return NotFound();
            }

            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
