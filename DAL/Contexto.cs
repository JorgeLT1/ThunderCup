using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public DbSet<Jugador> Jugador { get; set; }
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

}