using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendINAISO.Models
{
    public class Aplicacion
    {
        [Key]
        public int Id { get; set; }

        public string Clase { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
