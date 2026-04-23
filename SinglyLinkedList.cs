namespace LinkedListApp;

// Клас однозв'язного списку цілих чисел.
public class SinglyLinkedList
{
    // Посилання на перший вузол (голову) списку.
    // Якщо head == null, то список порожній.
    private Node? head;

    // Кількість елементів у списку (зручно мати окреме поле-лічильник).
    private int count;

    // Публічна властивість: кількість елементів.
    public int Count => this.count;

    // Публічна властивість: чи порожній список.
    public bool IsEmpty => this.head == null;

    // --- Додавання елементу в кінець списку ---
    // Використовується для початкового наповнення списку.
    public void AddLast(int value)
    {
        var newNode = new Node(value);

        // Якщо список порожній — новий вузол стає головою.
        if (this.head == null)
        {
            this.head = newNode;
        }
        else
        {
            // Інакше доходимо до останнього вузла і чіпляємо новий.
            var current = this.head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        this.count++;
    }

    // --- ГОЛОВНА ОПЕРАЦІЯ ЗА ВАРІАНТОМ: Вставка ПІСЛЯ першого елементу ---
    // Тобто новий вузол стає другим у списку.
    public void InsertAfterFirst(int value)
    {
        // Якщо списку немає — нема "першого елементу", кидаємо виняток.
        if (this.head == null)
        {
            throw new InvalidOperationException(
                "Неможливо вставити після першого елементу: список порожній.");
        }

        var newNode = new Node(value);

        // Зберігаємо посилання на те, що раніше було другим.
        newNode.Next = this.head.Next;

        // Тепер після голови йде наш новий вузол.
        this.head.Next = newNode;

        this.count++;
    }

    // --- ЗАВДАННЯ 1: Знайти перше входження заданого значення ---
    // Повертає індекс (0-based) елемента або -1, якщо не знайдено.
    public int IndexOf(int value)
    {
        var current = this.head;
        int index = 0;

        while (current != null)
        {
            if (current.Value == value)
            {
                return index; // Знайшли — повертаємо позицію.
            }

            current = current.Next;
            index++;
        }

        return -1; // Не знайшли.
    }

    // --- ЗАВДАННЯ 2: Кількість елементів, кратних 2,
    // що розташовані на ПАРНИХ позиціях ---
    // Увага: під "парними позиціями" зазвичай розуміють позиції 2, 4, 6...
    // при нумерації з 1 (тобто індекси 1, 3, 5... при 0-based).
    public int CountEvenValuesAtEvenPositions()
    {
        int counter = 0;
        var current = this.head;
        int position = 1; // нумеруємо з 1 (як у звичайному житті)

        while (current != null)
        {
            // Позиція парна (2, 4, 6...) і значення кратне 2
            if (position % 2 == 0 && current.Value % 2 == 0)
            {
                counter++;
            }

            current = current.Next;
            position++;
        }

        return counter;
    }

    // --- ЗАВДАННЯ 3: Новий список зі значень, що стоять ДО мінімального ---
    // Нумерація з голови: беремо всі вузли, що стоять перед першим мінімумом.
    public SinglyLinkedList GetElementsBeforeMin()
    {
        var result = new SinglyLinkedList();

        // Якщо список порожній — повертаємо порожній новий список.
        if (this.head == null)
        {
            return result;
        }

        // Крок 1: знайти мінімальне значення.
        int min = this.head.Value;
        var current = this.head.Next;
        while (current != null)
        {
            if (current.Value < min)
            {
                min = current.Value;
            }

            current = current.Next;
        }

        // Крок 2: пройти по списку ще раз і копіювати елементи до першого min.
        current = this.head;
        while (current != null && current.Value != min)
        {
            result.AddLast(current.Value);
            current = current.Next;
        }

        return result;
    }

    // --- ЗАВДАННЯ 4: Видалити всі елементи, що стоять ПІСЛЯ мінімального ---
    // Тобто після першого входження мінімуму обриваємо список.
    public void RemoveAfterMin()
    {
        if (this.head == null)
        {
            return; // Нема чого видаляти.
        }

        // Шукаємо мінімум.
        int min = this.head.Value;
        var current = this.head.Next;
        while (current != null)
        {
            if (current.Value < min)
            {
                min = current.Value;
            }

            current = current.Next;
        }

        // Знаходимо перший вузол зі значенням min і "обрізаємо" хвіст.
        current = this.head;
        int newCount = 0;
        while (current != null)
        {
            newCount++;
            if (current.Value == min)
            {
                current.Next = null; // обриваємо звʼязок із рештою
                break;
            }

            current = current.Next;
        }

        this.count = newCount;
    }

    // --- Допоміжний метод: перетворити список на текст для виведення ---
    public override string ToString()
    {
        if (this.head == null)
        {
            return "[ порожній ]";
        }

        var parts = new List<string>();
        var current = this.head;
        while (current != null)
        {
            parts.Add(current.Value.ToString());
            current = current.Next;
        }

        return "[ " + string.Join(" -> ", parts) + " ]";
    }
}
