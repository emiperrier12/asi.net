namespace TP1_Voiture.Web.Components.Features.Voitures;

public class VoitureApiClient(HttpClient httpClient)
{
    public async Task<VoitureDto[]> GetVoituresAsync()
    {
        return await httpClient.GetFromJsonAsync<VoitureDto[]>("/voitures") 
               ?? [];
    }
    
    public async Task<VoitureDto?> GetVoitureByImmatriculationAsync(string immatriculation)
    {
        return await httpClient.GetFromJsonAsync<VoitureDto>($"/voitures/immat/{immatriculation}");
    }
    
    public async Task<LocationDto[]> GetLocationsByImmatriculationAsync(string immatriculation)
    {
        return await httpClient.GetFromJsonAsync<LocationDto[]>($"/locations/{immatriculation}") 
               ?? [];
    }
    
    public async Task<bool> CreateLocationAsync(CreateLocationDto location)
    {
        var response = await httpClient.PostAsJsonAsync("/locations", location);
        return response.IsSuccessStatusCode;
    }
}