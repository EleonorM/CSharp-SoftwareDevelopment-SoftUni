namespace _04.Array_BasedStack.UnitTests
{
    using _03.ImplementArray_BasedStack;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTestsArray_BasedStack
    {
        [TestMethod]
        public void Enqueue_EmptyStack_ShouldAddElement()
        {
            // Arrange
            var stack = new ArrayStack<int>();

            // Act
            stack.Push(5);

            // Assert
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void PushPop_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new ArrayStack<string>();
            var element = "some value";

            // Act
            stack.Push(element);
            var elementFromQueue = stack.Pop();

            // Assert
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(element, elementFromQueue);
        }
    }
}
