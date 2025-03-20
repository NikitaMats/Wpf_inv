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

        public bool IsValidIPv4(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
                return false;

            // Разделяем строку по точкам
            string[] parts = ipAddress.Split('.');
            if (parts.Length != 4)
                return false;

            // Проверяем каждый октет
            foreach (string part in parts)
            {
                // Проверяем, что октет — это число
                if (!int.TryParse(part, out int octet))
                    return false;

                // Проверяем диапазон октета
                if (octet < 0 || octet > 255)
                    return false;
            }

            return true;
        }
    }
}
