using ColmenApp.ViewModels;
using ColmenApp.Views.Accounts;
using ColmenApp.Views.Customers;
using ColmenApp.Views.Orders;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ColmenApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabView : TabbedPage
    {
        public MainTabView()
        {
            InitializeComponent();
        }
    }
}