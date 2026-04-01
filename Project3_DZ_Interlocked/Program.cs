using System.Text;

namespace Project3_DZ_Interlocked
{
    internal class Program
    {
        static class Statistic
        {
            public static int Words = 0;
            public static int Lines = 0;
            public static int Punctuation = 0;

            private static readonly object _locker = new object();
            public static void AddWords(int count)
            {
                Interlocked.Add(ref Words, count);
            }
            public static void AddLines(int count)
            {
                Interlocked.Add(ref Lines, count);
            }

            public static void AddPunctuation(int count)
            {
                lock (_locker) 
                {
                    Punctuation += count;
                }
            }
        }
        static void AnalyzeFile(object filePathObj)
        {
            string filePath = (string)filePathObj;
            int localWords = 0;
            int localLines = 0;
            int localPunctuation = 0;

            char[] punctuationChars = { '.', ',', ';', ':', '-', '—', '‒', '…', '!', '?', '"', '\'', '«', '»', '(', ')', '{', '}', '[', ']', '<', '>', '/' };

            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    localLines++;
                    localWords += line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

                    foreach (char c in line)
                    {
                        if (punctuationChars.Contains(c)) localPunctuation++;
                    }
                }

                Statistic.AddLines(localLines);
                Statistic.AddWords(localWords);
                Statistic.AddPunctuation(localPunctuation);

                Console.WriteLine($"[Потік {Thread.CurrentThread.ManagedThreadId}] Завершив: {Path.GetFileName(filePath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {filePath}: {ex.Message}");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string root = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test");

            string[] files = Directory.GetFiles(root);
            List<Thread> threads = new List<Thread>();

            foreach (string file in files)
            {
                Thread t = new Thread(AnalyzeFile);
                threads.Add(t);
                t.Start(file);
            }
            foreach (var t in threads)
            {
                t.Join();
            }

            Console.WriteLine($"Слів: {Statistic.Words}");
            Console.WriteLine($"Рядків: {Statistic.Lines}");
            Console.WriteLine($"Розділових знаків: {Statistic.Punctuation}");
        }
    }
}
