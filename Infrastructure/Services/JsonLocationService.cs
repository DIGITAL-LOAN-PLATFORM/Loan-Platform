using System.Text.Json;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

public class JsonLocationService(
    IFileProvider webRootFileProvider,
    ILogger<JsonLocationService> logger) : ILocationService
{
    private const string LocationFilePath = "data/rwanda_locations.json";
    private List<Province>? _cachedLocations;
    private readonly SemaphoreSlim _cacheLock = new(1, 1);

    public async Task<List<Province>> GetAllLocationsAsync()
    {
        if (_cachedLocations is not null)
        {
            return _cachedLocations;
        }

        await _cacheLock.WaitAsync();
        try
        {
            if (_cachedLocations is not null)
            {
                return _cachedLocations;
            }

            var fileInfo = webRootFileProvider.GetFileInfo(LocationFilePath);
            if (!fileInfo.Exists)
            {
                logger.LogWarning("Location JSON file not found at {FilePath}.", LocationFilePath);
                _cachedLocations = [];
                return _cachedLocations;
            }

            await using var stream = fileInfo.CreateReadStream();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var locations = await JsonSerializer.DeserializeAsync<List<Province>>(stream, options);
            _cachedLocations = locations ?? [];
            return _cachedLocations;
        }
        catch (JsonException ex)
        {
            logger.LogError(ex, "Invalid JSON format in {FilePath}.", LocationFilePath);
            _cachedLocations = [];
            return _cachedLocations;
        }
        finally
        {
            _cacheLock.Release();
        }
    }
}
