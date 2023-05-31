using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class JugadorBLL
{
    private Contexto _contexto;

    public JugadorBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int jugadorId)
    {
        return _contexto.Jugador.Any(o => o.JugadorId == jugadorId);
    }

    private bool Insertar(Jugador jugador)
    {
        _contexto.Jugador.Add(jugador);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Jugador jugador)
    {
        var JugadorExistencia = _contexto.Jugador.Find(jugador.JugadorId);
        if (JugadorExistencia == null)
        {
            return false;
        }

        _contexto.Entry(JugadorExistencia).CurrentValues.SetValues(jugador);
        return _contexto.SaveChanges() > 0;
    }


    public bool Guardar(Jugador jugador)
    {
        if (!Existe(jugador.JugadorId))
        {
            return this.Insertar(jugador);
        }
        else
        {
            return this.Modificar(jugador);
        }
    }

    public bool Eliminar(Jugador jugador)
    {
        if (Existe(jugador.JugadorId))
        {
            var JugadorEliminar = _contexto.Jugador.Find(jugador.JugadorId);
            _contexto.Entry(JugadorEliminar).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        else
        {
            return false;
        }
    }

    public Jugador? Buscar(int jugadorId)
    {
        return _contexto.Jugador
          .Where(o => o.JugadorId == jugadorId)
          .AsNoTracking()
          .SingleOrDefault();
    }

    public List<Jugador> GetList(Expression<Func<Jugador, bool>> criterio)
    {
        return _contexto.Jugador.AsNoTracking().Where(criterio).ToList();
    }

}