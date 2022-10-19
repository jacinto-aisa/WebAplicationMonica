

using Microsoft.EntityFrameworkCore.Query.Internal;
using WebAplicationMonica.Models;

namespace WebAplicationMonica.Services
{
    public class EFRepositorioCurso : IRepositorioCurso
    {
        readonly DesignTimeJacintoContextFactory factoriaDeContextos = new();
        readonly JacintoContext contexto;
        public EFRepositorioCurso()
        {
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
                return contexto.Cursos.Find(Id);
            }
            return null;
        }
    }
}
