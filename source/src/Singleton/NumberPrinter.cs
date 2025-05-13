namespace DesignPatterns.Singleton
{
    using System;
    using System.Threading;

    using Zbw.DesignPatterns.Singleton;

    using ZbW.DesignPatterns.Singleton.Threads;

    public class NumberPrinter : IDisposable
    {
        private readonly Timer _timer;
        private int count;

        public NumberPrinter()
        {
            _timer = new Timer(OnPrint, null, 0, 2000);
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        private void OnPrint(object? state)
        {
            ThreadingPrintSpooler.Instance.Print(new PrintJob($"{count}"));
            count++;
        }
    }
}
