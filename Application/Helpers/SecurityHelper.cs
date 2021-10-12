using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helpers
{
   public class SecurityHelper
    {
        /// <summary>
        /// Encriptación Suiza Lab
        /// </summary>
        public static string Encriptar(string sPassword)
        {
            string sEncriptado = string.Empty;
            int iContador = sPassword.Length;

            int[] aux = new int[] { 3, 24, 8, 10, 34, 17, 20, 21, 21, 3, 24, 8, 10, 34, 17, 20 };

            for (int i = 0; i < iContador; i++)
            {
                sEncriptado = (sEncriptado + Convert.ToChar(Encoding.ASCII.GetBytes(sPassword.Substring(i, 1))[0] + aux[i]).ToString());
            }

            return sEncriptado;
        }

        /// <summary>
        /// Desencriptación Suiza Lab
        /// </summary>
        public static string Desencriptar(string sPassword)
        {
            string sDesencriptado = string.Empty;
            int iContador = sPassword.Length;

            int[] aux = new int[] { 3, 24, 8, 10, 34, 17, 20, 21, 21, 3, 24, 8, 10, 34, 17, 20 };

            for (int i = 0; i < iContador; i++)
            {
                sDesencriptado = (sDesencriptado + Convert.ToChar(Encoding.ASCII.GetBytes(sPassword.Substring(i, 1))[0] - aux[i]).ToString());
            }

            return sDesencriptado;
        }

        /// <summary>
        /// GetBasicAuthentication
        /// </summary>
        public static string GetCredentialsBasicAuthentication(string user, string password)
        {
            return $"Basic { Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", user, password))) }";
        }
    }
}
