using Prism.Modularity;
using Prism.Regions;

namespace ImageDisplay
{
    public class ImageDisplayModule : IModule
    {
        IRegionManager _regionManager;

        public ImageDisplayModule(RegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ImageDisplay",typeof(Views.ImageDisplay));
        }
    }
}