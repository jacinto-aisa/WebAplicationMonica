namespace WebAplicationMonica.CrossCuting.Exceptions
{
    [Serializable]
    public class ModuloNotFoundException : Exception
    {
        public int ModuloId { get; }
        public ModuloNotFoundException() { }

        public ModuloNotFoundException(string message)
            : base(message) { }

        public ModuloNotFoundException(string message, Exception inner)
            : base(message, inner) { }
        public ModuloNotFoundException(string message, int moduloId) : this(message) 
        {
            ModuloId = moduloId;
        }
    }
}
