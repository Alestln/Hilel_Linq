using System.Text.Json.Serialization;

namespace Hilel_Linq.Entities;

public class Book
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("author")]
    public string Author { get; set; }
    
    [JsonPropertyName("year")]
    public int Year { get; set; }
    
    [JsonPropertyName("genre")]
    public string Genre { get; set; }
    

    public override string ToString()
    {
        return $"Название: {Title}\nАвтор: {Author}\nГод издания: {Year}\nЖанр: {Genre}";
    }
}