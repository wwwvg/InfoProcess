using Information.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Information
{
    public class InformationModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public InformationModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("ProcessesListRegion", typeof(ProcessesList));
            _regionManager.RegisterViewWithRegion("ProcessInfoRegion", typeof(ProcessInfo));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}