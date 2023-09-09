public class UsuarioViewModel
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<ReservaViewModel> Reservas { get; set; }
}

public class ReservaViewModel
{
    public int Id { get; set; }
    public string Aplicacion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
}