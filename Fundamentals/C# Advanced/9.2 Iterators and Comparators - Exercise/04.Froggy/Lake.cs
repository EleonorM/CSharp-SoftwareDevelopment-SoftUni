namespace _04.Froggy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        public int[] Stones { get; set; }

        public Lake(int[] stones)
        {
            this.Stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Stones.Length; i = i + 2)
            {
                yield return Stones[i];
            }

            var counter = Stones.Length;
            if (Stones.Length % 2 != 0)
            {
                counter--;
            }

            for (int i = counter - 1; i >= 1; i = i - 2)
            {
                yield return Stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
