namespace LinkedListShared
{
    public class MyLinkedListNode<T>
    {
        public MyLinkedListNode()
        {

        }
        public MyLinkedListNode(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
        public MyLinkedListNode<T> Next { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
