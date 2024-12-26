using System.Configuration;

namespace ClaseDatos
{
    public class Conexion
    {
        public string ObtenerConexionSQL()
        {
            string servidor = ConfigurationManager.AppSettings["server"] ; 
            string baseDatos = ConfigurationManager.AppSettings["database"];
            string usuario = ConfigurationManager.AppSettings["user"];
            string contraseña = ConfigurationManager.AppSettings["password"];           

            string connectionString = $"Server={servidor};Database={baseDatos};Uid={usuario};Pwd={contraseña};";
            return connectionString;
        } 
    }}