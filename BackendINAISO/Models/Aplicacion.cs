using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendINAISO.Models
{
    public class Aplicacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Clase { get; set; }

        // Relación uno a muchos con Reserva
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
