using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_inv.Model;

namespace Wpf_inv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Computer> computers = new List<Computer>();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Öâåò îøèáêè.
        /// </summary>
        //private readonly Color _errorColor = Color.LightPink;

        /// <summary>
        /// Öâåò îêíà áåç îøèáîê.
        /// </summary>
        //private readonly Color _normalColor = Color.White;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Считываем данные из полей ввода
            string pcName = PCNameTextBox.Text;
            string pcModel = PCModelTextBox.Text;
            string inventoryNumber = InventoryNumberTextBox.Text;
            string serialNumber = SerialNumberTextBox.Text;
            string ipAddress = IPAddressTextBox.Text;
            int ramSize;
            int hddSize;

            // Пробуем преобразовать значение объема оперативной памяти и жесткого диска в целые числа
            if (!int.TryParse(RAMSizeTextBox.Text, out ramSize) || !int.TryParse(HDDSizeTextBox.Text, out hddSize))
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для объема оперативной памяти и жесткого диска.");
                return;
            }

            string motherboardModel = MotherboardModelTextBox.Text;
            string cpuModel = CPUModelTextBox.Text;
            string installedSoftware = InstalledSoftwareTextBox.Text;

            // Создаем экземпляр класса Monitor (предполагается, что номер и модель монитора вы получаете, например, из каких-либо полей)
            Model.Monitor monitor = new Model.Monitor(MonitorModelTextBox.Text, MonitorInventoryNumberTextBox.Text, MonitorSerialNumberTextBox.Text);

            // Создаем экземпляр класса Computer
            Computer computer = new Computer(pcName, pcModel, inventoryNumber, serialNumber,
                                              ipAddress, ramSize, hddSize,
                                              motherboardModel, cpuModel,
                                              installedSoftware, monitor);

            // Добавляем новый компьютер в список
            computers.Add(computer);

            // Очищаем поля ввода после сохранения
            ClearInputFields();

            // Сообщение об успешном сохранении
            MessageBox.Show("Устройство успешно сохранено!");
        }

        private void ClearInputFields()
        {
            // Очищаем или сбрасываем значения в полях ввода
            PCNameTextBox.Clear();
            PCModelTextBox.Clear();
            InventoryNumberTextBox.Clear();
            SerialNumberTextBox.Clear();
            IPAddressTextBox.Clear();
            RAMSizeTextBox.Clear();
            HDDSizeTextBox.Clear();
            MotherboardModelTextBox.Clear();
            CPUModelTextBox.Clear();
            InstalledSoftwareTextBox.Clear();
            MonitorModelTextBox.Clear();
            MonitorInventoryNumberTextBox.Clear();
            MonitorSerialNumberTextBox.Clear();
        }
    }
}