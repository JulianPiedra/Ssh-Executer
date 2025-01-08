using System.Configuration;

namespace ClaseDatos
{
    public class Conexion
    {
        public string ObtenerConexionSQL()
        {
            string servidor = ConfigurationManager.AppSettings["server"];
            string baseDatos = ConfigurationManager.AppSettings["database"];
            string usuario = ConfigurationManager.AppSettings["user"];
            string contraseña = ConfigurationManager.AppSettings["password"];
            bool windowsAuth = bool.TryParse(ConfigurationManager.AppSettings["windowsauth"], out bool isWindowsAuth) && isWindowsAuth;

            string connectionString = windowsAuth
                ? $"Server={servidor};Database={baseDatos};Integrated Security=SSPI;"
                : $"Server={servidor};Database={baseDatos};Uid={usuario};Pwd={contraseña};";

            return connectionString;
        }
    }
}
