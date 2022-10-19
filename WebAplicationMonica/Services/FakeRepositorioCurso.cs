
using System.Linq;
using WebAplicationMonica.Models;

namespace WebAplicationMonica.Services
{
    public class FakeRepositorioCurso : IRepositorioCurso
    {
        

        readonly List<Curso> misCursos = new();
        public FakeRepositorioCurso()
        {
            misCursos.Add(new Curso() { Id = 1, Name = "Curso De Ingles" });
            misCursos.Add(new Curso() { Id = 2, Name = "Curso de Francesiuiu" });
            misCursos.Add(new Curso() { Id = 3, Name = "Curso de Aleman" });
        }


        public void AddCurso(Curso curso)
        {
            var ultimoNumero = misCursos.Count;
            curso.Id = ultimoNumero;
            misCursos.Add(curso);
        }

        public void BorraCurso(int Id)
        {
            misCursos.RemoveAt(Id);
        }

        public List<Curso> ListaCursos()
        {
            return misCursos;
        }

        public Curso TomaCurso(int Id)
        {
            return misCursos.Where(x => x.Id == Id).First();
            
        }
    }
}
