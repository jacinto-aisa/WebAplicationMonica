using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Reflection;
using System.Resources;
using WebAplicationMonica.CrossCuting.Exceptions;
using WebAplicationMonica.CrossCuting.Logging;
using WebAplicationMonica.Models;

namespace WebAplicationMonica.Services
{
    public class EFRepositorioModulo : IRepositorioModulo
    {
        readonly DesignTimeJacintoContextFactory factoriaDeContextos = new();
        readonly JacintoContext contexto;
        readonly ResourceManager resourceManager = new("WebAplicationMonica.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
        readonly ILoggerManager _loggerManager;
        public EFRepositorioModulo(ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
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
                var moduloEncontrado = contexto.Modulos.Find(Id);
                if (moduloEncontrado is null)
                    throw new ModuloNotFoundException(resourceManager.GetString("ModuloNotFound") ?? "", Id);

                return moduloEncontrado;
            }
            return null;
        }
    }
}
