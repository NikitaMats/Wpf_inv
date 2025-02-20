using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_inv.Model
{
    /// <summary>
    /// Класс отвечающий за хранение данных о компьютерах.
    /// </summary>
    class Computer
    {
        /// <summary>
        /// Имя компьютера.
        /// </summary>
        private string _pcName;

        /// <summary>
        /// Модель компьютера.
        /// </summary>
        private string _pcModel;

        /// <summary>
        /// Инвентаризационный номер компьютера.
        /// </summary>
        private string _inventoryNumber;

        /// <summary>
        /// Серийный номер компьютера.
        /// </summary>
        private string _serialNumber;

        /// <summary>
        /// IP адрес компьютера.
        /// </summary>
        private string _ipAddress;

        /// <summary>
        /// Объем оперативной памяти компьютера. Указывается в гигабайтах.
        /// </summary>
        private int _ramSize;

        /// <summary>
        /// Объем памяти компьютера. Указывается в гигабайтах.
        /// </summary>
        private int _hddSize;

        /// <summary>
        /// Модель материнской платы компьютера.
        /// </summary>
        private string _motherboardMode;

        /// <summary>
        /// Модель процессора компьютера.
        /// </summary>
        private string _cpuModel;

        /// <summary>
        /// Список установленного ПО на компьютере.
        /// </summary>
        private string _installedSoftware;

        /// <summary>
        /// Экземпляр класса <see cref="Monitor"/>.
        /// </summary>
        private Monitor _monitor;

        /// <summary>
        /// Возвращает и задаёт имя компьютера.
        /// </summary>
        public string PCName
        {
            get
            {
                return _pcName;
            }
            set
            {
                _pcName = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт модель компьютера.
        /// </summary>
        public string PCModel
        {
            get
            {
                return _pcModel;
            }
            set
            {
                _pcModel = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт инвентаризационный номер компьютера.
        /// </summary>
        public string InventoryNumber
        {
            get
            {
                return _inventoryNumber;
            }
            set
            {
                _inventoryNumber = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт серийный номер компьютера.
        /// </summary>
        public string SerialNumber
        {
            get
            {
                return _serialNumber;
            }
            set
            {
                _serialNumber = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт IP адрес компьютера.
        /// </summary>
        public string IPAddress
        {
            get
            {
                return _ipAddress;
            }
            set
            {
                _ipAddress = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт оперативной объем памяти компьютера. Указывается в гигабайтах.
        /// </summary>
        public int RAMSize
        {
            get
            {
                return _ramSize;
            }
            set
            {
                _ramSize = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт объем памяти компьютера. Указывается в гигабайтах.
        /// </summary>
        public int HDDSize
        {
            get
            {
                return _hddSize;
            }
            set
            {
                _hddSize = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт модель материнской платы компьютера.
        /// </summary>
        public string MotherboardModel
        {
            get
            {
                return _motherboardMode;
            }
            set
            {
                _motherboardMode = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт модель процессора компьютера.
        /// </summary>
        public string CPUModel
        {
            get
            {
                return _cpuModel;
            }
            set
            {
                _cpuModel = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт список установленного ПО (например, перечисленный через запятую).
        /// </summary>
        public string InstalledSoftware
        {
            get
            {
                return _installedSoftware;
            }
            set
            {
                _installedSoftware = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт монитор компьютера. Требует экземпляр класса <see cref="Monitor"/>.
        /// </summary>
        public Monitor Monitor
        {
            get
            {
                return _monitor;
            }
            set
            {
                _monitor = value;
            }
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Computer"/>.
        /// </summary>
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
