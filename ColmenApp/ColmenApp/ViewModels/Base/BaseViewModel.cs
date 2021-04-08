using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ColmenApp.Interfaces;

namespace ColmenApp.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly INavigationService NavigationService;

        protected readonly IApiService ApiService;

        protected readonly IDialogService DialogService;

        public bool IsBusy { get; set; }
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public BaseViewModel()
        {
            IsBusy = false;
            NavigationService = ViewModelLocator.Resolve<INavigationService>();
            ApiService = ViewModelLocator.Resolve<IApiService>();
            DialogService = ViewModelLocator.Resolve<IDialogService>();
        }

        public void OnPropertyChangedEventArgs([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
