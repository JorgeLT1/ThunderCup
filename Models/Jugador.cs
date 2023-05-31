using System.ComponentModel.DataAnnotations;

public class Jugador
{
    [Key]
    public int JugadorId { get; set; }
    
    [Required(ErrorMessage = "El nombre del jugador es requerido.")]
    public string? NombreJugadorReal { get; set; }
    [Required(ErrorMessage = "El nombre de usuario es requerido.")]
    public string? Usuario { get; set; }
    [Required(ErrorMessage = "La edad es obligatoria.")]
    [Range(1, 100, ErrorMessage = "La edad debe ser mayor que cero")]
    public int Edad { get; set; }
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    [Required(ErrorMessage = "La liga es requerida.")]
    public string? Liga { get; set; }
}