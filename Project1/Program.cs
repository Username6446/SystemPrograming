using System.Diagnostics;

namespace Project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Process current = Process.GetCurrentProcess();
            //current.PriorityClass = ProcessPriorityClass.RealTime;
            //Console.WriteLine("---- Process Info -----");
            //Console.WriteLine($"Priority Class: {current.PriorityClass}");
            //Console.WriteLine($"Name: {current.ProcessName}");
            //Console.WriteLine($"Id: {current.Id}");
            //Console.WriteLine($"MachineName: {current.MachineName}");
            //Console.WriteLine($"PrivateMemorySize: {current.PrivateMemorySize}");
            //Console.WriteLine($"StartTime: {current.StartTime}");
            //Console.WriteLine($"TotalProcessorTime: {current.TotalProcessorTime}");
            //Console.WriteLine($"UserProcessorTime: {current.UserProcessorTime}");

            //Process[] processes = Process.GetProcesses();
            //Console.WriteLine("Name\t\t\tPID\t\t\tPriority\t\t\tMachine name");
            //foreach (var p in processes)
            //{
            //    try
            //    {
            //        Console.WriteLine($"{p.ProcessName}\t" +
            //        $"{p.Id}\t{p.PriorityClass}\t{p.MachineName}");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine(p.ProcessName);
            //        Console.ResetColor();
            //    }

            //}

            //Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe");
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = @"notepad",
                Arguments = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}",
                WindowStyle = ProcessWindowStyle.Maximized
            };

            Process pr = Process.Start(info);
            Console.ReadKey();
            //pr.Kill();
            pr.CloseMainWindow();
            //pr.Close();
            Console.WriteLine("Wait for exit.......");
            pr.WaitForExit();
            Console.WriteLine($"Exit code: {pr.ExitCode}");
            Console.WriteLine($"Exit code: {pr.ExitTime}");
            Console.ReadKey();
        }
    }
}
