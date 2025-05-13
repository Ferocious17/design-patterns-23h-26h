namespace ZbW.DesignPatterns.Singleton.Threads
{
    using System;
    using System.Collections.Generic;

    using Zbw.DesignPatterns.Singleton;

    public class PoorMansPrintSpooler
    {
        private static PoorMansPrintSpooler? _instance;

        private readonly Queue<PrintJob> _jobs;
        private volatile bool _cancelRequested;

        private PoorMansPrintSpooler()
        {
            _jobs = new Queue<PrintJob>();
        }

        private void ProcessPrintJobs()
        {
            while (!_cancelRequested)
            {
                if (_jobs.Count > 0)
                {
                    var printJob = _jobs.Dequeue();
                    Console.WriteLine($"Print Job: {printJob}");
                }
            }
        }

        public void Start()
        {
            ProcessPrintJobs();
        }

        public void Stop()
        {
            _cancelRequested = true;
        }

        public void Print(PrintJob printJob)
        {
            _jobs.Enqueue(printJob);
        }

        public static PoorMansPrintSpooler GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PoorMansPrintSpooler();
            }

            return _instance;
        }
    }
}
