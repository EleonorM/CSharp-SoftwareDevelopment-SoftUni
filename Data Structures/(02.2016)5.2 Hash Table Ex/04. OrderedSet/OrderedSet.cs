namespace _04._OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private Node<T> Root;

        public int Count { get; set; }

        public void Add(T element)
        {
            if (Count == 0)
            {
                Root = new Node<T>(element);
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
                            currentNode.Right = new Node<T>(element);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.Right;
                        }
                    }
                    else if (element.CompareTo(currentNode.Value) < 0)
                    {
                        if (currentNode.Left == null)
                        {
                            currentNode.Left = new Node<T>(element);
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

        public void Remove(T element)
        {
            var currentNode = Root;
            while (currentNode != null)
            {
                if (element.CompareTo(currentNode.Value) > 0)
                {
                    if (currentNode.Right.Value.Equals(element))
                    {
                        currentNode.Right = null;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                    }
                }
                else if (element.CompareTo(currentNode.Value) < 0)
                {
                    if (currentNode.Left.Value.Equals(element))
                    {
                        currentNode.Left = null;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                    }
                }
                else
                {
                    currentNode = null;
                }
            }

            Count--;
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
