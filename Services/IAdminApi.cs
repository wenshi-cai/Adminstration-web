using SmartParkingAdmin.Models;
namespace SmartParkingAdmin.Services;
public interface IAdminApi {
Task<List<UserAccount>> GetUsersAsync(); Task SetUserActiveAsync(Guid id,bool active);
Task<List<ParkingPrice>> GetPricesAsync(); Task SavePriceAsync(ParkingPrice p); Task DeletePriceAsync(Guid id);
Task<List<ParkingSpot>> GetSpotsAsync(); Task SaveSpotAsync(ParkingSpot s); Task DeleteSpotAsync(Guid id);
}
