using System.Text.Json.Serialization;

namespace Hilel_Linq.Entities;

public class Student
{
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
    
    [JsonPropertyName("mark")]
    public int Mark { get; set; }
    
    
    public override string ToString()
    {
        return $"\nИмя: {FirstName}\nФамилия: {LastName}\nОценка: {Mark}";
    }
}