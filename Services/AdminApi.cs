
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using SmartParkingAdmin.Models;

namespace SmartParkingAdmin.Services;

public sealed class AdminApi : IAdminApi
{
    private readonly IHttpClientFactory _factory;
    private readonly IConfiguration _config;

    public AdminApi(
        IHttpClientFactory factory,
        IConfiguration config)
    {
        _factory = factory;
        _config = config;
    }

    private HttpClient CreateClient(string key)
    {
        var url = _config[$"ApiBaseUrls:{key}"]
            ?? throw new InvalidOperationException(
                $"Missing ApiBaseUrls:{key}");

        var client = _factory.CreateClient();
        client.BaseAddress = new Uri(url);

        return client;
    }

    // User management

    public async Task<List<UserAccount>> GetUsersAsync()
    {
        return await CreateClient("Users")
            .GetFromJsonAsync<List<UserAccount>>("api/users")
            ?? [];
    }

    public async Task SetUserActiveAsync(Guid id, bool active)
    {
        var response = await CreateClient("Users")
            .PatchAsJsonAsync(
                $"api/users/{id}/status",
                new { isActive = active });

        response.EnsureSuccessStatusCode();
    }

    // Parking price management

    public async Task<List<ParkingPrice>> GetPricesAsync()
    {
        return await CreateClient("Prices")
            .GetFromJsonAsync<List<ParkingPrice>>("api/prices")
            ?? [];
    }

    public async Task SavePriceAsync(ParkingPrice price)
    {
        var client = CreateClient("Prices");

        var response = price.Id == Guid.Empty
            ? await client.PostAsJsonAsync("api/prices", price)
            : await client.PutAsJsonAsync(
                $"api/prices/{price.Id}", price);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeletePriceAsync(Guid id)
    {
        var response = await CreateClient("Prices")
            .DeleteAsync($"api/prices/{id}");

        response.EnsureSuccessStatusCode();
    }

    // Parking spot management

    public async Task<List<ParkingSpot>> GetSpotsAsync()
    {
        return await CreateClient("Parking")
            .GetFromJsonAsync<List<ParkingSpot>>(
                "api/parking-spots")
            ?? [];
    }

    public async Task SaveSpotAsync(ParkingSpot spot)
    {
        var client = CreateClient("Parking");

        var response = spot.Id == Guid.Empty
            ? await client.PostAsJsonAsync(
                "api/parking-spots", spot)
            : await client.PutAsJsonAsync(
                $"api/parking-spots/{spot.Id}", spot);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteSpotAsync(Guid id)
    {
        var response = await CreateClient("Parking")
            .DeleteAsync($"api/parking-spots/{id}");

        response.EnsureSuccessStatusCode();
    }
}
