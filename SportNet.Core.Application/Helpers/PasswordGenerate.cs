using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportNet.Core.Application.Helpers
{
    public class PasswordGenerate
    {
        private static readonly Random random = new Random();
        private const string CaracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int LongitudPorDefecto = 6;

        public static string GenerarPassword(int longitud = LongitudPorDefecto)
        {
            char[] caracteres = new char[longitud];
            for (int i = 0; i < longitud; i++)
            {
                caracteres[i] = CaracteresPermitidos[random.Next(CaracteresPermitidos.Length)];
            }
            return new string(caracteres);
        }
    }
}
