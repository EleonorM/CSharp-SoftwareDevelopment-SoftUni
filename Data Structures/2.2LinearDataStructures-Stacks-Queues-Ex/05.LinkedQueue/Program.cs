public class Program
{
    public static void Main()
    {
        var testList = new LinkedQueue<int>();
        testList.Enqueue(1);
        testList.Enqueue(2);
        testList.Enqueue(3);

        var array = testList.ToArray();
        System.Console.WriteLine(string.Join(" ", array));
    }
}
