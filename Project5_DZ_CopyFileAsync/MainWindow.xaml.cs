using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace Project5_DZ_CopyFileAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fromTb.Text = @"C:\Users\Іван\source\repos\ITSTEP\SystemPrograming_OS\SystemPrograming\Project5_DZ_CopyFileAsync\bigfile.txt";
            toTb.Text = @"C:\Users\Іван\Downloads";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string source = fromTb.Text;
            string destination = Path.Combine(toTb.Text, $"NewFile_{DateTime.Now.ToString("HHmmss")}.txt");
            try
            {
                string res = await CopyFileAsync(source, destination);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Task<string> CopyFileAsync(string source, string dest)
        {
            return Task.Run(() =>
            {
                File.Copy(source, dest, true);
                return Path.GetFileName(dest);
            });
        }
    }
}