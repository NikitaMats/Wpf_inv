using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json.Nodes;
using Wpf_inv.Model;
using System.Collections;

namespace Wpf_inv.Service
{
    /// <summary>
    /// Класс отвечающий за запись данных в файл.
    /// </summary>
    internal class Serializer
    {
        /// <summary>
        /// Путь к системной папке AppData.
        /// </summary>
        private static string DataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\inv.txt";

        /// <summary>
        /// Метод отвечающий за загрузку данных из файла.
        /// </summary>
        /// <returns>Список объектов класса <see cref="Computer"/>.</returns>
        public static List<Computer> LoadData()
        {
            StreamReader sr = new StreamReader(DataPath);
            var jsonObject = sr.ReadLine();
            sr.Close();
            var computer = JsonConvert.DeserializeObject<List<Computer>>(jsonObject);
            return computer;
        }

        /// <summary>
        /// Метод отвечающий за запись данных в файла.
        /// </summary>
        /// <param name="computer"> Список объектов класса <see cref="Computer"/> для записи.</param>
        public static void WriteData(List<Computer> computer)
        {
            var jsonObject = JsonConvert.SerializeObject(computer);
            StreamWriter sw = new StreamWriter(DataPath);
            sw.WriteLine(jsonObject);
            sw.Close();

        }
    }
}
