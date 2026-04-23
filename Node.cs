namespace LinkedListApp;

// Клас, що описує один вузол (елемент) однозв'язного списку
public class Node
{
    // Значення, яке зберігається у вузлі (ціле число)
    public int Value { get; set; }

    // Посилання (вказівник) на наступний вузол у списку.
    // Якщо Next == null, то цей вузол є останнім (хвостом) списку.
    public Node? Next { get; set; }

    // Конструктор приймає значення і створює новий вузол.
    // Посилання Next за замовчуванням null (поки що вузол "самотній").
    public Node(int value)
    {
        this.Value = value;
        this.Next = null;
    }
}
