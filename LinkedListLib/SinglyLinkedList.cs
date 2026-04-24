using System.Collections;

namespace LinkedListLib;

public class SinglyLinkedList : IEnumerable<int>
{
    private Node? head;
    private int count;
    public int Count => this.count;
    public bool IsEmpty => this.head == null;
 
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

    public IEnumerator<int> GetEnumerator()
    {
        var current = this.head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

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
