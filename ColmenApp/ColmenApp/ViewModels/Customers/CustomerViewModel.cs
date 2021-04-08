using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using ColmenApp.Models;
using ColmenApp.Models.Responses.Pagination;
using ColmenApp.ViewModels.Base;
using Xamarin.Forms;

namespace ColmenApp.ViewModels.Customers
{
    class CustomerViewModel : BaseViewModel
    {
        #region Constants

        const int RefreshDuration = 2;

        #endregion

        #region Properties

        public ObservableCollection<Customer> CustomerList { get; set; }
        public Customer SelectedCustomer { get; set; }

        public int ItemTreshold { get; set; }
        public int ActualPage { get; set; }
        public int LastPage { get; set; }
        public bool IsRefreshing { get; set; }

        #endregion

        #region Commands
        //public ICommand ATSelectionChangedCommand => new Command(Tapped);
        public ICommand ItemTresholdReachedCommand => new Command(async () => await ItemsTresholdReached());
        public ICommand moveToAddCustomerCommand => new Command(async () => await moveToAddCustomer());

        public ICommand RefreshCommand => new Command(async () => await RefreshDataAsync());



        #endregion

        #region Constructor

        public CustomerViewModel()
        {
            ItemTreshold = 4;
            CustomerList = new ObservableCollection<Customer>();
            LoadInitialCustomersAsync();
        }

        #endregion

        #region Methods

        private async Task ItemsTresholdReached()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                if (!(ActualPage >= LastPage))
                {
                    var items = await GetCustomersAsync(ActualPage+1);
                    foreach (var item in items)
                    {
                        CustomerList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void LoadInitialCustomersAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ActualPage = 1;
                CustomerList.Clear();

                var items = await GetCustomersAsync(ActualPage);
                foreach (var item in items)
                {
                    CustomerList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task LoadCustomersAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ActualPage = 1;
                CustomerList.Clear();

                var items = await GetCustomersAsync(ActualPage);
                foreach (var item in items)
                {
                    CustomerList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task RefreshDataAsync()
        {
            IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            await LoadCustomersAsync();
            IsRefreshing = false;
        }
        private async Task<ObservableCollection<Customer>> GetCustomersAsync(int numberOfPage)
        {
            ObservableCollection<Customer> customer = new ObservableCollection<Customer>();
            var apiResponse = new ResponsePaginate<Customer>(ref customer);
            apiResponse = await ApiService.GetAllCustomers(numberOfPage, App.Token);
            
            ActualPage = apiResponse.CurrentPage;
            LastPage = apiResponse.LastPage;

            return apiResponse.data;
        }
        private async Task moveToAddCustomer()
        {
            await NavigationService.NavigateToAsync<AddCustomerViewModel>();
        }

        #endregion
    }
}
