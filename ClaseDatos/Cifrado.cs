using System.Configuration;

using System.Security.Cryptography;

namespace ClaseDatos
{
    public static class Cifrado
    {
        private static byte[] Clave=Convert.FromBase64String(ConfigurationManager.AppSettings["key"]) ; 
        private static byte[] IV= Convert.FromBase64String(ConfigurationManager.AppSettings["iv"]) ; 


        public static string Encriptar(string textoPlano)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Clave;
                aesAlg.IV = IV;

                var encriptador = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncriptado = new MemoryStream())
                {
                    using (var csEncriptado = new CryptoStream(msEncriptado, encriptador, CryptoStreamMode.Write))
                    {
                        using (var swEncriptado = new StreamWriter(csEncriptado))
                        {
                            swEncriptado.Write(textoPlano);
                        }
                    }
                    return Convert.ToBase64String(msEncriptado.ToArray());
                }
            }
        }

        public static  string Desencriptar(string textoEncriptado)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Clave;
                aesAlg.IV = IV;

                var desencriptador = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDesencriptado = new MemoryStream(Convert.FromBase64String(textoEncriptado)))
                {
                    using (var csDesencriptado = new CryptoStream(msDesencriptado, desencriptador, CryptoStreamMode.Read))
                    {
                        using (var srDesencriptado = new StreamReader(csDesencriptado))
                        {
                            return srDesencriptado.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
