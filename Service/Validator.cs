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
        /// Checks that the number of characters in a string is within the specified range.
        /// </summary>
        /// <param name="FunctionName">The name of the property from which the method was called.</param>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        /// <param name="value">Line.</param>
        /// <exception cref="ArgumentException">Thrown when the number of characters in a string is out of range.</exception>
        public static void AssertCountSymbolsInRange(string FunctionName, int min, int max, string value)
        {
            if (!(value.Length >= min && value.Length <= max))
                throw new ArgumentException(
                    $"The number of characters of the {FunctionName} field must be in the range from {min} to {max}.");
        }

        /// <summary>
        /// Checks if a string is IPv4 compliant.
        /// </summary>
        /// <param name="ipAddress">Line.</param>
        /// <exception cref="ArgumentException">Thrown when a string is not IPv4 compliant.</exception>
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
