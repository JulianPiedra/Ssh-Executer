using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Models
{
    public class Database
    {
        public string? Servidor { get; set; }
        public string? BaseDatos { get; set; }
        public string? Usuario { get; set; }
        public string? Contraseña { get; set; }
        public bool WindowsAuth { get; set; }
        public Database(string? servidor, string? bd, string? user, string? pass, bool windowsAuth)
        {
            Servidor = servidor;
            BaseDatos = bd;
            Usuario = user;
            Contraseña = pass;
            WindowsAuth = windowsAuth;
        }
        public Database()
        {
            string? servidor = ConfigurationManager.AppSettings["server"];
            string? bd = ConfigurationManager.AppSettings["database"];
            string? user = ConfigurationManager.AppSettings["user"];
            string? pass = ConfigurationManager.AppSettings["password"];
            bool windowsAuth = bool.TryParse(ConfigurationManager.AppSettings["windowsauth"], out bool isWindowsAuth) && isWindowsAuth;
            Servidor = servidor;
            BaseDatos = bd;
            Usuario = user;
            Contraseña = pass;
            WindowsAuth = windowsAuth;
        }
        public void Validate() {
            // Validate the input fields
            if (string.IsNullOrWhiteSpace(Servidor) ||
                string.IsNullOrWhiteSpace(BaseDatos) ||
                (string.IsNullOrWhiteSpace(Usuario) ||
                 string.IsNullOrWhiteSpace(Contraseña)) &&
                !WindowsAuth)
            {
                throw new ArgumentException("Please complete all fields.");
             
            }
        }
    }
}
