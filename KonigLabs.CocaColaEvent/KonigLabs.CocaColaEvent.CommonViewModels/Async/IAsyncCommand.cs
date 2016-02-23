using System.Threading.Tasks;
using System.Windows.Input;

namespace KonigLabs.CocaColaEvent.CommonViewModels.Async
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}
