﻿namespace _02.GenericBoxofInteger
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public override string ToString()
        {
            return $"{Value.GetType()}: {this.Value}";
        }
    }
}
