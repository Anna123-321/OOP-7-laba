namespace LinkedListApp;

public static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Демонстрація однозв'язного списку (Варіант 12) ===\n");

        // --- Створюємо список і наповнюємо початковими значеннями ---
        var list = new SinglyLinkedList();
        int[] initial = { 7, 4, 10, 8, 3, 6, 12, 3, 5 };
        foreach (var v in initial)
        {
            list.AddLast(v);
        }

        Console.WriteLine($"Початковий список:       {list}");
        Console.WriteLine($"Кількість елементів:      {list.Count}\n");

        // --- Операція за варіантом: вставка ПІСЛЯ першого елементу ---
        Console.WriteLine("Вставляємо значення 99 після першого елементу:");
        list.InsertAfterFirst(99);
        Console.WriteLine($"Після вставки:           {list}\n");

        // --- Завдання 1: перше входження заданого значення ---
        int searchValue = 3;
        int idx = list.IndexOf(searchValue);
        Console.WriteLine($"Завдання 1. Перше входження значення {searchValue}: " +
                          (idx >= 0 ? $"індекс {idx}" : "не знайдено"));

        // Перевіримо ще для значення, якого немає
        int missing = 777;
        int idx2 = list.IndexOf(missing);
        Console.WriteLine($"              Перше входження значення {missing}: " +
                          (idx2 >= 0 ? $"індекс {idx2}" : "не знайдено") + "\n");

        // --- Завдання 2: кількість парних чисел на парних позиціях ---
        int evenAtEven = list.CountEvenValuesAtEvenPositions();
        Console.WriteLine($"Завдання 2. Кратних 2 на парних позиціях: {evenAtEven}\n");

        // --- Завдання 3: новий список зі значень ДО мінімального ---
        var before = list.GetElementsBeforeMin();
        Console.WriteLine($"Завдання 3. Елементи до мінімуму:  {before}");
        Console.WriteLine($"             (у вихідному списку мінімум — найменше значення)\n");

        // --- Завдання 4: видалити все ПІСЛЯ мінімального ---
        Console.WriteLine("Завдання 4. Видаляємо елементи після першого мінімуму.");
        list.RemoveAfterMin();
        Console.WriteLine($"Список після видалення:  {list}");
        Console.WriteLine($"Кількість елементів:      {list.Count}\n");

        Console.WriteLine("=== Кінець демонстрації ===");
    }
}
