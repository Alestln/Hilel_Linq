using Hilel_Linq.Entities;

namespace Hilel_Linq;

public static class LinqTasks
{
    /// <summary>
    /// Написати програму на C#, яка отримує набір рядків зі словами та фільтрує лише ті,
    /// які починаються з літери "A". Вивести результат на екран.
    /// </summary>
    public static void GetLinesStartsWith(IEnumerable<string> lines)
    {
        var result = lines
            .Where(l => l.Trim().StartsWith("А", StringComparison.OrdinalIgnoreCase));
        // How to consider encoding 
        // var result = lines.Where(l => l.StartsWith("А", StringComparison.OrdinalIgnoreCase) || l.StartsWith("A", StringComparison.OrdinalIgnoreCase));

        Console.WriteLine("Строки, которые начинаются на А:");
        foreach (var s in result)
        {
            Console.WriteLine(s);
        }
    }

    /// <summary>
    /// Створити два масиви цілих чисел різної довжини.
    /// Використовуючи LINQ, знайти всі значення, які містяться в обох масивах та відобразити їх на екран.
    /// </summary>
    /// <param name="firstArray">Первый массив</param>
    /// <param name="secondArray">Второй массив</param>
    public static void GetGeneralValues(int[] firstArray, int[] secondArray)
    {
        var result = firstArray.Intersect(secondArray);

        Console.WriteLine("\nОбщие элементы двух массивов:");
        foreach (var i in result)
        {
            Console.Write($"{i} ");
        }
    }

    /// <summary>
    /// Написати програму, яка створює колекцію об'єктів класу Student, в яких є поля "Ім'я", "Прізвище" та "Оцінка".
    /// Використовуючи LINQ, знайти студента з максимальною оцінкою та вивести його на екран.
    /// </summary>
    /// <param name="students">Список студентов</param>
    public static void GetStudentsWithMaxMark(IEnumerable<Student> students)
    {
        // List of students with max mark.
        var maxMark = students.Max(s => s.Mark);

        Console.WriteLine("\n\nСтуденты с масимальной оценкой:");
        foreach (var student in students.Where(s => s.Mark == maxMark))
        {
            Console.WriteLine(student);
        }
    }

    /// <summary>
    /// Створити колекцію об'єктів класу Product, в яких є поля "Назва", "Ціна" та "Категорія".
    /// Використовуючи LINQ, згрупувати продукти за категорією та обчислити середню ціну кожної категорії.
    /// </summary>
    /// <param name="products">Список продуктов</param>
    public static void GetAveragePriceOfCategory(IEnumerable<Product> products)
    {
        var result = products
            .GroupBy(p => p.Category)
            .Select(p => new {Category = p.Key, AveragePrice = p.Sum(x => x.Price) / p.Count()});

        Console.WriteLine("\n\nСредняя цена категорий продуктов:");
        foreach (var res in result)
        {
            Console.WriteLine($"{res.Category}: {res.AveragePrice}");
        }
    }

    public static void GetOldEmployees(IEnumerable<Employee> employees)
    {
        var result = employees
            .Where(e => Convert.ToInt32((DateTime.Now - e.EmploymentDate).TotalDays / 365.25) > 5);

        Console.WriteLine("\nСотрудники, работающие больше 5 лет:");
        foreach (var employee in result)
        {
            Console.WriteLine($"{employee}\n");
        }
    }

    public static void GetNewFantasticBooks(IEnumerable<Book> books)
    {
        var result = books
            .Where(b => b.Genre == "Fantastic" && b.Year > 2010);

        Console.WriteLine("Книги жанра фантастика и год издания которых больше 2010:");
        foreach (var book in result)
        {
            Console.WriteLine($"{book}\n");
        }
    }

    /// <summary>
    /// Створити колекцію об'єктів класу Customer, в яких є поля "Ім'я", "Прізвище", "Адреса" та "Замовлення".
    /// Використовуючи LINQ, знайти клієнтів, які зробили замовлення
    /// на суму більше 1000 грн та вивести їх замовлення у вигляді переліку.
    /// </summary>
    /// <param name="customers">Список клиентов</param>
    public static void GetCustomersWithExpensiveOrder(IEnumerable<Customer> customers)
    {
        var result = customers
            .Where(c => c.Order.Sum(o => o.Price) > 1000);

        Console.WriteLine("Клиенты, которые сделали заказ на больше чем 1000 грн:\n");
        foreach (var customer in result)
        {
            Console.WriteLine(customer);
        }
    }
}