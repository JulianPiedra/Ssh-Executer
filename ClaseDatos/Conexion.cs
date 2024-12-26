namespace ClaseDatos
{
    public class Conexion
    {
        public string ObtenerConexionSQL()
        {
            //string servidor = "DESKTOP-USKGIM6\\PROYECTOS";
            string servidor = "BLASPHENOR";
            string baseDatos = "ComandosBD";
            string usuario = "sa";
            string contraseña = "12345";

            string connectionString = $"Server={servidor};Database={baseDatos};Uid={usuario};Pwd={contraseña};";
            return connectionString;
        }

        public string ObtenerConexionSqlLuis()
        {
            string servidor = "LAPTOP-44H1EHER";
            //string servidor = "BLASPHENOR";
            string baseDatos = "ComandosBD";
            string usuario = "Luis";
            string contraseña = "Luis";
            string connectionString = $"Server={servidor};Database={baseDatos};Uid={usuario};Pwd={contraseña};";
            return connectionString;
        }

    }}