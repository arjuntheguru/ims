using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IMS.WebApp.Services
{
    public class SnackbarHandler
    {
        private readonly ISnackbar _snackbar;
        public SnackbarHandler(ISnackbar snackbar)
        {
            _snackbar = snackbar;
        }

        public void ShowSnackbar(bool IsSuccess, string message)
        {
            _snackbar.Clear();
            _snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            _snackbar.Add(message, IsSuccess ? MudBlazor.Severity.Success : MudBlazor.Severity.Error, options =>
            {
                options.ShowTransitionDuration = 500;
                options.HideTransitionDuration = 500;
                options.VisibleStateDuration = 1800;
            });
        }
    }
}
