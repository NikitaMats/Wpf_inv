using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_inv.Service
{
    internal class Validator
    {
        /// <summary>
        /// Проверяет, что количество символов в строке находится в нужном диапазоне.
        /// </summary>
        /// <param name="FunctionName">Имя свойства, откуда был вызван метод.</param>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <param name="value">Строка.</param>
        /// <exception cref="ArgumentException">Выбрасывается, когда количество символов строки не входит в диапазон.</exception>
        public static void AssertCountSymbolsInRange(string FunctionName, int min, int max, string value)
        {
            if (!(value.Length >= min && value.Length <= max))
                throw new ArgumentException(
                    $"The number of characters of the {FunctionName} field must be in the range from {min} to {max}.");
        }

        /// <summary>
        /// Проверяет строку на соответствие IPv4.
        /// </summary>
        /// <param name="ipAddress">Строка.</param>
        /// <exception cref="ArgumentException">Выбрасывается, когда строка не соответсвует IPv4.</exception>
        public bool IsValidIPv4(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
                throw new ArgumentException("The line must not be empty.");

            string[] parts = ipAddress.Split('.');

            if (parts.Length != 4)
                throw new ArgumentException("The line does not match IPv4.");

            foreach (string part in parts)
            {
                if (!int.TryParse(part, out int octet))
                    throw new ArgumentException("The line does not match IPv4.");

                if (octet < 0 || octet > 255)
                    throw new ArgumentException("The line does not match IPv4.");
            }

            return true;
        }
    }
}
