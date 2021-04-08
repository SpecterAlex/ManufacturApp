using System.Threading.Tasks;
using Acr.UserDialogs;
using ColmenApp.Interfaces;

namespace ColmenApp.Services
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }

        public IProgressDialog Progress(string title, bool show)
        {
            return UserDialogs.Instance.Progress(title,null,null,show,null);
        }
        public void StartLoading(string message)
        {
            UserDialogs.Instance.ShowLoading(message);
        }

        public void StopLoading()
        {
            UserDialogs.Instance.HideLoading();
        }
    }
}
