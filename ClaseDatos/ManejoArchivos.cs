using Models;
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
        private static string cadenaConexion { get; set; }

        public static DataTable Servers { get; set; } = new DataTable();
        public static DataTable Comandos { get; set; } = new DataTable();
        public ManejoArchivos()
        {
            cadenaConexion = conn.ObtenerConexionSQL();
        }
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
        public void CrearServidor(Server server)
        {
            
            string query = @"
            INSERT INTO Servers (NombreServer, IP, UserID, Pass) 
            VALUES (@NomServer, @IP, @Usuario, @Pass);
        ";

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NomServer", server.NomServer);
                        command.Parameters.AddWithValue("@IP", server.IP);
                        command.Parameters.AddWithValue("@Usuario", server.Usuario);
                        command.Parameters.AddWithValue("@Pass", Cifrado.Encriptar(server.Contraseña));

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public void CrearComando(Command commands)
        {
            

            string query = @"
              INSERT INTO Comandos (Comando, NombreServer) 
              VALUES (@Comando, @Servidor);
        ";

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Comando", commands.Comando);
                        command.Parameters.AddWithValue("@Servidor", commands.Server);

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void EliminarServidor(Server server)
        {
            string query = @"
            DELETE FROM Comandos 
            WHERE NombreServer = @NomServer;
        ";

            string query2 = @"
            DELETE FROM Servers 
            WHERE NombreServer = @NomServer;
        ";

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NomServer", server.NomServer);
                        command.ExecuteNonQuery();

                        command.CommandText = query2;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void EliminarComando(Command commands)
        {
            string query = @"
            DELETE FROM Comandos 
            WHERE Comando = @Comando 
            AND NombreServer = @server;
        ";

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Comando", commands.Comando);
                        command.Parameters.AddWithValue("@server", commands.Server);

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void ModificarServidor(Server server)
        {

            string query = @"
            UPDATE Servers 
            SET NombreServer = @NomServer, IP = @IP, UserID = @Usuario, Pass = @Pass 
            WHERE NombreServer = @NomOriginal;
        ";

            string query2 = @"
            UPDATE Comandos 
            SET NombreServer = @NomServer 
            WHERE NombreServer = @NomOriginal;
        ";

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NomServer", server.NomServer);
                        command.Parameters.AddWithValue("@IP", server.IP);
                        command.Parameters.AddWithValue("@Usuario", server.Usuario);
                        command.Parameters.AddWithValue("@Pass", Cifrado.Encriptar(server.Contraseña));
                        command.Parameters.AddWithValue("@NomOriginal", server.NomOriginal);

                        command.ExecuteNonQuery();

                        command.CommandText = query2;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ModificarComando(Command commands)
        {
            string query = @"
            UPDATE Comandos 
            SET Comando = @Comando 
            WHERE Comando = @ComandoOriginal;
        ";

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Comando", commands.Comando);
                        command.Parameters.AddWithValue("@ComandoOriginal", commands.NomOriginal);

                        command.ExecuteNonQuery();
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

