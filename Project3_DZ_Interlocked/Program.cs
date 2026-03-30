namespace Project3_DZ_Interlocked
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string root = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Test";
            string[] files = Directory.GetFiles(root);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
