using WebAplicationMonica.Models;

namespace WebAplicationMonica.Services
{
    public interface IRepositorioModulo
    {
        Modulo? TomaModulo(int Id);
        void BorraModulo(int Id);
        void AddModulo(Modulo curso);
        List<Modulo>? ListaModulos();
    }
}
