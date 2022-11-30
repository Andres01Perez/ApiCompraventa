using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ApiCompraventa.Entidades;

namespace ApiCompraventa.Models
{
    public class IdentityModel : IdentityUser
    {
        [Display(Name = "Número de Documento")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string DocumentNumber { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Address { get; set; }

        public int TipoDocumentoId { get; set; }

        [JsonIgnore]
        [Display(Name = "Tipo de documento")]
        public TipoDocumento TipoDocumento { get; set; }

        [JsonIgnore]
        public ICollection<Historial> Historiales { get; set; }

        [JsonIgnore]
        public ICollection<Articulo> Articulos { get; set; }
    }
}