using System.Threading.Tasks;
using ColmenApp.ViewModels.Base;

namespace ColmenApp.Interfaces
{
    public interface INavigationService
    {
        BaseViewModel PreviousPageViewModel { get; }

        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task RemoveLastFromBackStackAsync();
        Task RemoveBackStackAsync();
        Task Return();
    }
}
