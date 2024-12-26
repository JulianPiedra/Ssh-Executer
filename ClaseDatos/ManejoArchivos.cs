using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Xml;
namespace ClaseDatos
{
    public class ManejoArchivos
    {
        private static Conexion conn = new Conexion();
        private static string cadenaConexion = conn.ObtenerConexionSQL();
        //private static string cadenaConexion = conn.ObtenerConexionSQL();

        public static DataTable Servers { get; set; } = new DataTable();
        public static DataTable Comandos { get; set; } = new DataTable();
        public void CargarDatos()
        {

            string query = @"
                    SELECT * FROM Servers;
                ";
            string query2 = @"
                    SELECT * FROM Comandos;
                ";
            try
            {
                // Crear una nueva conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crea un nuevo comando SQL utilizando la consulta y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Crear un nuevo SqlDataAdapter para ejecutar el comando y llenar el DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            Servers.Clear();
                            Comandos.Clear();
                            // Llena el DataTable con los datos del adaptador
                            adapter.Fill(Servers);
                            command.CommandText = query2;
                           
                            adapter.Fill(Comandos);
                            foreach (DataRow row in Servers.Rows)
                            {
                                if (row["pass"] != null)
                                {
                                    row["pass"] = Cifrado.Desencriptar(row["pass"].ToString());
                                }

                            }


                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void CrearServidor(string NomServer, string IP, string Usuario, string Contraseña)
        {


            if (string.IsNullOrEmpty(NomServer) || string.IsNullOrEmpty(IP)
                || string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Contraseña))
                throw new ArgumentException("Uno o más argumentos son nulos o vacíos.");

            if (!IP.Split('.').All(x => byte.TryParse(x, out _)))
            {
                throw new ArgumentException("La dirección IP no es válida.");
            }
            string query = $@"
                    INSERT INTO Servers (NombreServer, IP, UserID, Pass) VALUES ('{NomServer}', '{IP}', '{Usuario}', '{Cifrado.Encriptar(Contraseña)}');
                ";

            try
            {
                // Crear una nueva conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crea un nuevo comando SQL utilizando la consulta y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Crear un nuevo SqlDataAdapter para ejecutar el comando y llenar el DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    connection.Close();

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }


        }

        public void CrearComando(string Comando, string Servidor)
        {

            if (string.IsNullOrEmpty(Comando))
            {
                throw new ArgumentNullException(nameof(Comando), "El comando no puede ser nulo o vacío.");
            }


            string query = $@"
                      INSERT INTO Comandos (Comando, NombreServer) VALUES ('{Comando}', '{Servidor}');
                ";

            try
            {
                // Crear una nueva conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crea un nuevo comando SQL utilizando la consulta y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Crear un nuevo SqlDataAdapter para ejecutar el comando y llenar el DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    connection.Close();

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public void EliminarServidor(string NomServer)
        {


            string query = $@"
                    Delete FROM Servers where NombreServer='{NomServer}';
                ";
            string query2 = $@"
                        Delete FROM Comandos where NombreServer='{NomServer}';
                    ";
            try
            {
                // Crear una nueva conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crea un nuevo comando SQL utilizando la consulta y la conexión
                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        // Crear un nuevo SqlDataAdapter para ejecutar el comando y llenar el DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.ExecuteNonQuery();
                            command.CommandText = query;
                            command.ExecuteNonQuery();
                        }
                    }
                    connection.Close();


                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void EliminarComando(string Comando, string server)
        {

            string query = $@"
                    Delete FROM Comandos where Comando='{Comando}' and NombreServer='{server}';
                ";
            try
            {
                // Crear una nueva conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crea un nuevo comando SQL utilizando la consulta y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Crear un nuevo SqlDataAdapter para ejecutar el comando y llenar el DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.ExecuteNonQuery();
                            command.CommandText = query;
                        }
                    }
                    connection.Close();

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void ModificarServidor(string NomOriginal, string NomServer, string IP, string Usuario, string Contraseña)
        {
            if (string.IsNullOrEmpty(NomServer) || string.IsNullOrEmpty(IP)
                               || string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Contraseña))
            {
                throw new ArgumentException("Uno o más argumentos son nulos o vacíos.");
            }

            //validar ips
            if (!IP.Split('.').All(x => byte.TryParse(x, out _)))
            {
                throw new ArgumentException("La dirección IP no es válida.");
            }


            string query = $@"
                    UPDATE Servers SET NombreServer = '{NomServer}', IP = '{IP}', UserID = '{Usuario}', Pass = '{Cifrado.Encriptar(Contraseña)}' WHERE NombreServer = '{NomOriginal}';
                ";
            string query2 = $@"
                    UPDATE Comandos SET NombreServer = '{NomServer}' WHERE NombreServer = '{NomOriginal}';
                ";

            try
            {
                // Crear una nueva conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crea un nuevo comando SQL utilizando la consulta y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Crear un nuevo SqlDataAdapter para ejecutar el comando y llenar el DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.ExecuteNonQuery();
                            command.CommandText = query2;
                            command.ExecuteNonQuery();
                        }
                    }
                    connection.Close();

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }


        }
        public void ModificarComando(string ComandoOriginal, string Comando)
        {

            if (string.IsNullOrEmpty(Comando))
            {
                throw new ArgumentNullException(nameof(Comando), "El comando no puede ser nulo o vacío.");
            }


            string query = $@"
                    UPDATE Comandos SET Comando = '{Comando}' WHERE Comando = '{ComandoOriginal}';
                ";

            try
            {
                // Crear una nueva conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crea un nuevo comando SQL utilizando la consulta y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Crear un nuevo SqlDataAdapter para ejecutar el comando y llenar el DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    connection.Close();

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
    }

}

