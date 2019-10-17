namespace _08.Threeuple
{
    public class Tuple<T, V, W>
    {
        public Tuple(T item1, V item2, W item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        private T item1;

        private V item2;

        private W item3;

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

        public W Item3
        {
            get
            {
                return this.item3;
            }
            private set
            {
                this.item3 = value;
            }
        }
        public override string ToString()
        {
            return $"{item1} -> {item2} -> {item3}";
        }
    }
}
