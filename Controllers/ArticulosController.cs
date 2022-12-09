using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCompraventa.Data;
using ApiCompraventa.DTOs;
using ApiCompraventa.Entidades;

namespace ApiCompraventa.Controllers
{
    [ApiController]
    [Route("api/articulos")]
    public class ArticulosController : ControllerBase
    {
        private readonly ILogger<ArticulosController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ArticulosController(ILogger<ArticulosController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ArticuloDTOs>>> GetArticles()
        {
            var article = await _context.Articulos.OrderBy(v => v.Id).ToListAsync();
            return _mapper.Map<List<ArticuloDTOs>>(article);
        }

        //Search by parameter
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ArticuloDTOs>> GetArticle(int id)
        {
            var article = await _context.Articulos.FirstOrDefaultAsync(v => v.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            return _mapper.Map<ArticuloDTOs>(article);
        }

        [HttpPost]
        public async Task<ActionResult<Articulo>> PostArticle([FromBody] ArticuloDTOsCreation articleCreationDTO)
        {
            var article = _mapper.Map<Articulo>(articleCreationDTO);

            _context.Add(article);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Articulo>> PutArticle(int id, Articulo article)
        {
            if (id != article.Id)
            {
                return BadRequest("No coinciden los campos a editar");
            }

            var exist = await _context.Articulos.AnyAsync(v => v.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            _context.Update(article);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            Articulo article = await _context.Articulos.FirstOrDefaultAsync(v => v.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(article);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
