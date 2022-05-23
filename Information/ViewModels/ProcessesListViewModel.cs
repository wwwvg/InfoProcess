using Information.Helpers;
using Information.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Information.ViewModels
{
    internal class ProcessesListViewModel: BindableBase
    {
        private ObservableCollection<ProcessNameID> _processesNameID = new();   // список процессов
        public ObservableCollection<ProcessNameID> ProcessesNameID  
        {
            get { return _processesNameID; }
            set { SetProperty(ref _processesNameID, value); }
        }

        private int _selectedIndex;                                             // выделенный элемент
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { SetProperty(ref _selectedIndex, value); }
        }

        public ProcessesListViewModel()                                         // конструктор
        {
            foreach (var item in Process.GetProcesses())
                _processesNameID.Add(new ProcessNameID { Name = item.ProcessName, ID = item.Id });

            TimerStart();
        }

        private DispatcherTimer _timer = null;                                  //таймер

        private void TimerStart()
        {
            _timer = new DispatcherTimer();  // если надо, то в скобках указываем приоритет, например DispatcherPriority.Render
            _timer.Tick += new EventHandler((sender, e) => 
            {
                List<ProcessNameID> processNameIDs = new();
                foreach (var item in Process.GetProcesses().ToList())
                {
                processNameIDs.Add(new ProcessNameID { Name = item.ProcessName, ID = item.Id });
                }
                UpdateProcessesList.Update(_processesNameID, processNameIDs);
            });
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            _timer.Start();
        }
    }
}
