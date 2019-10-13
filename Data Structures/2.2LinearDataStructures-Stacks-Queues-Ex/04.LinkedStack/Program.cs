public class Program
{
    public static void Main()
    {
        var testList = new LinkedStack<int>();
        testList.Push(1);
        testList.Push(2);
        testList.Push(3);

        var array = testList.ToArray();
        System.Console.WriteLine(string.Join(" ", array));
    }
}
