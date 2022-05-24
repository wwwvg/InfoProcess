using Prism.Mvvm;
using Prism.Events;
using Information.Events;
using Information.Services;
using System.Collections.Generic;

namespace Information.ViewModels
{
    public class ProcessInfoViewModel : BindableBase
    {
        public ProcessInfoViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<ProcessChanged>().Subscribe(OnProcessChanged);
        }

        private void OnProcessChanged(KeyValuePair<int, string> keyValuePair)
        {
            ProcessName = keyValuePair.Value;
            ProcessorUsage = InfoService.ProcessorUsage(ProcessName);
            WorkingSet = InfoService.WorkingSet(keyValuePair.Key);
            PrivateMemorySize = InfoService.PrivateMemorySize(keyValuePair.Key);
            HandleCount = InfoService.HandleCount(keyValuePair.Key);
        }

        private string _processName;
        public string ProcessName
        {
            get => _processName;
            set => SetProperty(ref _processName, value);
        }

        private string _processorUsage;
        public string ProcessorUsage
        {
            get => _processorUsage;
            set => SetProperty(ref _processorUsage, value);
        }

        private string _workingSet;
        public string WorkingSet
        {
            get => _workingSet;
            set => SetProperty(ref _workingSet, value);
        }

        private string _privateMemorySize;
        public string PrivateMemorySize
        {
            get => _privateMemorySize;
            set => SetProperty(ref _privateMemorySize, value);
        }

        private string _handleCount;
        public string HandleCount
        {
            get => _handleCount;
            set => SetProperty(ref _handleCount, value);
        }
    }
}
