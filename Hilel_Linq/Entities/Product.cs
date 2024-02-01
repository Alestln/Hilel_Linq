using System.Text.Json.Serialization;

namespace Hilel_Linq.Entities;

public class Product
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    
    [JsonPropertyName("category")]
    public string Category { get; set; }
}