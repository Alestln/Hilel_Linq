using System.Text.Json;
using Hilel_Linq.Entities;

namespace Hilel_Linq;

class Program
{
    static void Main(string[] args)
    {
        // Task 1
        // Автор текста ChatGPT :)
        LinqTasks.GetLinesStartsWith(new[]
        {
            "Алексей шел по улице, задумчиво нахмурив брови.",
            "Безмятежный вечер прогуливался вдоль аллей парка",
            "Анна любила читать книги, сидя на античной лавочке.",
            "Вдоль асфальтовой дорожки пробегали автомобили.",
            "Астрономы изучали астероиды в бескрайнем космосе.",
            "Белые анютины глазки расцвели весной под окном."
        });

        // Task 2
        int[] firstArray = new int[Random.Shared.Next(10) + 1];
        int[] secondArray = new int[Random.Shared.Next(10) + 1];

        GenerateNumberArray(firstArray);
        GenerateNumberArray(secondArray);
        
        LinqTasks.GetGeneralValues(firstArray, secondArray);
        
        // Data in tasks 3-7 was generated on https://www.mockaroo.com/
        // Task 3
        IEnumerable<Student> students = GetDataFromJson<Student>("students.json");
        LinqTasks.GetStudentsWithMaxMark(students);
        
        // Task 4
        IEnumerable<Product> products = GetDataFromJson<Product>("products.json");
        LinqTasks.GetAveragePriceOfCategory(products);
        
        // Task 5
        IEnumerable<Employee> employees = GetDataFromJson<Employee>("employees.json");
        LinqTasks.GetOldEmployees(employees);
        
        // Task 6
        IEnumerable<Book> books = GetDataFromJson<Book>("books.json");
        LinqTasks.GetNewFantasticBooks(books);
        
        // Task 6
        IEnumerable<Customer> customers = GetDataFromJson<Customer>("customers.json");
        LinqTasks.GetCustomersWithExpensiveOrder(customers);
    }

    private static void GenerateNumberArray(int[] array)
    {
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = Random.Shared.Next(50);
        }
    }

    private static IEnumerable<T> GetDataFromJson<T>(string filename) where T : class
    {
        var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Jsons", filename);

        if (File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);

            IEnumerable<T> data = JsonSerializer.Deserialize<IEnumerable<T>>(json) ?? throw new NullReferenceException($"{filename} is null.");

            return data;
        }

        throw new FileNotFoundException($"{jsonPath} not found.");
    }
}