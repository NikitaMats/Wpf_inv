using Newtonsoft.Json;
using System.IO;
using Wpf_inv.Model;

namespace Wpf_inv.Service
{
    /// <summary>
    /// The class responsible for writing data to a file.
    /// </summary>
    internal class Serializer
    {
        /// <summary>
        /// Path to the system AppData folder.
        /// </summary>
        private static string DataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\inv.txt";

        /// <summary>
        /// The method responsible for loading data from a file.
        /// </summary>
        /// <returns>List of class objects.<see cref="Computer"/>.</returns>
        public static List<Computer> LoadData()
        {
            StreamReader sr = new StreamReader(DataPath);
            var jsonObject = sr.ReadLine();
            sr.Close();
            var computer = JsonConvert.DeserializeObject<List<Computer>>(jsonObject);
            return computer;
        }

        /// <summary>
        /// The method responsible for writing data to a file.
        /// </summary>
        /// <param name="computer">List of class objects.<see cref="Computer"/> для записи.</param>
        public static void WriteData(List<Computer> computer)
        {
            var jsonObject = JsonConvert.SerializeObject(computer);
            StreamWriter sw = new StreamWriter(DataPath);
            sw.WriteLine(jsonObject);
            sw.Close();

        }
    }
}
