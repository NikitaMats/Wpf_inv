namespace Wpf_inv.Model
{
    /// <summary>
    /// Класс отвечающий за хранение данных о мониторах.
    /// </summary>
    internal class Monitor
    {
        /// <summary>
        /// Модель монитора.
        /// </summary>
        private string _model;

        /// <summary>
        /// Инвентаризационный номер монитора.
        /// </summary>
        private string _inventoryNumber;

        /// <summary>
        /// Серийный номер монитора.
        /// </summary>
        private string _serialNumber;

        /// <summary>
        /// Возвращает и задаёт модель монитора.
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
        /// Возвращает и задаёт инвентаризационный номер монитора.
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
        /// Возвращает и задаёт серийный номер монитора.
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
        /// Создаёт экземпляр класса <see cref="Monitor"/>.
        /// </summary>
        public Monitor(string model, string inventoryNumber, string serialNumber)
        {
            Model = model;
            InventoryNumber = inventoryNumber;
            SerialNumber = serialNumber;
        }   
    }
}
