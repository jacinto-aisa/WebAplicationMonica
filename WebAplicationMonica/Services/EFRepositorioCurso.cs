

using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;
using System.Reflection;
using WebAplicationMonica.Models;
using System.Resources;
using WebAplicationMonica.CrossCuting.Exceptions;
using NLog.LayoutRenderers;
using WebAplicationMonica.CrossCuting.Logging;

namespace WebAplicationMonica.Services
{
    public class EFRepositorioCurso : IRepositorioCurso
    {
        readonly DesignTimeJacintoContextFactory factoriaDeContextos = new();
        readonly JacintoContext contexto;
        readonly ResourceManager resourceManager = new("WebAplicationMonica.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
        readonly ILoggerManager LoggerManager; 
        public EFRepositorioCurso(ILoggerManager loggerManager)
        {
            this.LoggerManager = loggerManager;
            this.LoggerManager.LogInfo("holaaaaa");
            string[] args = new string[1];
            contexto = factoriaDeContextos.CreateDbContext(args);
        }
        public void AddCurso(Curso curso)
        {
            if (contexto.Cursos is not null)
            {
                contexto.Cursos.Add(curso);
                contexto.SaveChanges();
            }
            else
            {
                this.LoggerManager.LogError($"El curso no ha podido ser insertado Id: {curso.Id} Nombre: {curso.Name}");
            }
        }

        public void BorraCurso(int Id)
        {
            if (contexto.Cursos is not null)
            {
                var cursoABorrar = TomaCurso(Id);
                if (cursoABorrar is not null)
                {
                    contexto.Cursos.Remove(cursoABorrar);
                }
            }
        }

        public List<Curso>? ListaCursos()
        {
            if (contexto.Cursos is not null)
            {
                return contexto.Cursos.ToList();
            }
            return null;
        }

        public Curso? TomaCurso(int Id)
        {
            this.LoggerManager.LogInfo($"Busqueda del Curso de Id: {Id} ");
            if (contexto.Cursos is not null)
            {
                var cursoEncontrado = contexto.Cursos.Find(Id);
                if (cursoEncontrado is null)
                {
                    this.LoggerManager.LogWarn($"El curso de Id: {Id}, no se ha encontrado ");    
                    //El log de Error lo lanzaremos cuando lo capturemos en el middleware.
                    throw new CursoNotFoundException(resourceManager.GetString("CursoNotFound") ?? "", Id);

                }

                return cursoEncontrado;
            }
            return null;
        }
    }
}
