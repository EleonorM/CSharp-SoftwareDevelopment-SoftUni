namespace _05._BalancedOrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BalancedOrderedSet<T> : IEnumerable<T>
       where T : IComparable<T>
    {
        public Node<T> Root { get; set; }

        public int Count { get; set; }

        public BalancedOrderedSet()
        {
            Count = 0;
            Root = null;
        }

        public void Add(T element)
        {
            var newNode = new Node<T>(element);
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                var currentNode = Root;
                while (currentNode != null)
                {
                    if (element.CompareTo(currentNode.Value) > 0)
                    {
                        if (currentNode.Right == null)
                        {
                            currentNode.Right = newNode;
                            newNode.Parent = currentNode;
                            CheckBalance(newNode);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.Right;
                        }
                    }
                    else if (element.CompareTo(currentNode.Value) <= 0)
                    {
                        if (currentNode.Left == null)
                        {
                            currentNode.Left = newNode;
                            newNode.Parent = currentNode;
                            CheckBalance(newNode);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.Left;
                        }
                    }
                }


            }

            Count++;

        }

        private void CheckBalance(Node<T> node)
        {
            if (Math.Abs(Height(node.Left) - Height(node.Right)) > 1)
            {
                Rebalance(node);
            }

            if (node.Parent == null)
            {
                return;
            }

            CheckBalance(node.Parent);
        }

        public bool Contains(T element)
        {
            var currentNode = Root;
            while (currentNode != null)
            {
                if (element.CompareTo(currentNode.Value) > 0)
                {
                    currentNode = currentNode.Right;
                }
                else if (element.CompareTo(currentNode.Value) < 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var list = new List<Node<T>>();
            DFS(Root, list);
            foreach (var node in list)
            {
                yield return node.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int Height(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return node.Height();
            }

        }

        private void Rebalance(Node<T> node)
        {
            if (Height(node.Left) - Height(node.Right) > 1)
            {
                if (Height(node.Left.Left) > Height(node.Left.Right))
                {
                    node = RightRotate(node);
                }
                else
                {
                    node = LeftRightRotate(node);
                }
            }
            else
            {
                if (Height(node.Right.Left) > Height(node.Right.Right))
                {
                    node = RightLeftRotate(node);
                }
                else
                {
                    node = LeftRotate(node);
                }
            }

            if (node.Parent == null)
            {
                Root = node;
            }
        }

        private Node<T> LeftRotate(Node<T> node)
        {
            var child = node.Right;
            var grandChild = node.Right.Right;
            child.Parent = node.Parent;
            if (node.Parent != null)
            {
                node.Parent.Right = child;
            }
            node.Parent = child;
            child.Left = node;
            child.Right = grandChild;
            node.Right = null;
            grandChild.Parent = child;

            return child;
        }

        private Node<T> RightRotate(Node<T> node)
        {
            var child = node.Left;
            var grandChild = node.Left.Left;
            child.Parent = node.Parent;
            if (node.Parent != null)
            {
                node.Parent.Left = child;
            }
            node.Parent = child;
            child.Right = node;
            child.Left = grandChild;
            node.Left = null;
            grandChild.Parent = child;

            return child;
        }

        private Node<T> RightLeftRotate(Node<T> node)
        {
            var child = node.Right;
            var grandChild = node.Right.Left;
            grandChild.Parent = node.Parent;
            grandChild.Right = child;
            grandChild.Left = node;
            child.Left = null;
            node.Right = null;
            if (node.Parent != null)
            {
                node.Parent.Right = grandChild;
            }
            node.Parent = grandChild;
            child.Parent = grandChild;


            return grandChild;
        }

        private Node<T> LeftRightRotate(Node<T> node)
        {
            var child = node.Left;
            var grandChild = node.Left.Right;
            grandChild.Parent = node.Parent;
            if (node.Parent != null)
            {
                node.Parent.Left = grandChild;
            }
            node.Parent = grandChild;
            grandChild.Left = child;
            grandChild.Right = node;
            child.Right = null;
            node.Left = null;
            child.Parent = grandChild;

            return grandChild;
        }

        private void DFS(Node<T> node, List<Node<T>> collection)
        {
            if (node.Left != null)
            {
                DFS(node.Left, collection);
            }
            collection.Add(node);

            if (node.Right != null)
            {
                DFS(node.Right, collection);
            }
        }
    }
}
