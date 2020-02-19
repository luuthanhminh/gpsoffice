using System;
using System.Threading.Tasks;

namespace gpsoffice.Core.Services.Interfaces
{
    public interface IDialogService
    {
        Task<bool> ShowMessage(string title, string message, string buttonConfirmText, string buttonCancelText);

        Task<string> ShowMultipleSelection(string title, string[] options);

        Task ShowMessage(string title, string message, string buttonCloseText);

        Task ShowMessage(string message);
    }
}
