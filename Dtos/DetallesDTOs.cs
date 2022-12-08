using ApiCompraventa.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCompraventa.DTOs
{
    public class DetallesDTOs
    {
        public int Id { get; set; }
        public int HistorialId { get; set; }

        public int EstadoId { get; set; }

        [Display(Name = "Historial")]
        [JsonIgnore]
        public Historial historial { get; set; }

        [Display(Name = "Estado")]
        [JsonIgnore]
        public Estado estado { get; set; }
    }
}
