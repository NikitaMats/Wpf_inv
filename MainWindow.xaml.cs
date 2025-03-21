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
        /// Stores a list of devices.
        /// </summary>
        private List<Computer> _computers = [];

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
                _computers = [];
            }
        }

        /// <summary>
        /// Responsible for processing clicks on the save button.
        /// </summary>
        private void AddEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            string pcName = PCNameTextBox.Text;
            string pcModel = PCModelTextBox.Text;
            string inventoryNumber = InventoryNumberTextBox.Text;
            string serialNumber = SerialNumberTextBox.Text;
            string ipAddress = IPAddressTextBox.Text;       
            string motherboardModel = MotherboardModelTextBox.Text;
            string cpuModel = CPUModelTextBox.Text;
            string installedSoftware = InstalledSoftwareTextBox.Text;
            Model.Monitor monitor = new(MonitorModelTextBox.Text, MonitorInventoryNumberTextBox.Text, MonitorSerialNumberTextBox.Text);

            if (!int.TryParse(RAMSizeTextBox.Text, out int ramSize) || !int.TryParse(HDDSizeTextBox.Text, out int hddSize))
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для объема оперативной памяти и жесткого диска.");
                return;
            }

            if (!int.TryParse(CabinetNumberTextBox.Text, out int cabinet))
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для номера кабинета.");
                return;
            }

            Computer computer = new(cabinet, pcName, pcModel, inventoryNumber, serialNumber,
                                              ipAddress, ramSize, hddSize,
                                              motherboardModel, cpuModel,
                                              installedSoftware, monitor);

            _computers.Add(computer);

            AllEquipmentListView.Items.Add(computer);

            ClearInputFields();

            MessageBox.Show("Устройство успешно сохранено!");
        }

        /// <summary>
        /// The method responsible for clearing text fields.
        /// </summary>
        private void ClearInputFields()
        {
            CabinetNumberTextBox.Clear();
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

        /// <summary>
        /// The function is responsible for handling the change of the selected element in the ListView.
        /// </summary>
        private void AllEquipmentListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllEquipmentListView.SelectedItem is Computer selectedComputer)
            {
                CabinetNumberTextBox.Text = selectedComputer.Cabinet.ToString();
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

        /// <summary>
        /// The function is responsible for processing clicks on the save button.
        /// </summary>
        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (AllEquipmentListView.SelectedItem is Computer selectedComputer)
            {
                selectedComputer.Cabinet = int.TryParse(CabinetNumberTextBox.Text, out int cabinet) ? cabinet : 0;
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

                AllEquipmentListView.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите компьютер для редактирования.");
            }
        }

        /// <summary>
        /// The function is responsible for processing clicks on the delete button.
        /// </summary>
        private void DeleteEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (AllEquipmentListView.SelectedItem is Computer selectedComputer)
            {
                _computers.Remove(selectedComputer);

                AllEquipmentListView.Items.Remove(selectedComputer);

                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите компьютер для удаления.");
            }
        }

        /// <summary>
        /// The function is responsible for processing clicks on the filter button.
        /// </summary>
        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            var filteredComputers = Filtration.FilterObjectsWithZeroFields(_computers);

            FilteredListView.ItemsSource = filteredComputers;
        }

        /// <summary>
        /// The function is responsible for processing the click on the search button.
        /// </summary>
        private void SearchCabinetButton_Click(object sender, RoutedEventArgs e)
        {
            string cabinetNumber = SearchCabinetTextBox.Text;

            if (string.IsNullOrEmpty(cabinetNumber))
            {
                MessageBox.Show("Введите номер кабинета.");
                return;
            }

            var filteredComputers = _computers.Where(c => c.Cabinet.ToString() == cabinetNumber).ToList();

            FilteredListView.ItemsSource = filteredComputers;
        }

        /// <summary>
        /// Function triggered when the form is closed. Responsible for saving data.
        /// </summary>
        private void MainForm_FormClosed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serializer.WriteData(_computers);
        }
    }
}