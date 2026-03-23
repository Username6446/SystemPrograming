using System.Diagnostics;
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

namespace Project1_DZ_TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = Process.GetProcesses();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem is Process selected)
            {
                selected.Kill();
            }
            else
            {
                MessageBox.Show("Select one item from table!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (grid.SelectedItem is Process selected)
            {
                MessageBox.Show($"{selected.ProcessName} Select one item from table!");
                bool falg = selected.CloseMainWindow();
                MessageBox.Show($"{falg}123123");
            }
            else
            {
                MessageBox.Show("Select one item from table!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem is Process selected)
            {
                StringBuilder info = new StringBuilder();

                try
                {
                    info.AppendLine("---- Process Info -----");
                    info.AppendLine($"Name: {selected.ProcessName}");
                    info.AppendLine($"Id: {selected.Id}");
                    info.AppendLine($"Priority Class: {selected.PriorityClass}");
                    info.AppendLine($"Machine Name: {selected.MachineName}");
                    info.AppendLine($"Private Memory: {selected.PrivateMemorySize64 / 1024 / 1024} MB");
                    info.AppendLine($"Start Time: {selected.StartTime}");
                    info.AppendLine($"Total CPU Time: {selected.TotalProcessorTime}");
                    info.AppendLine($"User CPU Time: {selected.UserProcessorTime}");

                    MessageBox.Show(info.ToString(), "Process Details", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Access Denied:\nDetails: {ex.Message}",
                                    "System Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Select one item from table!");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string nameToStart = processName.Text;
            if (!string.IsNullOrWhiteSpace(nameToStart))
            {
                try
                {
                    Process.Start(new ProcessStartInfo(nameToStart) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem is Process selected)
            {
                string nameProcessToStart = processName.Text;
                MessageBox.Show($"{selected.ProcessName} \t{nameProcessToStart}", "Some text", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Select one item from table!");
            }
        }
    }
}