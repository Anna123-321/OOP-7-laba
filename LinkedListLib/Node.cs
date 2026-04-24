namespace LinkedListLib;

public class Node
{
    public Node(int value)
    {
        this.Value = value;
        this.Next = null;
    }

    public int Value { get; set; }
    public Node? Next { get; set; }
}
