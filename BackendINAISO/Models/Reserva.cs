using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendINAISO.Models
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("usuario_id")]
        public virtual int UsuarioId { get; set; }

        [ForeignKey("aplicacion_id")]
        public virtual int AplicacionId { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Aplicacion Aplicacion { get; set; }
    }
}
