using System;

namespace Models
{
    public class Command
    {
        public string? NomOriginal { get; set; }
        public string? Server { get; set; }
        public string? Comando { get; set; }
        public Command(string nomOriginal, string nomServer, string comando)
        {
            NomOriginal = nomOriginal;
            Server = nomServer;
            Comando = comando;
        }
        public Command(string nomServer, string comando)
        {
            Server = nomServer;
            Comando = comando;
        }


        public void Validate() {
            if (string.IsNullOrEmpty(Comando))
            {
                throw new ArgumentNullException(nameof(Comando), "Command can't be null.");
            }
        }
    }
}
