namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T left { get; set; }

        private T right { get; set; }

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            if (this.left.Equals(this.right))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
