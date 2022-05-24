using Information.Helpers;
using Information.Models;
using Prism.Mvvm;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Threading;
using Information.Events;

namespace Information.ViewModels
{
    internal class ProcessesListViewModel: BindableBase
    {
        private ObservableCollection<ProcessNameId> _processesNameId = new();   // список процессов
        private readonly IEventAggregator _eventAggregator;
        public ObservableCollection<ProcessNameId> ProcessesNameId  
        {
            get => _processesNameId;
            set => SetProperty(ref _processesNameId, value);
        }

        private int _selectedIndex;                                             // выделенный элемент
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => SetProperty(ref _selectedIndex, value);
        }

        public ProcessesListViewModel(IEventAggregator eventAggregator)                                         // конструктор
        {
            _eventAggregator = eventAggregator;
            foreach (var item in Process.GetProcesses())
                _processesNameId.Add(new ProcessNameId { Name = item.ProcessName, Id = item.Id });

            TimerStart();
        }

        private DispatcherTimer _timer = null;                                  //таймер

        private void TimerStart()
        {
            _timer = new DispatcherTimer();  // если надо, то в скобках указываем приоритет, например DispatcherPriority.Render
            _timer.Tick += new EventHandler((sender, e) =>
            {
                var processNameIDs = Process.GetProcesses().ToList().Select(item => new ProcessNameId { Name = item.ProcessName, Id = item.Id }).ToList();
                /*
                List<ProcessNameId> processNameIDs = new();
                foreach (var item in Process.GetProcesses().ToList())
                {
                    processNameIDs.Add(new ProcessNameId { Name = item.ProcessName, Id = item.Id });
                }
                */
                UpdateProcessesList.Update(_processesNameId, processNameIDs);
                var keyValuePair = new KeyValuePair<int, string>(_processesNameId.ElementAt(_selectedIndex).Id, _processesNameId.ElementAt(_selectedIndex).Name);
                _eventAggregator.GetEvent<ProcessChanged>().Publish(keyValuePair);
            });
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 2000);
            _timer.Start();
        }
    }
}
