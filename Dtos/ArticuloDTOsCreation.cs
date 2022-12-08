using ApiCompraventa.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCompraventa.DTOs
{
    public class ArticuloDTOsCreation
    {

        public int CategoriaId { get; set; }

        public int MarcaId { get; set; }

        [JsonIgnore]
        [Display(Name = "Categoria")]
        public Categorias Categorias { get; set; }

        [JsonIgnore]
        [Display(Name = "Marca")]
        public Marca Marca { get; set; }

        [JsonIgnore]
        public ICollection<Historial> Historiales { get; set; }

        [JsonIgnore]
        public ICollection<FotoArticulo> FotoArticulos { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1900, 3000, ErrorMessage = "Valor de módelo no válido.")]
        public string Descripcion { get; set; }

        [Display(Name = "Tamaño")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Tamano { get; set; }
    }
}
