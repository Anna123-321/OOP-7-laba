using System.Collections;

namespace LinkedListLib;

/// <summary>
/// Однозв'язний список цілих чисел (варіант 12).
/// Підтримує вставку після першого елемента, індексацію на читання,
/// видалення за номером, перебір <c>foreach</c> та операції варіанта.
/// </summary>
public class SinglyLinkedList : IEnumerable<int>
{
    /// <summary>
    /// Посилання на перший вузол списку (голову). Якщо <c>null</c> — список порожній.
    /// </summary>
    private Node? head;

    /// <summary>
    /// Поточна кількість елементів у списку.
    /// </summary>
    private int count;

    /// <summary>
    /// Кількість елементів у списку.
    /// </summary>
    public int Count => this.count;

    /// <summary>
    /// Показує, чи список порожній.
    /// </summary>
    public bool IsEmpty => this.head == null;

    /// <summary>
    /// Індексатор для доступу на читання за номером елемента.
    /// Нумерація починається з <c>0</c>.
    /// </summary>
    /// <param name="index">Номер елемента (0-based).</param>
    /// <returns>Значення елемента, що стоїть на позиції <paramref name="index"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Виникає, якщо <paramref name="index"/> від'ємний або виходить за межі списку.
    /// </exception>
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index), "Індекс виходить за межі списку.");
            }

            var current = this.head;
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }

            return current!.Value;
        }
    }

    /// <summary>
    /// Додає значення в кінець списку.
    /// Допоміжна операція для початкового наповнення.
    /// </summary>
    /// <param name="value">Значення, яке треба додати.</param>
    public void AddLast(int value)
    {
        var newNode = new Node(value);

        if (this.head == null)
        {
            this.head = newNode;
        }
        else
        {
            var current = this.head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        this.count++;
    }

    /// <summary>
    /// Вставляє нове значення одразу після першого (головного) елемента списку.
    /// Операція включення згідно з варіантом 12.
    /// </summary>
    /// <param name="value">Значення, яке треба вставити.</param>
    /// <exception cref="InvalidOperationException">
    /// Виникає, якщо список порожній (немає першого елемента).
    /// </exception>
    public void InsertAfterFirst(int value)
    {
        if (this.head == null)
        {
            throw new InvalidOperationException(
                "Неможливо вставити після першого елемента: список порожній.");
        }

        var newNode = new Node(value)
        {
            Next = this.head.Next,
        };
        this.head.Next = newNode;

        this.count++;
    }

    /// <summary>
    /// Видаляє елемент за його номером у списку. Нумерація починається з <c>0</c>.
    /// </summary>
    /// <param name="index">Номер елемента, який треба видалити.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Виникає, якщо <paramref name="index"/> від'ємний або виходить за межі списку.
    /// </exception>
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.count)
        {
            throw new ArgumentOutOfRangeException(
                nameof(index), "Індекс виходить за межі списку.");
        }

        if (index == 0)
        {
            this.head = this.head!.Next;
        }
        else
        {
            var previous = this.head!;
            for (int i = 0; i < index - 1; i++)
            {
                previous = previous.Next!;
            }

            previous.Next = previous.Next!.Next;
        }

        this.count--;
    }

    /// <summary>
    /// Знаходить номер першого входження заданого значення у списку (завдання 1).
    /// </summary>
    /// <param name="value">Значення, яке шукаємо.</param>
    /// <returns>
    /// Номер (0-based) першого входження, або <c>-1</c>, якщо значення не знайдено.
    /// </returns>
    public int IndexOf(int value)
    {
        var current = this.head;
        int index = 0;

        while (current != null)
        {
            if (current.Value == value)
            {
                return index;
            }

            current = current.Next;
            index++;
        }

        return -1;
    }

    /// <summary>
    /// Повертає кількість елементів, значення яких кратні заданому дільнику
    /// і які розташовані на парних позиціях списку (завдання 2).
    /// Позиції нумеруються з <c>1</c>, тому парними є 2, 4, 6 і т.д.
    /// </summary>
    /// <param name="divisor">Дільник, кратність якому перевіряється (у варіанті — 2).</param>
    /// <returns>Кількість елементів, що відповідають умові.</returns>
    /// <exception cref="ArgumentException">Виникає, якщо <paramref name="divisor"/> дорівнює 0.</exception>
    public int CountMultiplesAtEvenPositions(int divisor)
    {
        if (divisor == 0)
        {
            throw new ArgumentException("Дільник не може дорівнювати нулю.", nameof(divisor));
        }

        int counter = 0;
        var current = this.head;
        int position = 1;

        while (current != null)
        {
            if (position % 2 == 0 && current.Value % divisor == 0)
            {
                counter++;
            }

            current = current.Next;
            position++;
        }

        return counter;
    }

    /// <summary>
    /// Повертає новий список, що містить значення елементів, розташованих
    /// до першого входження мінімального елемента (завдання 3).
    /// Нумерація ведеться з голови списку.
    /// </summary>
    /// <returns>Новий список зі значеннями, що стоять до мінімуму (не включно).</returns>
    public SinglyLinkedList GetElementsBeforeMin()
    {
        var result = new SinglyLinkedList();

        if (this.head == null)
        {
            return result;
        }

        int min = this.FindMin();

        var current = this.head;
        while (current != null && current.Value != min)
        {
            result.AddLast(current.Value);
            current = current.Next;
        }

        return result;
    }

    /// <summary>
    /// Видаляє зі списку всі елементи, що розташовані після першого входження
    /// мінімального елемента (завдання 4).
    /// Сам мінімальний елемент залишається в списку як останній.
    /// </summary>
    public void RemoveAfterMin()
    {
        if (this.head == null)
        {
            return;
        }

        int min = this.FindMin();

        var current = this.head;
        int newCount = 0;
        while (current != null)
        {
            newCount++;
            if (current.Value == min)
            {
                current.Next = null;
                break;
            }

            current = current.Next;
        }

        this.count = newCount;
    }

    /// <summary>
    /// Повертає перелічувач, що дозволяє перебирати значення списку
    /// за допомогою оператора <c>foreach</c>.
    /// </summary>
    /// <returns>Перелічувач цілих значень списку в порядку від голови до хвоста.</returns>
    public IEnumerator<int> GetEnumerator()
    {
        var current = this.head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    /// <summary>
    /// Нетипова реалізація <see cref="IEnumerable.GetEnumerator"/>,
    /// потрібна для сумісності зі старим, нетиповим інтерфейсом <see cref="IEnumerable"/>.
    /// </summary>
    /// <returns>Той самий перелічувач, що й у типовій версії.</returns>
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    /// <summary>
    /// Допоміжний метод: знаходить мінімальне значення у непорожньому списку.
    /// </summary>
    /// <returns>Мінімальне значення серед елементів списку.</returns>
    private int FindMin()
    {
        int min = this.head!.Value;
        var current = this.head.Next;
        while (current != null)
        {
            if (current.Value < min)
            {
                min = current.Value;
            }

            current = current.Next;
        }

        return min;
    }
}
