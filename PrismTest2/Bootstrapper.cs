using DialogService;
using FolderSelection;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using PrismTest2.Views;
using System;
using System.Windows;

namespace PrismTest2
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        
        protected override void ConfigureModuleCatalog()
        {
            // Module A is defined in the code.
            Type moduleAType = typeof(FolderSelectionModule);
            ModuleCatalog.AddModule(new ModuleInfo(moduleAType.Name, moduleAType.AssemblyQualifiedName));

        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            this.RegisterTypeIfMissing(typeof(ISelectFolderService), typeof(SelectFolderService), true);
            //this.Container.RegisterInstance<CallbackLogger>(this.callbackLogger);
        }
    }
}
