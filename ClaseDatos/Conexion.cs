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
    }}