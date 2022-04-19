using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace moduleA
{
    public class ModuleAModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            //Using view discovery
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));

            //Using view Injection
            //IRegion region = _regionManager.Regions["ContentRegion"];

            //var view1 = containerProvider.Resolve<ViewA>();
            //region.Add(view1);

            //var view2 = containerProvider.Resolve<ViewA>();
            //view2.Content = new TextBlock()
            //{
            //    Text = "Hello from View 2",
            //    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            //    VerticalAlignment = System.Windows.VerticalAlignment.Center
            //};
            //region.Add(view2);
            //region.Activate(view2);


        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
