namespace ISP.PageModels
{
    public class CardPageModelBase : PageModelBase
    {
        public virtual Task CreateCardAsync()
        {
            return Task.CompletedTask;
        }
    }
}
