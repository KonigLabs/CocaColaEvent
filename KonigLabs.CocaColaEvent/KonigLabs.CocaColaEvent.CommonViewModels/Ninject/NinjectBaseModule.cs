
using KonigLabs.CocaColaEvent.CommonViewModels.Messenger;
using KonigLabs.CocaColaEvent.CommonViewModels.Services;
using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Navigation;
using Ninject.Modules;

namespace KonigLabs.CocaColaEvent.CommonViewModels.Ninject
{
    public class NinjectBaseModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IMappingEngine>()
            //    .ToMethod(x => MappingEngineConfigurator.CreateEngine(new BasicProfile()));

            Bind<MessageFactory>().ToSelf();
            Bind<IMessenger>().To<MvvmLightMessenger>().InSingletonScope();
            Bind<ViewModelStorage>().ToSelf().InSingletonScope();
            Bind<IDialogService>().To<DialogService>();
        }
    }
}
