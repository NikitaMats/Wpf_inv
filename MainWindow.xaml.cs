using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf_inv.Model;
using Wpf_inv.Service;

namespace Wpf_inv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Хранит список устройств.
        /// </summary>
        private List<Computer> _computers = new List<Computer>();

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                _computers = Serializer.LoadData();
                for (int i = 0; i <= _computers.Count - 1; i++)
                {
                    AllEquipmentListView.Items.Add(_computers[i]);
                }
            }
            catch
            {
                _computers = new List<Computer>();
            }
        }

        /// <summary>
        /// Отвечает за обработку нажатия на кнопку сохранения.
        /// </summary>
        private void AddEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            // Считываем данные из полей ввода
            string pcName = PCNameTextBox.Text;
            string pcModel = PCModelTextBox.Text;
            string inventoryNumber = InventoryNumberTextBox.Text;
            string serialNumber = SerialNumberTextBox.Text;
            string ipAddress = IPAddressTextBox.Text;
            string cabinet = CabinetNumberTextBox.Text;
            string motherboardModel = MotherboardModelTextBox.Text;
            string cpuModel = CPUModelTextBox.Text;
            string installedSoftware = InstalledSoftwareTextBox.Text;
            int ramSize;
            int hddSize;
            Model.Monitor monitor = new Model.Monitor(MonitorModelTextBox.Text, MonitorInventoryNumberTextBox.Text, MonitorSerialNumberTextBox.Text);

            // Пробуем преобразовать значение объема оперативной памяти и жесткого диска в целые числа
            if (!int.TryParse(RAMSizeTextBox.Text, out ramSize) || !int.TryParse(HDDSizeTextBox.Text, out hddSize))
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для объема оперативной памяти и жесткого диска.");
                return;
            }

            Computer computer = new Computer(pcName, pcModel, inventoryNumber, serialNumber,
                                              ipAddress, ramSize, hddSize,
                                              motherboardModel, cpuModel,
                                              installedSoftware, monitor);

            // Добавляем новый компьютер в список
            _computers.Add(computer);

            // Добавляем информацию о компьютере в ListBox
            AllEquipmentListView.Items.Add(computer);

            // Очищаем поля ввода после сохранения
            ClearInputFields();

            // Сообщение об успешном сохранении
            MessageBox.Show("Устройство успешно сохранено!");
        }

        /// <summary>
        /// Метод отвечающий за очистку текстовых полей.
        /// </summary>
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

        private void AllEquipmentListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllEquipmentListView.SelectedItem is Computer selectedComputer)
            {
                PCNameTextBox.Text = selectedComputer.PCName;
                PCModelTextBox.Text = selectedComputer.PCModel;
                InventoryNumberTextBox.Text = selectedComputer.InventoryNumber;
                SerialNumberTextBox.Text = selectedComputer.SerialNumber;
                IPAddressTextBox.Text = selectedComputer.IPAddress;
                RAMSizeTextBox.Text = selectedComputer.RAMSize.ToString();
                HDDSizeTextBox.Text = selectedComputer.HDDSize.ToString();
                MotherboardModelTextBox.Text = selectedComputer.MotherboardModel;
                CPUModelTextBox.Text = selectedComputer.CPUModel;
                InstalledSoftwareTextBox.Text = selectedComputer.InstalledSoftware;
                MonitorModelTextBox.Text = selectedComputer.Monitor.Model;
                MonitorInventoryNumberTextBox.Text = selectedComputer.Monitor.InventoryNumber;
                MonitorSerialNumberTextBox.Text = selectedComputer.Monitor.SerialNumber;
            }
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, выбран ли элемент в ListView
            if (AllEquipmentListView.SelectedItem is Computer selectedComputer)
            {
                // Обновляем свойства выбранного компьютера
                selectedComputer.PCName = PCNameTextBox.Text;
                selectedComputer.PCModel = PCModelTextBox.Text;
                selectedComputer.InventoryNumber = InventoryNumberTextBox.Text;
                selectedComputer.SerialNumber = SerialNumberTextBox.Text;
                selectedComputer.IPAddress = IPAddressTextBox.Text;
                selectedComputer.RAMSize = int.TryParse(RAMSizeTextBox.Text, out int ramSize) ? ramSize : 0;
                selectedComputer.HDDSize = int.TryParse(HDDSizeTextBox.Text, out int hddSize) ? hddSize : 0;
                selectedComputer.MotherboardModel = MotherboardModelTextBox.Text;
                selectedComputer.CPUModel = CPUModelTextBox.Text;
                selectedComputer.InstalledSoftware = InstalledSoftwareTextBox.Text;
                selectedComputer.Monitor.Model = MonitorModelTextBox.Text;
                selectedComputer.Monitor.InventoryNumber = MonitorInventoryNumberTextBox.Text;
                selectedComputer.Monitor.SerialNumber = MonitorSerialNumberTextBox.Text;

                // Обновляем отображение в ListView
                AllEquipmentListView.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите компьютер для редактирования.");
            }
        }

        private void DeleteEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, выбран ли элемент в ListView
            if (AllEquipmentListView.SelectedItem is Computer selectedComputer)
            {
                // Удаляем выбранный компьютер из списка
                _computers.Remove(selectedComputer);

                // Удаляем элемент из ListView
                AllEquipmentListView.Items.Remove(selectedComputer);

                // Очищаем текстовые поля
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите компьютер для удаления.");
            }
        }

        private void MainForm_FormClosed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serializer.WriteData(_computers);
        }
    }
}