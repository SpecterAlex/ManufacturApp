﻿using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using ColmenApp.Interfaces;
using ColmenApp.ViewModels;
using ColmenApp.ViewModels.Base;
using ColmenApp.Views;
using Xamarin.Forms;

namespace ColmenApp.Services
{
    public class NavigationService : INavigationService
    {
        public BaseViewModel PreviousPageViewModel
        {
            get
            {
                var mainPage = Application.Current.MainPage as NavigationPage;
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return viewModel as BaseViewModel;
            }
        }

        public Task InitializeAsync()
        {
            return NavigateToAsync<LoginViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task RemoveLastFromBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as NavigationPage;

            if (mainPage != null)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        public Task RemoveBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as NavigationPage;

            if (mainPage != null)
            {
                for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
                {
                    var page = mainPage.Navigation.NavigationStack[i];
                    mainPage.Navigation.RemovePage(page);
                }
            }

            return Task.FromResult(true);
        }

        public Task Return()
        {
            return InternalPopAsync();
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType, parameter);

            if (page is MainTabView)
            {
                Application.Current.MainPage = new NavigationPage(page);
            }
            else
            {
                var navigationPage = Application.Current.MainPage as NavigationPage;
                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    Application.Current.MainPage = new NavigationPage(page);
                }
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        private async Task InternalPopAsync()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return;
            }

        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
                throw new Exception($"Cannot locate page type for {viewModelType}");

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName =
                viewModelType.FullName.Replace("Model", string.Empty);

            var viewModelAssemblyName =
                viewModelType.GetTypeInfo().Assembly.FullName;

            var viewAssemblyName =
                string.Format(CultureInfo.InvariantCulture, "{0},{1}", viewName, viewModelAssemblyName);

            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }
    }
}
