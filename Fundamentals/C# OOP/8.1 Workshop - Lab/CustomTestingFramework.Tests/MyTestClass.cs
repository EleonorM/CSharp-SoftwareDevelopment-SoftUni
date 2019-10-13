namespace CustomTestingFramework.Tests
{
    using CustomTestingFramework.Asserts;
    using CustomTestingFramework.Attributes;
    using System;

    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void ShouldSumValues()
        {
            int a = 2;
            int b = 3;
            int expected = 5;

            int actual = a + b;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ShouldSumValues2()
        {
            int a = 2;
            int b = 3;
            int expected = 6;

            int actual = a + b;

            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void ShouldSumValues3()
        {
            var a = new string[5];

            Assert.Throws<IndexOutOfRangeException>(() => a[12] == "LALA");
        }
    }
}
