namespace Models
{
    public class Server
    {
        public string? NomOriginal { get; set; }
        public string? NomServer { get; set; }
        public string? IP { get;  set; }
        public string? Usuario { get; set; }
        public string? Contraseña { get; set; }
        public Server(string nomOriginal, string nomServer, string ip, string usuario, string contraseña)
        {
            NomOriginal = nomOriginal;
            NomServer = nomServer;
            IP = ip;
            Usuario = usuario;
            Contraseña = contraseña;
        }
        public Server(string nomServer, string ip, string usuario, string contraseña)
        {
            NomServer = nomServer;
            IP = ip;
            Usuario = usuario;
            Contraseña = contraseña;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(NomServer))
                throw new ArgumentException("NomServer cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(IP))
                throw new ArgumentException("IP cannot be null or empty.");
            if (!System.Net.IPAddress.TryParse(IP, out _))
                throw new ArgumentException("IP Address is not valid.");
            if (string.IsNullOrWhiteSpace(Usuario))
                throw new ArgumentException("Usuario cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Contraseña))
                throw new ArgumentException("Contraseña cannot be null or empty.");
        }
    }
}
