using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ColmenApp.ViewModels.Base;
using Xamarin.Forms;

namespace ColmenApp.ViewModels.Customers
{
    class AddCustomerViewModel : BaseViewModel
    {
        #region Commands
        public ICommand backCommand => new Command(async () => await Back());

        #endregion

        #region Constructor

        public AddCustomerViewModel()
        {

        }

        #endregion

        #region Methods
        private async Task Back()
        {
            await NavigationService.Return();
        }

        #endregion
        
    }
}
