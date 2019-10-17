namespace _06.GenericCountMethodDouble
{
    using System;
    public class Box<T> : IComparable<Box<T>> where T : IComparable<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public int CompareTo(Box<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public override string ToString()
        {
            return $"{Value.GetType()}: {this.Value}";
        }
    }

}
