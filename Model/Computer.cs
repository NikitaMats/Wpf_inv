using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_inv.Model
{
    // Класс для хранения информации о компьютерах.
    class Computer
    {
        // Свойства компьютера.
        public string PCName { get; set; }
        public string PCModel { get; set; }
        public string InventoryNumber { get; set; }
        public string SerialNumber { get; set; }
        public string IPAddress { get; set; }
        public int RAMSize { get; set; } // В гигабайтах
        public int HDDSize { get; set; } // В гигабайтах
        public string MotherboardModel { get; set; }
        public string CPUModel { get; set; }
        public string InstalledSoftware { get; set; } // Список установленного ПО (например, перечисленный через запятую)
        public Monitor Monitor { get; set; } // Экземпляр класса Monitor

        // Конструктор класса.
        public Computer(string pcName, string pcModel, string inventoryNumber, string serialNumber,
                        string ipAddress, int ramSize, int hddSize,
                        string motherboardModel, string cpuModel, string installedSoftware, Monitor monitor)
        {
            PCName = pcName;
            PCModel = pcModel;
            InventoryNumber = inventoryNumber;
            SerialNumber = serialNumber;
            IPAddress = ipAddress;
            RAMSize = ramSize;
            HDDSize = hddSize;
            MotherboardModel = motherboardModel;
            CPUModel = cpuModel;
            InstalledSoftware = installedSoftware;
            Monitor = monitor;
        }
    }
}
