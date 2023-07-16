namespace SolidConsoleApp
{
    public class BeforeMessageLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
        public void Info(string message)
        {
            Console.WriteLine("Info: {0}", message);
        }
        public void Debug(string message)
        {
            //Console.WriteLine("Debug: {0}", message); // Doing changes in concreate class; It violates open/closed principle.
            Console.WriteLine("Dev Debug: {0}", message);
        }
    }

    public class AfterMessageLogger // To solve, we can either use "virtual" or "abstract" method so, we can extend the class and re-implement the method.
    {
        public virtual void Log(string message)
        {
            Console.WriteLine(message);
        }
        public virtual void Info(string message)
        {
            Console.WriteLine("Info: {0}", message);
        }
        public virtual void Debug(string message)
        {
            Console.WriteLine("Debug: {0}", message);
        }
    }

    public class DevMessageLogger : AfterMessageLogger
    {
        public override void Debug(string message)
        {
            Console.WriteLine("Dev Debug: {0}", message);
        }
    }

    public class OpenClosed
    {
        public static void Run()
        {
            var logger = new AfterMessageLogger();
            logger.Debug("Hello, Logger");

            logger = new DevMessageLogger();
            logger.Debug("Hello, New Logger");
        }
    }
}
