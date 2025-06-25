using ISP.Models;
using Microsoft.JSInterop;
using System;

namespace ISP.PageModels
{
    public class SendingListPageModel : PageModelBase
    {

        private readonly IJSRuntime JS;
        public SendingListPageModel(IJSRuntime jS)
        {
            JS = jS;
        }

        public async Task SendEmail()
        {
            await JS.InvokeVoidAsync(
            "sendEmail", "Koleshkov@mail.com", "Test Header", "Test body");
        }
    }
}
