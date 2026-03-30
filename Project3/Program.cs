namespace Project3
{
    class Counter
    {
        public static int count = 0;
    }
    class LockCounter
    {
        private int number;
        private int evenNumbers;
        public int Number { get { return number; } set { } }
        public int EvenNumbers { get { return evenNumbers; } set { } }
        public void UpdateFields()
        {
            for(int i = 0;i<1_000_000;i++)
            {
                lock (this)
                {
                    //Number++;
                    Interlocked.Increment(ref number);
                    if((Number % 2) == 0)
                    {
                        Interlocked.Increment(ref evenNumbers);
                    }
                }
            }
        }
    }
    class LockCounterStatic
    {
        static int number;
        static int evenNumbers;
        public int Number { get { return number; } set { } }
        public int EvenNumbers { get { return evenNumbers; } set { } }
        public static void UpdateFields()
        {
            for(int i = 0;i<1_000_000;i++)
            {
                lock (typeof(LockCounterStatic))
                {
                    number++;
                    if(number%2==0)
                    {
                        evenNumbers++;
                    }
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Problem
            //Thread[] threads = new Thread[5];
            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i] = new Thread(
            //        delegate ()
            //        {
            //            for (int j = 0; j < 1_000_000; j++)
            //            {
            //                ++Counter.count;
            //            }
            //        });
            //    threads[i].Start();
            //}
            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i].Join();
            //}
            //Console.WriteLine($"Counter : {Counter.count}");

            #endregion
            #region Sync

            //Thread[] threads = new Thread[5];

            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i] = new Thread(
            //        delegate ()
            //        {
            //            for (int j = 0; j < 1_000_000; j++)
            //            {
            //                Interlocked.Increment(ref Counter.count);
            //            }
            //        });
            //    threads[i].Start();
            //}
            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i].Join();
            //}
            //Console.WriteLine($"Counter : {Counter.count}");

            #endregion
            #region Lock Counter
            LockCounter counter = new LockCounter();
            Thread[] threads = new Thread[5];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(counter.UpdateFields);
                threads[i].Start();
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
            Console.WriteLine($"All numbers : {counter.Number}");
            Console.WriteLine($"Even numbers: {counter.EvenNumbers}");
            

            #endregion
        }
    }
}
