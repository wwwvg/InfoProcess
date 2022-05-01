using Prism.Mvvm;

namespace InfoProcess.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Process info";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
