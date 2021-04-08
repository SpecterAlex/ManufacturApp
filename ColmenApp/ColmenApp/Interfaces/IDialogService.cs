using System.Threading.Tasks;
using Acr.UserDialogs;

namespace ColmenApp.Interfaces
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);
        IProgressDialog Progress(string title, bool show);
        void StartLoading(string message);
        void StopLoading();
    }
}
