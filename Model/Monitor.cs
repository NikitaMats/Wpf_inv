namespace Wpf_inv.Model
{
    /// <summary>
    /// The class responsible for storing data about monitors.
    /// </summary>
    internal class Monitor
    {
        /// <summary>
        /// Monitor model.
        /// </summary>
        private string _model;

        /// <summary>
        /// Monitor inventory number.
        /// </summary>
        private string _inventoryNumber;

        /// <summary>
        /// Serial number of the monitor.
        /// </summary>
        private string _serialNumber;

        /// <summary>
        /// Gets and sets the monitor model.
        /// </summary>
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        /// <summary>
        /// Returns and sets the inventories number of the monitor.
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
        /// Returns and sets the serial number of the monitor.
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
        /// Creates an instance of a class <see cref="Monitor"/>.
        /// </summary>
        public Monitor(string model, string inventoryNumber, string serialNumber)
        {
            Model = model;
            InventoryNumber = inventoryNumber;
            SerialNumber = serialNumber;
        }   
    }
}
