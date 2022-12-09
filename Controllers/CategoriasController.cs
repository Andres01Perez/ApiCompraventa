using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCompraventa.Data;
using ApiCompraventa.DTOs;
using ApiCompraventa.Entidades;

namespace ApiCompraventa.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly ILogger<CategoriasController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoriasController(ILogger<CategoriasController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        //Search
        [HttpGet]
        public async Task<ActionResult<List<CategoriasDTOs>>> GetArticleTypes()
        {
            var articleType = await _context.Categoriass.OrderBy(vt => vt.Description).ToListAsync();
            return _mapper.Map<List<CategoriasDTOs>>(articleType);
        }

        //Search by parameter
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoriasDTOs>> GetArticleType(int id)
        {
            var articleType = await _context.Categoriass.FirstOrDefaultAsync(vt => vt.Id == id);

            if (articleType == null)
            {
                return NotFound();
            }

            return _mapper.Map<CategoriasDTOs>(articleType);
        }

        [HttpPost]
        public async Task<ActionResult<Categorias>> PostArticleType([FromBody] CategoriasDTOsCreation articleTypeCreationDTO)
        {
            var articleType = _mapper.Map<Categorias>(articleTypeCreationDTO);

            _context.Add(articleType);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categorias>> PutArticleType(int id, Categorias articleType)
        {
            if (id != articleType.Id)
            {
                return BadRequest("No coinciden los campos a editar");
            }

            var exist = await _context.Categoriass.AnyAsync(vt => vt.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            _context.Update(articleType);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticleType(int id)
        {
            Categorias articleType = await _context.Categoriass.FirstOrDefaultAsync(vt => vt.Id == id);

            if (articleType == null)
            {
                return NotFound();
            }

            _context.Categoriass.Remove(articleType);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
