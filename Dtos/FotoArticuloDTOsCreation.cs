using ApiCompraventa.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCompraventa.DTOs
{
    public class FotoArticuloDTOsCreation
    {
        public int ArticuloId { get; set; }

        [JsonIgnore]
        public Articulo Articulo { get; set; }

        [Display(Name = "URL Photo")]
        public IFormFile ImageId { get; set; }
    }
}
