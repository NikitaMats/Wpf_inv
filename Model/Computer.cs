namespace Wpf_inv.Model
{
    /// <summary>
    /// The class responsible for storing data about computers.
    /// </summary>
    class Computer
    {
        /// <summary>
        /// The number of the office in which the PC is installed.
        /// </summary>
        private int _cabinet;

        /// <summary>
        /// Computer name.
        /// </summary>
        private string _pcName;

        /// <summary>
        /// Computer model.
        /// </summary>
        private string _pcModel;

        /// <summary>
        /// Computer inventory number.
        /// </summary>
        private string _inventoryNumber;

        /// <summary>
        /// Computer serial number.
        /// </summary>
        private string _serialNumber;

        /// <summary>
        /// Computer IP address.
        /// </summary>
        private string _ipAddress;

        /// <summary>
        /// The amount of RAM in a computer. Specified in gigabytes.
        /// </summary>
        private int _ramSize;

        /// <summary>
        /// The amount of computer memory. Specified in gigabytes.
        /// </summary>
        private int _hddSize;

        /// <summary>
        /// Computer motherboard model.
        /// </summary>
        private string _motherboardMode;

        /// <summary>
        /// Computer processor model.
        /// </summary>
        private string _cpuModel;

        /// <summary>
        /// List of software installed on the computer.
        /// </summary>
        private string _installedSoftware;

        /// <summary>
        /// Class instance <see cref="Monitor"/>.
        /// </summary>
        private Monitor _monitor;

        /// <summary>
        /// Returns and sets the office number.
        /// </summary>
        public int Cabinet
        {
            get
            {
                return _cabinet;
            }
            set
            {
                _cabinet = value;
            }
        }

        /// <summary>
        /// Gets and sets the computer name.
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
        /// Returns and sets the computer model.
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
        /// Returns and sets the inventory number of the computer.
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
        /// Returns and sets the serial number of the computer.
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
        /// Returns and sets the IP address of the computer.
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
        /// Returns and sets the computer's RAM capacity. Specified in gigabytes.
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
        /// Returns and sets the amount of computer memory. Specified in gigabytes.
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
        /// Returns and sets the computer's motherboard model.
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
        /// Returns and sets the computer's processor model.
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
        /// Returns and sets a list of installed software (e.g., comma-separated list).
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
        /// Gets and sets the computer monitor. Requires an instance of the class <see cref="Monitor"/>.
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
        /// Creates an instance of a class <see cref="Computer"/>.
        /// </summary>
        public Computer(int cabinet, string pcName, string pcModel, string inventoryNumber, string serialNumber,
                        string ipAddress, int ramSize, int hddSize,
                        string motherboardModel, string cpuModel, string installedSoftware, Monitor monitor)
        {
            Cabinet = cabinet;
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

        /// <summary>
        /// Method called to get the Computer description string.
        /// </summary>
        /// <returns>Line.</returns>
        public override string ToString()
        {
            return $"{PCName} - {PCModel} (Инв. номер: {InventoryNumber})";
        }
    }
}
