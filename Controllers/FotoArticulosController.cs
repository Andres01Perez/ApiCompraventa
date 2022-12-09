using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCompraventa.Data;
using ApiCompraventa.DTOs;
using ApiCompraventa.Entidades;
using ApiCompraventa.Services;

namespace ApiCompraventa.Controllers
{
    [ApiController]
    [Route("api/fotosArticulo")]
    public class FotoArticulosController : ControllerBase
    {
        private readonly ILogger<FotoArticulosController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IFileStorage filestorage;
        private readonly string contenedor = "Files";

        public FotoArticulosController(ILogger<FotoArticulosController> logger, ApplicationDbContext context, IMapper mapper,
             IFileStorage filestorage)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
            this.filestorage = filestorage;
        }


        //Select * from actor
        [HttpGet]
        public async Task<ActionResult<List<FotoArticuloDTOs>>> Get()
        {
            var entidades = await context.FotoArticulos.ToListAsync();

            return mapper.Map<List<FotoArticuloDTOs>>(entidades);
        }

        // Búsqueda por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FotoArticuloDTOs>> Get(int id)
        {
            var vehiclephoto = await context.FotoArticulos.FirstOrDefaultAsync(x => x.Id == id);

            if (vehiclephoto == null)
            {
                return NotFound();
            }

            return mapper.Map<FotoArticuloDTOs>(vehiclephoto);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] FotoArticuloDTOsCreation articlePhotoCreationDTO)
        {
            var archivos = mapper.Map<FotoArticulo>(articlePhotoCreationDTO);

            if (articlePhotoCreationDTO.ImageId != null)
            {
                archivos.ImageId = await filestorage.GuardarArchivo(contenedor, articlePhotoCreationDTO.ImageId);
            }

            context.Add(archivos);
            await context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var articlephoto = await context.FotoArticulos.FirstOrDefaultAsync(x => x.Id == id);

            if (articlephoto == null)
            {
                return NotFound();
            }

            context.Remove(articlephoto);
            await context.SaveChangesAsync();
            return NoContent(); //204
        }

    }
}
