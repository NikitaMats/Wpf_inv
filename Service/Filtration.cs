using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wpf_inv.Model;

namespace Wpf_inv.Service
{
    internal class Filtration
    {
        /// <summary>
        /// A filter function that returns a list of objects that contain fields with a value of 0.
        /// </summary>
        /// <param name="computers">List of objects to be checked.</param>
        /// <returns>List of objects containing fields with value 0.</returns>
        public static List<Computer> FilterObjectsWithZeroFields(List<Computer> computers)
        {
            List<Computer> result = new List<Computer>();

            foreach (var computer in computers)
            {
                PropertyInfo[] properties = computer.GetType().GetProperties();

                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(int))
                    {
                        int value = (int)property.GetValue(computer);

                        if (value == 0)
                        {
                            result.Add(computer);
                            break;
                        }
                    }

                    if (property.PropertyType == typeof(string)) 
                    {
                        string value = (string)property.GetValue(computer);

                        if (value == "0")
                        {
                            result.Add(computer);
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
