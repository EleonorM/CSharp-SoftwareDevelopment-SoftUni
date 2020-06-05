namespace _04.Array_BasedStack.Tests
{
    using _03.ImplementArray_BasedStack;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

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

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_EmptyStack_ThrowsException()
        {
            // Arrange
            var stack = new ArrayStack<int>();

            // Act
            stack.Pop();

            // Assert: expect and exception
        }

        [TestMethod]
        public void PushPop100Elements_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new ArrayStack<int>();
            int numberOfElements = 1000;

            // Act
            for (int i = 0; i < numberOfElements; i++)
            {
                stack.Push(i);
            }

            // Assert
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(numberOfElements - i, stack.Count);
                var element = stack.Pop();
                Assert.AreEqual(1000 - 1 - i, element);
                Assert.AreEqual(numberOfElements - i - 1, stack.Count);
            }
        }

        [TestMethod]
        public void ArrayStack_PushPopManyChunks_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new ArrayStack<int>();
            int chunks = 100;

            // Act & Assert in a loop
            int value = 1;
            for (int i = 0; i < chunks; i++)
            {
                Assert.AreEqual(0, stack.Count);
                var chunkSize = i + 1;
                for (int counter = 0; counter < chunkSize; counter++)
                {
                    Assert.AreEqual(value - 1, stack.Count);
                    stack.Push(value);
                    Assert.AreEqual(value, stack.Count);
                    value++;
                }
                for (int counter = 0; counter < chunkSize; counter++)
                {
                    value--;
                    Assert.AreEqual(value, stack.Count);
                    stack.Pop();
                    Assert.AreEqual(value - 1, stack.Count);
                }
                Assert.AreEqual(0, stack.Count);
            }
        }

        [TestMethod]
        public void PushPop_WithInitialCapacity1_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new ArrayStack<int>(1);

            // Act & Assert
            stack.Push(1);
            Assert.AreEqual(1, stack.Count, "Stack does not grow properly.");

            stack.Push(2);
            Assert.AreEqual(2, stack.Count);

            var elementPoped = stack.Pop();
            Assert.AreEqual(2, elementPoped, "Stack does not return correct value.");
            Assert.AreEqual(1, stack.Count, "Stack does not grow properly.");

            var elementPoped2 = stack.Pop();
            Assert.AreEqual(1, elementPoped2);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void ToArray_NonEmptyList_ShouldReturnArray()
        {
            // Arrange
            var stack = new ArrayStack<int>();
            stack.Push(3);
            stack.Push(5);
            stack.Push(-2);
            stack.Push(7);

            // Act
            var arr = stack.ToArray();

            // Assert
            CollectionAssert.AreEqual(arr,
                new int[] { 7, -2, 5, 3 });
        }

        [TestMethod]
        public void ToArray_EmptyList_ShouldReturnEmptyArray()
        {
            // Arrange
            var stack = new ArrayStack<DateTime>();

            // Act
            var arr = stack.ToArray();

            // Assert
            CollectionAssert.AreEqual(arr, new List<DateTime>() { });
        }
    }
}
