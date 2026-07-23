using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
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

namespace Project6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            fromTextBox.Text = Source = @"C:\Users\Іван\source\repos\ITSTEP\SystemPrograming_OS\SystemPrograming\Project6\bigfile.txt";
            toTextBox.Text = Destination = @"C:\Users\Іван\Downloads";
        }

        private void Source_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == true)
            {
                fromTextBox.Text = Source = dialog.FileName;
            }
        }

        private void Dest_Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if( dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                toTextBox.Text = Destination = dialog.FileName;
            }
        }

        private void Copy_Button_Click(object sender, RoutedEventArgs e)
        {
            string fileName = System.IO.Path.GetFileName(Source);
            string destFullPath = System.IO.Path.Combine(Destination, fileName);
            File.Copy(Source, destFullPath, true);
            MessageBox.Show("File copied!!!");
        }
        private Task FileCopyAsync(string source, string dest)
        {
            return Task.Run(() =>
            {
                File.Copy(source, dest, true);
            });
        }
    }
}