using System.Configuration;

namespace ClaseDatos
{
    public class Conexion
    {
        public string ObtenerConexionSQL()
        {
            string servidor = Cifrado.Desencriptar(ConfigurationManager.AppSettings["server"]);
            string baseDatos = Cifrado.Desencriptar(ConfigurationManager.AppSettings["database"]);
            string usuario = Cifrado.Desencriptar(ConfigurationManager.AppSettings["user"]);
            string contraseña = Cifrado.Desencriptar(ConfigurationManager.AppSettings["password"]);
            bool windowsAuth = bool.TryParse(ConfigurationManager.AppSettings["windowsauth"], out bool isWindowsAuth) && isWindowsAuth;

            string connectionString = windowsAuth
                ? $"Server={servidor};Database={baseDatos};Integrated Security=SSPI;"
                : $"Server={servidor};Database={baseDatos};Uid={usuario};Pwd={contraseña};";

            return connectionString;
        }
    }
}
