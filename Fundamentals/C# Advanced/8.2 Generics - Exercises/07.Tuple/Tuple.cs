namespace _07.Tuple
{
    public class Tuple<T, V>
    {
        public Tuple(T item1, V item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        private T item1;

        private V item2;

        public T Item1
        {
            get
            {
                return this.item1;
            }
            private set
            {
                this.item1 = value;
            }
        }

        public V Item2
        {
            get
            {
                return this.item2;
            }
            private set
            {
                this.item2 = value;
            }
        }

        public override string ToString()
        {
            return $"{item1} -> {item2}";
        }
    }
}
