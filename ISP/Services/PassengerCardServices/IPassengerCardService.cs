using ISP.Models;

namespace ISP.Services.PassengerCardServices
{
    public interface IPassengerCardService
    {
        Task<bool> CreatePassengerCardAsync(PassengerCard passengerCard);
    }
}
