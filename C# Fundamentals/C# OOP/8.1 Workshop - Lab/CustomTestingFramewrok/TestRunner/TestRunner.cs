namespace CustomTestingFramework.TestRunner
{
    using CustomTestingFramework.Attributes;
    using CustomTestingFramework.Exceptions;
    using CustomTestingFramework.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class TestRunner
    {
        private readonly ICollection<string> resultInfo;

        public TestRunner()
        {
            resultInfo = new List<string>();
        }

        public ICollection<string> Run(string assemblyPath)
        {
            var testClasses = Assembly
                .LoadFrom(assemblyPath)
                .GetTypes()
                .Where(ti => ti.HasAttribute<TestClassAttribute>())
                .ToList();

            foreach (var testClass in testClasses)
            {
                var testMethods = testClass
               .GetMethods()
                .Where(mi => mi.HasAttribute<TestMethodAttribute>())
                .ToList();

                var testClassInstance = Activator.CreateInstance(testClass);

                foreach (var methodInfo in testMethods)
                {
                    try
                    {
                        methodInfo.Invoke(testClassInstance, null);

                        resultInfo.Add($"Method: {methodInfo.Name} - passed!");
                    }
                    catch (TestException te)
                    {
                        resultInfo.Add($"Method: {methodInfo.Name} - failed!");
                    }
                    catch 
                    {
                        resultInfo.Add($"Method: {methodInfo.Name} - unexpected error ocured!");
                    }
                }
            }

            return resultInfo;
        }
    }
}
