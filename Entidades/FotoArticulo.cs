using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCompraventa.Entidades
{
    public class FotoArticulo
    {
        public int Id { get; set; }
        public int ArticuloId { get; set; }

        [JsonIgnore]
        public Articulo Articulo { get; set; }

        [Display(Name = "URL Photo")]
        public string ImageId { get; set; }
    }
}
