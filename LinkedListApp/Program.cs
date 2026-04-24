using LinkedListLib;

namespace LinkedListApp;

/// <summary>
/// Демонстраційна програма: використовує однозв'язний список з бібліотеки
/// <see cref="LinkedListLib"/> та показує роботу всіх його операцій.
/// </summary>
public static class Program
{
    /// <summary>
    /// Точка входу застосунку.
    /// </summary>
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Демонстрація однозв'язного списку (варіант 12) ===\n");

        DemonstrateFirstList();
        Console.WriteLine();
        DemonstrateSecondList();

        Console.WriteLine("\n=== Кінець демонстрації ===");
    }

    /// <summary>
    /// Демонструє повний набір операцій на першому списку:
    /// наповнення, індексацію, foreach, вставку після першого,
    /// пошук, підрахунок кратних на парних позиціях, видалення за індексом,
    /// отримання списку до мінімуму та видалення після мінімуму.
    /// </summary>
    private static void DemonstrateFirstList()
    {
        Console.WriteLine("--- Список №1 ---");

        var list = new SinglyLinkedList();
        int[] values = { 7, 4, 10, 8, 3, 6, 12, 3, 5 };
        foreach (int v in values)
        {
            list.AddLast(v);
        }

        Print("Початковий список", list);
        Console.WriteLine($"Кількість елементів: {list.Count}");

        Console.WriteLine("\n[Індексація] list[0] = " + list[0] +
                          ", list[4] = " + list[4] +
                          ", list[list.Count - 1] = " + list[list.Count - 1]);

        Console.Write("[foreach] значення: ");
        foreach (int item in list)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();

        Console.WriteLine("\n[Вставка після першого] додаємо значення 99");
        list.InsertAfterFirst(99);
        Print("Після вставки", list);

        int searchA = 3;
        int searchB = 777;
        Console.WriteLine($"\n[Завдання 1] IndexOf({searchA}) = {list.IndexOf(searchA)}");
        Console.WriteLine($"[Завдання 1] IndexOf({searchB}) = {list.IndexOf(searchB)}");

        int divisor = 2;
        int evenAtEven = list.CountMultiplesAtEvenPositions(divisor);
        Console.WriteLine($"\n[Завдання 2] Кратних {divisor} на парних позиціях: {evenAtEven}");

        int divisor2 = 3;
        int triples = list.CountMultiplesAtEvenPositions(divisor2);
        Console.WriteLine($"[Завдання 2] Кратних {divisor2} на парних позиціях: {triples}");

        var beforeMin = list.GetElementsBeforeMin();
        Print("\n[Завдання 3] Елементи до мінімуму", beforeMin);

        int removeIndex = 2;
        Console.WriteLine($"\n[RemoveAt] видаляємо елемент під номером {removeIndex}");
        list.RemoveAt(removeIndex);
        Print("Після видалення", list);

        Console.WriteLine("\n[Завдання 4] Видаляємо всі елементи після мінімального");
        list.RemoveAfterMin();
        Print("Після видалення хвоста", list);
        Console.WriteLine($"Кількість елементів: {list.Count}");
    }

    /// <summary>
    /// Демонструє другий незалежний список з іншими значеннями.
    /// Показує, що клас коректно працює з кількома об'єктами одночасно.
    /// </summary>
    private static void DemonstrateSecondList()
    {
        Console.WriteLine("--- Список №2 ---");

        var list = new SinglyLinkedList();
        int[] values = { 15, 2, 20, 8, 14, 1, 6 };
        foreach (int v in values)
        {
            list.AddLast(v);
        }

        Print("Початковий список", list);

        int searchValue = 14;
        Console.WriteLine($"IndexOf({searchValue}) = {list.IndexOf(searchValue)}");

        int divisor = 2;
        Console.WriteLine(
            $"Кратних {divisor} на парних позиціях: " +
            list.CountMultiplesAtEvenPositions(divisor));

        var before = list.GetElementsBeforeMin();
        Print("Елементи до мінімуму", before);

        list.RemoveAfterMin();
        Print("Після видалення хвоста", list);
    }

    /// <summary>
    /// Допоміжний метод для виведення списку на консоль у форматі [ a -&gt; b -&gt; c ].
    /// Це — використання списку (проходимо <c>foreach</c>), а не його функціонал.
    /// </summary>
    /// <param name="title">Підпис перед списком.</param>
    /// <param name="list">Список, який треба вивести.</param>
    private static void Print(string title, SinglyLinkedList list)
    {
        if (list.IsEmpty)
        {
            Console.WriteLine($"{title}: [ порожній ]");
            return;
        }

        var parts = new List<string>();
        foreach (int v in list)
        {
            parts.Add(v.ToString());
        }

        Console.WriteLine($"{title}: [ {string.Join(" -> ", parts)} ]");
    }
}
