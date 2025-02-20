using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_inv.Model
{
    // Класс для хранения информации о мониторах.
    class Monitor
    {
        // Свойства модели, инвентаризационного номера и серийного номера монитора.
        public string Model { get; set; }
        public string InventoryNumber { get; set; }
        public string SerialNumber { get; set; }

        // Конструктор класса.
        public Monitor(string model, string inventoryNumber, string serialNumber)
        {
            Model = model;
            InventoryNumber = inventoryNumber;
            SerialNumber = serialNumber;
        }   
    }
}
