using ISP.Models;
using ISP.Services.PassengerCardServices;

namespace ISP.PageModels
{
    public class PassengerCardPageModel : CardPageModelBase
    {
        private readonly IConfiguration? configuration;
        private readonly IPassengerCardService passengerCardService;

        public PassengerCard PassengerCard { get; set; } = new();
        public List<string> Departments { get; set; }
        public List<string> TarnsportOraganizations { get; set; }

        public PassengerCardPageModel(IPassengerCardService passengerCardService,
            IConfiguration configuration)
        {
            this.passengerCardService = passengerCardService;

            Departments = configuration.GetSection("Options:Departments").Get<List<string>>() ?? new List<string> { "Пусто" };
            TarnsportOraganizations = configuration.GetSection("Options:TransportOrganizations").Get<List<string>>() ?? new List<string> { "Пусто" };
        }

        public override async Task CreateCardAsync()
        {
            IsVisibleSpinner = true;
            await passengerCardService.CreatePassengerCardAsync(PassengerCard);
            IsVisibleSpinner = false;

        }
    }
}
