namespace WebAplicationMonica.Models
{
    public class Modulo
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int CursoId { get; set; }

        public virtual Curso? MiCurso { get; set; }
    }
}
