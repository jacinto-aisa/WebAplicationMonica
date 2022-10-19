

using WebAplicationMonica.Models;

namespace WebAplicationMonica.Services
{
    public interface IRepositorioCurso
    {
        Curso? TomaCurso(int Id);
        void BorraCurso(int Id);
        void AddCurso(Curso curso);
        List<Curso>? ListaCursos();

    }
}
