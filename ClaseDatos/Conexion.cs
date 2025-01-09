using Models;
using System.Configuration;

namespace ClaseDatos
{
    public class Conexion
    {
        
        public string ObtenerConexionSQL()
        {
            Database database = new Database();
            string connectionString = $"Server={Cifrado.Desencriptar(database.Servidor)};Database={Cifrado.Desencriptar(database.BaseDatos)};" + (database.WindowsAuth
                ? "Integrated Security=SSPI;"
                : $"Uid={Cifrado.Desencriptar(database.Usuario)};Pwd={Cifrado.Desencriptar(database.Contraseña)};");

            return connectionString;
        }
    }
}
