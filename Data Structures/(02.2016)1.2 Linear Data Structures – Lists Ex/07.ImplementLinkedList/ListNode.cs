namespace _07.ImplementLinkedList
{
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public ListNode<T> Next { get; set; }
    }
}
