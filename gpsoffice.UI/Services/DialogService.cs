using System;
using System.Diagnostics;
using System.Threading.Tasks;
using gpsoffice.Core.Services.Interfaces;
using Xamarin.Forms;

namespace gpsoffice.UI.Services
{
    public class DialogService : IDialogService
    {
        const string APP_NAME = "GPSOffice";
        public async Task<bool> ShowMessage(string title, string message, string buttonConfirmText, string buttonCancelText)
        {
            try
            {
                var result = await Application.Current.MainPage.DisplayAlert(title, message, buttonConfirmText, buttonCancelText);

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task ShowMessage(string title, string message, string buttonCloseText)
        {
            try
            {
                await Application.Current.MainPage.DisplayAlert(title, message, buttonCloseText);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        public async Task<string> ShowMultipleSelection(string title, string[] options)
        {
            try
            {
                var result = await Application.Current.MainPage.DisplayActionSheet(title, null, null, options);

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task ShowMessage(string message)
        {
            try
            {
                await Application.Current.MainPage.DisplayAlert(APP_NAME, message, "Close");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
