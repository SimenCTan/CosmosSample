using CosmosSample.Domain.Entities;
using CosmosSample.Domain.Models;
using Newtonsoft.Json;

namespace CosmosSample.MauiCRM.Services;

public class SalesService
{
    private readonly HttpClient _httpClient;
    public SalesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<MemberEntity>> GetSalesMembersAsync()
    {
        var members = new List<MemberEntity>();
        try
        {
            var response = await _httpClient.GetAsync("Users/All");
            response.EnsureSuccessStatusCode();
            var responseStr = await response.Content.ReadAsStringAsync();
            members = JsonConvert.DeserializeObject<ResponseResult<List<MemberEntity>>>(responseStr).Data;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.Message);
        }
        await Task.CompletedTask;
        return members;
    }
}

