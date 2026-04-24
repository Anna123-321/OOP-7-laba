namespace LinkedListLib;

/// <summary>
/// Вузол (елемент) однозв'язного списку цілих чисел.
/// Зберігає значення та посилання на наступний вузол.
/// </summary>
public class Node
{
    /// <summary>
    /// Ініціалізує новий вузол із заданим значенням.
    /// Посилання на наступний вузол встановлюється у <c>null</c>.
    /// </summary>
    /// <param name="value">Ціле значення, яке зберігається у вузлі.</param>
    public Node(int value)
    {
        this.Value = value;
        this.Next = null;
    }

    /// <summary>
    /// Ціле значення, що зберігається у вузлі.
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// Посилання на наступний вузол у списку, або <c>null</c>, якщо цей вузол — останній.
    /// </summary>
    public Node? Next { get; set; }
}
