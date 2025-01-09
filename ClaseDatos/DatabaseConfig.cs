using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseDatos
{
    public class DatabaseConfig
    {
        public void SaveConfiguration(Database database)
        {
            // Abre la configuración de la aplicación
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Verifica y crea las claves si no existen
            AddOrUpdateAppSetting(config, "server", Cifrado.Encriptar(database.Servidor));
            AddOrUpdateAppSetting(config, "database", Cifrado.Encriptar(database.BaseDatos));
            AddOrUpdateAppSetting(config, "user", Cifrado.Encriptar(database.Usuario));
            AddOrUpdateAppSetting(config, "password", Cifrado.Encriptar(database.Contraseña));
            AddOrUpdateAppSetting(config, "windowsauth",database.WindowsAuth.ToString());

            // Guarda y actualiza la sección de configuración
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void AddOrUpdateAppSetting(Configuration config, string key, string value)
        {
            if (config.AppSettings.Settings[key] == null)
            {
                // Si no existe, crea una nueva clave
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                // Si existe, actualiza su valor
                config.AppSettings.Settings[key].Value = value;
            }
        }
    }
}
