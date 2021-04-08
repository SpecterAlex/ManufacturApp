using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColmenApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ColmenApp.Views.Orders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderView : ContentPage
    {
        public OrderView()
        {
            InitializeComponent();
        }
    }
}