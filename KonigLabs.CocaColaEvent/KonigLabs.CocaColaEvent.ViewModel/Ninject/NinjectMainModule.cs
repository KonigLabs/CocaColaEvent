
using KonigLabs.CocaColaEvent.CommonViewModels.Messenger;
using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Factories;
using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Navigation;
using KonigLabs.CocaColaEvent.ViewModel.Factories;
using KonigLabs.CocaColaEvent.ViewModel.Providers;
using KonigLabs.CocaColaEvent.ViewModel.ViewModels;
using Ninject;
using Ninject.Modules;
using System.Collections.Generic;
using System.Linq;

namespace KonigLabs.CocaColaEvent.ViewModel.Ninject
{
    public class NinjectMainModule: NinjectModule
    {
        public override void Load()
        {

            Bind<ElementProvider>().ToSelf();
            Bind<MainViewModel>().ToSelf();
            Bind<WelcomViewModel>().ToSelf();
            Bind<WelcomViewModelFactory>().ToSelf();
            Bind<IViewModelNavigator>().To<ViewModelNavigator>()
                .WithConstructorArgument(typeof(IChildrenViewModelsFactory),
                    x => new ChildrenViewModelsFactory(Enumerable.Empty<IViewModelFactory>()));
            Bind<IViewModelNavigator>().To<ViewModelNavigator>().WhenInjectedExactlyInto<MainViewModel>().WithConstructorArgument(typeof(IChildrenViewModelsFactory), x =>
            {
                var children = new List<IViewModelFactory>
                {
                    x.Kernel.Get<WelcomViewModelFactory>(),

                };

                return new ChildrenViewModelsFactory(children);
            });
            Bind<IViewModelNavigator>().To<ViewModelNavigator>().WhenInjectedExactlyInto<WelcomViewModelFactory>().WithConstructorArgument(typeof(IChildrenViewModelsFactory), x =>
            {
                var children = new List<IViewModelFactory>
                {
                    x.Kernel.Get<SelectTypeViewModelFactory>(),

                };

                return new ChildrenViewModelsFactory(children);
            });
            Bind<IViewModelNavigator>().To<ViewModelNavigator>().WhenInjectedExactlyInto<SelectTypeViewModelFactory>().WithConstructorArgument(typeof(IChildrenViewModelsFactory), x =>
            {
                var children = new List<IViewModelFactory>
                {
                    x.Kernel.Get<SelectSizeViewModelFactory>(),

                };

                return new ChildrenViewModelsFactory(children);
            });
            Bind<IViewModelNavigator>().To<ViewModelNavigator>().WhenInjectedExactlyInto<SelectSizeViewModelFactory>().WithConstructorArgument(typeof(IChildrenViewModelsFactory), x =>
            {
                var children = new List<IViewModelFactory>
                {
                    x.Kernel.Get<SelectDesignViewModelFactory>(),

                };

                return new ChildrenViewModelsFactory(children);
            });
            Bind<IViewModelNavigator>().To<ViewModelNavigator>().WhenInjectedExactlyInto<SelectDesignViewModelFactory>().WithConstructorArgument(typeof(IChildrenViewModelsFactory), x =>
            {
                var children = new List<IViewModelFactory>
                {
                    x.Kernel.Get<SelectTextViewModelFactory>(),

                };

                return new ChildrenViewModelsFactory(children);
            });
            Bind<IViewModelNavigator>().To<ViewModelNavigator>().WhenInjectedExactlyInto<SelectTextViewModelFactory>().WithConstructorArgument(typeof(IChildrenViewModelsFactory), x =>
            {
                var children = new List<IViewModelFactory>
                {
                    x.Kernel.Get<ResultViewModelFactory>(),

                };

                return new ChildrenViewModelsFactory(children);
            });
        }
    }
}
