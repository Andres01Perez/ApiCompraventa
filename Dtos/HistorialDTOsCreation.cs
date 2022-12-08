using ApiCompraventa.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCompraventa.DTOs
{
    public class HistorialDTOsCreation
    {
        public string descripcion { get; set; }
        public int articuloId { get; set; }

        [Display(Name = "Fecha de entrada")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime fechaEntrada { get; set; }

        [Display(Name = "Fecha de salida")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime fechaSalida { get; set; }

        [Display(Name = "Articulo")]
        [JsonIgnore]
        public Articulo articulo { get; set; }

        [Display(Name = "Detalles")]
        [JsonIgnore]
        public ICollection<Detalles> detalles { get; set; }
    }
}
