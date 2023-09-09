using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendINAISO.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [ForeignKey("Aplicacion")]
        public int AplicacionId { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Aplicacion Aplicacion { get; set; }
    }
}
