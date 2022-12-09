using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCompraventa.Data;
using ApiCompraventa.DTOs;
using ApiCompraventa.Entidades;

namespace ApiCompraventa.Controllers
{
    [ApiController]
    [Route("api/tipoDocumentos")]
    public class TipoDocumentosController : ControllerBase
    {
        private readonly ILogger<TipoDocumentosController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TipoDocumentosController(ILogger<TipoDocumentosController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoDocumentoDTOs>>> GetDocumentTypes()
        {
            var documentType = await _context.TipoDocumentos.OrderBy(v => v.nombre).ToListAsync();
            return _mapper.Map<List<TipoDocumentoDTOs>>(documentType);
        }

        //Search by parameter
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TipoDocumentoDTOs>> GetDocumentType(int id)
        {
            var documentType = await _context.TipoDocumentos.FirstOrDefaultAsync(v => v.Id == id);

            if (documentType == null)
            {
                return NotFound();
            }

            return _mapper.Map<TipoDocumentoDTOs>(documentType);
        }

        [HttpPost]
        public async Task<ActionResult<TipoDocumento>> PostDocumentType([FromBody] TipoDocumentoDTOsCreation documentTypeCreationDTO)
        {
            var documentType = _mapper.Map<TipoDocumento>(documentTypeCreationDTO);

            _context.Add(documentType);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Marca>> PutDocumentType(int id, TipoDocumento documentType)
        {
            if (id != documentType.Id)
            {
                return BadRequest("No coinciden los campos a editar");
            }

            var exist = await _context.TipoDocumentos.AnyAsync(v => v.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            _context.Update(documentType);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentType(int id)
        {
            TipoDocumento documentType = await _context.TipoDocumentos.FirstOrDefaultAsync(v => v.Id == id);

            if (documentType == null)
            {
                return NotFound();
            }

            _context.TipoDocumentos.Remove(documentType);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
