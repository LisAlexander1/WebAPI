using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using ClientAPI.Models;
using Newtonsoft.Json;

namespace ClientAPI.Services;

public class ApiClient
{
    public ApiClient(HttpClient httpClient, Token token)
    {
        HttpClient = httpClient;
        Token = token;
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.AccessToken);
    }

    private HttpClient HttpClient { get; }
    
    private Token Token { get; }

    public async Task<bool> AuthAsync(User user)
    {
        var response = await HttpClient.PostAsJsonAsync("auth", user);
        if (!response.IsSuccessStatusCode) return false;
        var token = await response.Content.ReadFromJsonAsync<Token>();
        if (token!.AccessToken is null) return false;
        Token.AccessToken = token.AccessToken;
        return true;
    }

    public async Task<List<Product>?> GetProductsAsync()
    {
        await Task.Delay(1000);
        return await HttpClient.GetFromJsonAsync<List<Product>>("products");
    }
    
    public async Task<Product?> GetProductByIdAsync(Guid id)
    {
        return await HttpClient.GetFromJsonAsync<Product>($"products/{id}");
    }
    
    public async Task<Product?> CreateProductAsync(Product product)
    {
        var response = await HttpClient.PostAsJsonAsync($"products", product);
        return await response.Content.ReadFromJsonAsync<Product>();
    }
    
    public async Task<Product?> UpdateProductAsync(Product product)
    {
        var response = await HttpClient.PutAsJsonAsync($"products", product);
        return await response.Content.ReadFromJsonAsync<Product>();
    }
    
    
    
    public async Task<List<Sale>?> GetSalesAsync()
    {
        await Task.Delay(1000);
        var response =  await HttpClient.GetAsync("sales");
        var content = await response.Content.ReadAsStringAsync();
        var sales = JsonConvert.DeserializeObject<List<Sale>>(content);
        return sales;
   
    }
    
    public async Task<Sale?> GetSaleByIdAsync(Guid id)
    {
        return await HttpClient.GetFromJsonAsync<Sale>($"sales/{id}");
    }
    
    public async Task<Sale?> CreateSaleAsync(Sale sale)
    {
        var response = await HttpClient.PostAsJsonAsync($"sales", sale);
        var content = await response.Content.ReadAsStringAsync();
        return await response.Content.ReadFromJsonAsync<Sale>();
    }
    
    public async Task<Sale?> UpdateSaleAsync(Sale sale)
    {
        var response = await HttpClient.PutAsJsonAsync($"sales", sale);
        return await response.Content.ReadFromJsonAsync<Sale>();
    }
    


}