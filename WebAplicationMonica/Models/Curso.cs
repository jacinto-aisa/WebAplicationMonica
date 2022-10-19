namespace WebAplicationMonica.Models
{
    public class Curso
    {
        public int Id { get; set; } 
        public string? Name { get; set; }    
        public virtual List<Modulo>? Modulos { get; set; }

    }
}
