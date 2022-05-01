using InfoProcess.Views;
using Information;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace InfoProcess
{
    public partial class App
    {
        protected override Window CreateShell() // устанавливаем главное окно
        {
            return Container.Resolve<MainWindow>(); 
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog) 
        {
            moduleCatalog.AddModule<InformationModule>(); // регистрируем модуль
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
