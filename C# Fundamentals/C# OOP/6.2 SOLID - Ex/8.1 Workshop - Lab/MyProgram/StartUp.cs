namespace MyProgram
{
    using System;
    using CustomTestingFramework.TestRunner;

    public class StartUp
    {
        public static void Main()
        {
            var runner = new TestRunner();

            var result = runner.Run(@"..\..\..\..\CustomTestingFramework.Tests\bin\Debug\netcoreapp2.2\CustomTestingFramework.Tests.dll");

            foreach (var info in result)
            {
                Console.WriteLine(info);
            }
        }
    }
}
