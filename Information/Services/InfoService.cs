using System;
using System.Diagnostics;
using System.Globalization;

namespace Information.Services
{
    public static class InfoService
    {
        static readonly PerformanceCounter _total_cpu = new PerformanceCounter("Process", "% Processor Time", "_Total");
        static PerformanceCounter _process_cpu = new PerformanceCounter("Process", "% Processor Time", "Idle");
        static string _processName;

        public static string HandleCount(int id)
        {
            return Process.GetProcessById(id).HandleCount.ToString();
        }

        public static string PrivateMemorySize(int id)
        {
            return Process.GetProcessById(id).PrivateMemorySize64.ToString();
        }

        public static string ProcessorUsage(string processName)
        {
            if(_processName != processName)
            {
                _process_cpu.Dispose();
                _process_cpu = new PerformanceCounter("Process", "% Processor Time", processName); 
                _processName = processName;
            }
            float percentage = _process_cpu.NextValue() / (/*Environment.ProcessorCount * */_total_cpu.NextValue()) * 100;
            return string.Format("{0:f1}", percentage);
        }

        public static string WorkingSet(int id)
        {
            return Process.GetProcessById(id).WorkingSet64.ToString();
        }
    }
}
