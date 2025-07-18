using SynchronizingResourceAccess;

partial class Program
{
    private static void MethodA()
    {
        // lock (SharedObjects.Conch)
        // {
        //     for (int i = 0; i < 5; i++)
        //     {
        //         // Simulate two seconds of work on the current thread.
        //         Thread.Sleep(Random.Shared.Next(2000));

        //         // Concatenate the letter "A" to the shared message.
        //         SharedObjects.Message += "A";
        //     }
        // }

        try
        {
            if (Monitor.TryEnter(SharedObjects.Conch, TimeSpan.FromSeconds(15)))
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(Random.Shared.Next(2000));
                    SharedObjects.Message += "A";
                    Interlocked.Increment(ref SharedObjects.Counter);
                }
            }
            else
            {
                WriteLine("Method A timed out when entering  a monitor on conch.");
            }
        }
        finally
        {
            Monitor.Exit(SharedObjects.Conch);
        }
    }

    private static void MethodB()
    {
        try
        {
            if (Monitor.TryEnter(SharedObjects.Conch, TimeSpan.FromSeconds(15)))
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(Random.Shared.Next(2000));
                    SharedObjects.Message += "B";
                    Write(".");
                    Interlocked.Increment(ref SharedObjects.Counter);
                }
            }
            else
            {
                WriteLine("Method B timed out when entering  a monitor on conch.");
            }
        }
        finally
        {
            Monitor.Exit(SharedObjects.Conch);
        }
    }    
}
