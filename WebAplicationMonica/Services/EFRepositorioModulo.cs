

using Microsoft.EntityFrameworkCore.Query.Internal;
using WebAplicationMonica.Models;

namespace WebAplicationMonica.Services
{
    public class EFRepositorioModulo : IRepositorioModulo
    {
        readonly DesignTimeJacintoContextFactory factoriaDeContextos = new();
        readonly JacintoContext contexto;
        public EFRepositorioModulo()
        {
            string[] args = new string[1];
            contexto = factoriaDeContextos.CreateDbContext(args);
        }
        public void AddModulo(Modulo modulo)
        {
            if (contexto.Modulos is not null)
            {
                contexto.Modulos.Add(modulo);
                contexto.SaveChanges();
            }
        }

        public void BorraModulo(int Id)
        {
            if (contexto.Modulos is not null)
            {
                var moduloABorrar = TomaModulo(Id);
                if (moduloABorrar is not null)
                {
                    contexto.Modulos.Remove(moduloABorrar);
                }
            }
        }

        public List<Modulo>? ListaModulos()
        {
            if (contexto.Modulos is not null)
            {
                return contexto.Modulos.ToList();
            }
            return null;
        }

        public Modulo? TomaModulo(int Id)
        {
            if (contexto.Modulos is not null)
            {
                return contexto.Modulos.Find(Id);
            }
            return null;
        }
    }
}
