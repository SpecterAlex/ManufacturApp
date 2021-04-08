using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using ColmenApp.Cache;
using ColmenApp.Interfaces;
using ColmenApp.Models;
using ColmenApp.Models.Responses;
using ColmenApp.Utils;
using ColmenApp.ViewModels.Base;
using Xamarin.Forms;

namespace ColmenApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Properties
        
        public string Username { get; set; }

        public string Password { get; set; }

        #endregion

        #region Commands

        public ICommand LoginCommand => new Command(Login);
        #endregion

        #region Singleton

        #endregion

        #region Constructor

        public LoginViewModel()
        {

        }

        #endregion

        #region Methods

        private async void Login()
        {
            try
            {
                if (IsValidFields())
                {
                    DialogService.StartLoading("Iniciando sesión...");
                    LoginResponse loginResponse = new LoginResponse();
                    ResponseApi<LoginResponse> apiResponse = new ResponseApi<LoginResponse>(ref loginResponse);
                    apiResponse = await ApiService.LoginUser(new Models.Requests.LoginRequest() { Username = this.Username, Password = this.Password });
                    if (apiResponse.Status != "success")
                    {
                        UserDialogs.Instance.Alert("Usuario o contraseña invalidos", "ERROR", "Aceptar");
                        DialogService.StopLoading();
                        return;
                    }

                    var Login = Settings.GetJsonGeneralSetting();
                    if (Login == null)
                        Login = new GeneralSetting();

                    Login.IsLogged = true;
                    Login.Mail = Username;
                    Login.Password = Password;
                    Login.UserId = apiResponse.data.User.Id.ToString();
                    Login.Token = apiResponse.data.AccessToken;
                    Login.FirstName = apiResponse.data.User.FirstName;
                    Login.LastName = apiResponse.data.User.LastName;
                    App.Token = Login.Token;

                    Settings.SetJsonGeneralSetting(Login);
                    DialogService.StopLoading();
                    await NavigationService.NavigateToAsync<MainTabViewModel>();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message, "ERROR", "Aceptar");
            }
        }

        private bool IsValidFields()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                UserDialogs.Instance.Alert("Debe ingresar su correo electrónico.", "Campo vacío", "Aceptar");
                return false;
            }

            if (!RegexUtil.ValidEmailAdress().IsMatch(Username))
            {
                UserDialogs.Instance.Alert("Debe ingresar un correo electrónico válido.", "Campo inválido", "Aceptar");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                UserDialogs.Instance.Alert("Debe ingresar su contraseña.", "Campo vacío", "Aceptar");
                return false;
            }

            return true;
        }

        #endregion

    }
}
