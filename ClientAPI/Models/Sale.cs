using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClientAPI.Models;

public class Sale
{
    public Guid Id { get; set; }
    
    [JsonPropertyName("sellDateTime")]
    public DateTime SellDateTime { get; set; }
    
    [JsonPropertyName("product")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Product Product { get; set; }
    
    public Guid ProductId { get; set; }
    
    [JsonPropertyName("sellsCount")]
    public int SellsCount { get; set; }
    
    [JsonIgnore]
    public double Sum { get; set; }
}