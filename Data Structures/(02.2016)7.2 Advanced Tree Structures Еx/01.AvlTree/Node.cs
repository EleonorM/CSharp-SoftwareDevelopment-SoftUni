namespace _01.AvlTree
{
    using System;

    public class Node<T>
        where T : IComparable<T>
    {
        private Node<T> leftChild;
        private Node<T> rightChild;

        public T Value { get; set; }

        public Node<T> LeftChild
        {
            get => leftChild;
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.leftChild = value;
            }
        }

        public Node<T> RightChild
        {
            get => rightChild; 
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.rightChild = value;
            }
        }

        public Node<T> Parent { get; set; }

        public int BalanceFactor { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public bool IsLeftChild()
        {
            if (this.Parent == null)
            {
                return false;
            }

            return Parent.LeftChild == this;
        }

        public bool IsRightChild()
        {
            if (this.Parent == null)
            {
                return false;
            }

            return Parent.RightChild == this;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

