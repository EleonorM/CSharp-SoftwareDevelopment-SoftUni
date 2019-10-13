namespace Chainblock
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var id1 = 123;
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            var id2 = 123;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);

            chainblock.Add(transaction2);

            System.Console.WriteLine(chainblock.Contains(transaction2));

        }
    }
}
