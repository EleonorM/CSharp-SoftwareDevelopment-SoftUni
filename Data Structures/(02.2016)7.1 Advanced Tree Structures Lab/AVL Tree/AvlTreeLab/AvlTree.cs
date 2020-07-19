namespace AvlTreeLab
{
    using System;

    public class AvlTree<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            var inserted = true;
            if (this.root == null)
            {
                root = new Node<T>(item);
            }
            else
            {
                inserted = this.InsertInternal(root, item);
            }

            if (inserted)
            {
                Count++;
            }
        }

        private bool InsertInternal(Node<T> node, T item)
        {
            var currentNode = node;
            var newNode = new Node<T>(item);
            var shouldRetrace = false;
            while (true)
            {
                if (currentNode.Value.CompareTo(item) < 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = newNode;
                        newNode.Parent = currentNode;
                        newNode.BalanceFactor = 0;
                        currentNode.BalanceFactor--;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }

                    currentNode = currentNode.RightChild;
                }
                else if (currentNode.Value.CompareTo(item) > 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = newNode;
                        newNode.Parent = currentNode;
                        newNode.BalanceFactor = 0;
                        currentNode.BalanceFactor++;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }

                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    return false;
                }
            }

            if (shouldRetrace)
            {
                this.RetraceInsert(currentNode);
            }

            return true;
        }

        private void RetraceInsert(Node<T> node)
        {
            var parent = node.Parent;
            while (parent != null)
            {
                if (node.IsLeftChild())
                {
                    parent.BalanceFactor++;
                    if (parent.BalanceFactor == 2)
                    {
                        if (node.BalanceFactor == -1)
                        {
                            this.RotateLeft(node);
                        }

                        this.RotateRight(parent);
                        break;

                    }
                    else if (parent.BalanceFactor == 0)
                    {
                        break;
                    }
                }
                else
                {
                    parent.BalanceFactor--;
                    if (parent.BalanceFactor == -2)
                    {
                        if (node.BalanceFactor == 1)
                        {
                            this.RotateRight(node);
                        }

                        this.RotateLeft(parent);
                        break;

                    }
                    else if (parent.BalanceFactor == 0)
                    {
                        break;
                    }
                }

                node = parent;
                parent = node.Parent;
            }
        }

        private void RotateRight(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.LeftChild;
            if (parent != null)
            {
                if (node.IsRightChild())
                {
                    parent.RightChild = child;
                }
                else
                {
                    parent.LeftChild = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }

            node.LeftChild = child.RightChild;
            child.RightChild = node;

            node.BalanceFactor -= 1 + Math.Max(child.BalanceFactor, 0);
            child.BalanceFactor -= 1 - Math.Min(node.BalanceFactor, 0);
        }

        private void RotateLeft(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.RightChild;
            if (parent != null)
            {
                if (node.IsLeftChild())
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }

            node.RightChild = child.LeftChild;
            child.LeftChild = node;

            node.BalanceFactor += 1 - Math.Min(child.BalanceFactor, 0);
            child.BalanceFactor += 1 + Math.Max(node.BalanceFactor, 0);
        }

        public bool Contains(T item)
        {
            var node = this.root;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }

                if (node.Value.CompareTo(item) < 0)
                {
                    node = node.RightChild;
                }
                else if (node.Value.CompareTo(item) > 0)
                {
                    node = node.LeftChild;
                }

            }

            return false;
        }

        public void ForeachDfs(Action<int, T> action)
        {
            if (this.Count == 0)
            {
                return;
            }

            this.InOrderDfs(this.root, 1, action);
        }

        private void InOrderDfs(Node<T> node, int depth, Action<int, T> action)
        {
            if (node.LeftChild != null)
            {
                InOrderDfs(node.LeftChild, depth + 1, action);

            }

            action(depth, node.Value);

            if (node.RightChild != null)
            {
                InOrderDfs(node.RightChild, depth + 1, action);
            }
        }
    }
}
