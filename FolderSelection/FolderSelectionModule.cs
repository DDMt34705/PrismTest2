using Prism.Modularity;
using Prism.Regions;

namespace FolderSelection
{
    public class FolderSelectionModule : IModule
    {
        IRegionManager _regionManager;
        public FolderSelectionModule(RegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("FolderSelection", typeof(Views.FolderSelection));            
        }
    }
}