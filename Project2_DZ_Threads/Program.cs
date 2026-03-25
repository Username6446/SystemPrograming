using System;
using System.Text;

namespace Project2_DZ_Threads
{
    internal class Program
    {
        static void Ex1()
        {
            for (int i = 1; i <= 50; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void Ex2(object? a)
        {
            var data = (Tuple<int, int>)a!;
            for (int i = data.Item1; i <= data.Item2; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void Ex3(object? a)
        {
            var data = (Tuple<int, int, int>)a!;
            for(int i = 0; i<data.Item3;i++)
            {
                Thread thread = new Thread(Ex2);
                thread.Start(new Tuple<int, int>(data.Item1, data.Item2));

            }
            
        }

        static void MinArr(object? a)
        {
            int[] arr = (int[])a!;
            Console.WriteLine($"Min : {arr.Min()}");

        }
        static void MaxArr(object? a)
        {
            int[] arr = (int[])a!;
            Console.WriteLine($"Max : {arr.Max()}");

        }
        static void AvgArr(object? a)
        {
            int[] arr = (int[])a!;
            Console.WriteLine($"Avg : {arr.Average()}");

        }
        static void PrintArr(object? a)
        {
            int[] arr = (int[])a!;
            foreach (var item in arr)
            {
                Console.WriteLine($"Element of arr {item}");
            }
        }
        static void PrintFileArr(object? a)
        {
            int[] arr = (int[])a!;
            File.AppendAllLines("Arr.txt", arr.Select(x => x.ToString()));
            StringBuilder results = new StringBuilder("--- Results ---\n");
            results.AppendLine($"Min: {arr.Min()}");
            results.AppendLine($"Max: {arr.Max()}");
            results.AppendLine($"Avg: {arr.Average()}");
            File.AppendAllText("Arr.txt", results.ToString());
        }
        static void Ex4_5(object? a)
        {

            int[] arr = new int[100];
            for (int i = 0; i < 100; i++)
            {
                arr[i] = new Random().Next(100);
            }
            Thread thread1 = new Thread(PrintArr);
            thread1.Start(arr);
            Thread thread2 = new Thread(MinArr);
            thread2.Start(arr);
            Thread thread3 = new Thread(MaxArr);
            thread3.Start(arr);
            Thread thread4 = new Thread(AvgArr);
            thread4.Start(arr);
            Thread thread5 = new Thread(PrintFileArr);

            thread1.Join();
            thread5.Start(arr);
        }
        static void Main(string[] args)
        {

            //Thread thread = new Thread(Ex1);
            //thread.Start();

            //Tuple<int, int> tuple = new Tuple<int, int>(25, 50);
            //Thread thread = new Thread(Ex2);
            //thread.Start(tuple);

            //Tuple<int, int, int> tuple = new Tuple<int, int, int>(25, 50, 4);
            //Thread thread = new Thread(Ex3);
            //thread.Start(tuple);

            Thread thread = new Thread(Ex4_5);
            thread.Start();

        }
    }
}
