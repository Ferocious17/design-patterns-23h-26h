namespace DesignPatterns.Singleton
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    using ZbW.DesignPatterns.Singleton.Threads;
    using ZbW.DesignPatterns.Singleton.Tpl;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            ThreadingPrintSpooler.Instance.Start();

            using var numberPrinter = new NumberPrinter();
            using var textPrinter = new TextPrinter();

            Console.ReadLine();
            ThreadingPrintSpooler.Instance.Stop();
            Console.ReadLine();
        }
    }
}
