
using System.Linq;
using WebAplicationMonica.Models;

namespace WebAplicationMonica.Services
{
    public class FakeRepositorioModulo : IRepositorioModulo
    {
        

        readonly List<Modulo> misModulos = new();
        public FakeRepositorioModulo()
        {
            misModulos.Add(new Modulo() { Id = 1, Name = "Modulo Vocals",CursoId = 1 });
            misModulos.Add(new Modulo() { Id = 2, Name = "Modulo Letters", CursoId = 1 });
            misModulos.Add(new Modulo() { Id = 3, Name = "Modulo Verbs", CursoId = 1 });

            misModulos.Add(new Modulo() { Id = 4, Name = "Modulo Vocalua" , CursoId = 2});
            misModulos.Add(new Modulo() { Id = 5, Name = "Modulo Letres", CursoId = 2 });

            misModulos.Add(new Modulo() { Id = 6, Name = "Modulo Vocalatchum", CursoId = 3 });
        }


        public void AddModulo(Modulo modulo)
        {
            var ultimoNumero = misModulos.Count;
            modulo.Id = ultimoNumero;
            misModulos.Add(modulo);
        }

        public void BorraModulo(int Id)
        {
            misModulos.RemoveAt(Id);
        }

        public List<Modulo> ListaModulos()
        {
            return misModulos;
        }

        public Modulo TomaModulo(int Id)
        {
            return misModulos.Where(x => x.Id == Id).First();
            
        }
    }
}
