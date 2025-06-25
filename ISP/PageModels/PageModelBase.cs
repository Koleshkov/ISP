using ISP.Models;
using ISP.Services.PassengerCardServices;

namespace ISP.PageModels
{
    public class PageModelBase
    {
        public bool IsVisibleSpinner { get; set; }
        public bool IsVisibleMessageBox { get; set; }

        public void CloseMessageBox() => IsVisibleMessageBox = false;

    }
}
