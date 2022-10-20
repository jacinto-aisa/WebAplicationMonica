

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
        ResourceManager resourceManager = new ResourceManager("WebAplicationMonica.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
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
            if (contexto.Cursos is not null)
            {
                var cursoEncontrado = contexto.Cursos.Find(Id);
                if (cursoEncontrado is null)
                   throw new CursoNotFoundException(resourceManager.GetString("CursoNotFound") ?? "",Id);
                 
                return cursoEncontrado;
            }
            return null;
        }
    }
}
