using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Information.ViewModels
{
    internal class ProcessesListViewModel: BindableBase
    {
        private ObservableCollection<Process> _processes = new ObservableCollection<Process>();
        public ObservableCollection<Process> Processes
        {
            get { return _processes; }
            set { SetProperty(ref _processes, value); }
        }



        private string _selectedProcess;
        public string SelectedProcess
        {
            get { return _selectedProcess; }
            set { SetProperty(ref _selectedProcess, value); }
        }

        public ProcessesListViewModel()
        {
            //TimerStart();
            var processes = Process.GetProcesses();
            foreach (var process in processes)
                Processes.Add(process);
        }

        private DispatcherTimer _timer = null;

        private void TimerStart()
        {
            _timer = new DispatcherTimer();  // если надо, то в скобках указываем приоритет, например DispatcherPriority.Render
            _timer.Tick += new EventHandler(TimerTick);
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            _timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {/*
            int id = SelectedProcess.Key;
            //Processes.ex
            Processes.Clear();
            var processes = Process.GetProcesses();
            foreach (var process in processes)
                Processes.Add(new KeyValuePair<int, string>(process.Id, process.ProcessName));
            foreach(var process in Processes)
            {
                if (process.Key == id)
                    SelectedProcess = process;
            }
            */
        }
    }
}
