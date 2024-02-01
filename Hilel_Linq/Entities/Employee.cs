using System;
using System.Text.Json.Serialization;

namespace Hilel_Linq.Entities;

public class Employee
{
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
    
    [JsonPropertyName("birthdayDate")]
    public DateTime BirthdayDate { get; set; }
    
    [JsonPropertyName("employmentDate")]
    public DateTime EmploymentDate { get; set; }
    

    public override string ToString()
    {
        return
            $"Имя: {FirstName}\nФамилия: {LastName}\nДата рождения: {BirthdayDate.ToString("d")}\nДата трудоустройства: {EmploymentDate.ToString("d")}";
    }
}