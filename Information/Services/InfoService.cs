using System.Diagnostics;
using System.Globalization;

namespace Information.Services
{
    public static class InfoService
    {
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
            var pc = new PerformanceCounter("Process", "% Processor Time", processName, true);
            return pc.NextValue().ToString(CultureInfo.InvariantCulture);
        }

        public static string WorkingSet(int id)
        {
            return Process.GetProcessById(id).WorkingSet64.ToString();
        }
    }
}
