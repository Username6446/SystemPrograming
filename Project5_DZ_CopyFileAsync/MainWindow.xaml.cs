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
            string targetFolder = toTb.Text;
            string destination = Path.Combine(targetFolder, "CopiedFile_" + DateTime.Now.ToString("HHmmss") + ".txt");

            var progressReporter = new Progress<double>(value =>
            {
                progressBar.Value = value;
            });

            try
            {
                progressBar.Value = 0;
                string fileName = await CopyFileWithProgressAsync(source, destination, progressReporter);

                MessageBox.Show($"Файл {fileName} успішно скопійовано!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
        Task<string> CopyFileWithProgressAsync(string source, string dest, IProgress<double> progress)
        {
            return Task.Run(async () =>
            {
                using (FileStream sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read))
                using (FileStream destStream = new FileStream(dest, FileMode.Create, FileAccess.Write))
                {
                    long totalBytes = sourceStream.Length;
                    long totalRead = 0;
                    byte[] buffer = new byte[1024 * 1024];
                    int read;

                    while ((read = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await destStream.WriteAsync(buffer, 0, read);
                        totalRead += read;

                        double percentage = (double)totalRead / totalBytes * 100;

                        progress?.Report(percentage);
                        await Task.Delay(50);
                    }
                }
                return Path.GetFileName(dest);
            });
        }
    }
}