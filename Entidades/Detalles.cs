using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCompraventa.Entidades
{
    public class Detalles
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
