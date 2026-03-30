namespace Project4
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"{Title}. {Author}";
        }
    }
    internal class Program
    {
        static void Display()
        {
            Console.WriteLine("Start Method Dosplay");
            Console.WriteLine("Task 1:");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            // some code
            Console.WriteLine("End Method Dosplay");
        }
        static void Main(string[] args)
        {
            #region Task
            //Task task1 = new Task(Display);
            //task1.Start();

            ////start automaticly

            //Task task2 = Task.Factory.StartNew(() => Console.WriteLine($"Task 2 " +
            //    $"{Thread.CurrentThread.ManagedThreadId}"));

            //Task task3 = Task.Run(() => Console.WriteLine($"Task 3. From Thread: " +
            //    $"{Thread.CurrentThread.ManagedThreadId}"));

            //Console.WriteLine("End Method Main");
            //Console.ReadKey();
            #endregion

            #region Task Method
            //Task task1 = new Task(Display);
            //task1.Start();
            //task1.Wait(); // freeze
            //Console.WriteLine("Task end work");
            #endregion

            #region Array Tasks
            //Random random = new Random();
            //Task[] tasks = new Task[3]
            //{
            //    new Task(() => Console.WriteLine("First Task")),
            //    new Task(() => Console.WriteLine("Second Task")),
            //    new Task(() => Console.WriteLine("Third Task")),
            //};
            //foreach (var task in tasks)
            //{
            //    task.Start();
            //}
            //Task.WaitAll(tasks);
            //Console.WriteLine("All task have done");
            //Task[] tasks2 = new Task[3];
            //int j = 0;
            //for(int i=0;i<tasks2.Length; i++)
            //{
            //    tasks2[i] = Task.Run(() =>
            //    {
            //        Thread.Sleep(random.Next(5000));
            //        Console.WriteLine($"task {++j} work");
            //    });
            //}
            //Task.WaitAny(tasks2);
            //Console.WriteLine("Any task have done");
            //Console.ReadLine();
            #endregion

            #region Continue With

            //Task task = new Task(() =>
            //{
            //    Console.WriteLine($"Task Id : {Task.CurrentId}");
            //    Thread.Sleep(1000);
            //});

            //Task continueTask = task.ContinueWith(Display2)
            //    .ContinueWith(Display2)
            //    .ContinueWith(Display2);

            //task.Start();   
            //continueTask.Wait();
            //Console.WriteLine("Main is working....");
            //Console.ReadLine();
            #endregion

            #region Task Return 
            Task<int> task = new Task<int>(() => Factorial(5, 88, 9, "Hello"));
            Task<int> sumTask = task.ContinueWith(Summa);
            task.Start();
            Console.WriteLine(task.Result);
            Console.WriteLine("-----------------");
            Console.WriteLine(sumTask.Result);

            Task<Book> task3 = new Task<Book>(() =>
            {
                Thread.Sleep(3000);
                return new Book { Title = "Harry Potter", Author = "Diana Rouling" };
            });
            task3.Start();

            Book b = task3.Result;
            Console.WriteLine($"{b.Title}. {b.Author}");
            Console.ReadLine();
            #endregion
        }
        static int Summa(Task<int> prev_task)
        {
            int sum = prev_task.Result + prev_task.Result;
            return sum;
        }
        static int Factorial(int x, int a, int b, string text)
        {
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(text);
            int result = 1;
            for(int i = 1;i<=x;i++)
            {
                result *= i;
            }
            return result;
        }
        static void Display2(Task prev)
        {
            Console.WriteLine("Start method Display");
            Console.WriteLine($"Task Id : {Task.CurrentId}");
            Console.WriteLine($"Previous Task Id : {prev.Id}");
            // some code
            Console.WriteLine("End method Display");
        }
    }
}
