namespace _08.LinkedQueue.Tests
{
    using _07.LinkedQueue;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class UnitTestLinkedQueue
    {
        [TestMethod]
        public void Enqueue_EmptyQueue_ShouldAddElement()
        {
            // Arrange
            var queue = new LinkedQueue<int>();

            // Act
            queue.Enqueue(5);

            // Assert
            Assert.AreEqual(1, queue.Count);
        }

        [TestMethod]
        public void EnqueueDeque_ShouldWorkCorrectly()
        {
            // Arrange
            var queue = new LinkedQueue<string>();
            var element = "some value";

            // Act
            queue.Enqueue(element);
            var elementFromQueue = queue.Dequeue();

            // Assert
            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(element, elementFromQueue);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_EmptyQueue_ThrowsException()
        {
            // Arrange
            var queue = new LinkedQueue<int>();

            // Act
            queue.Dequeue();

            // Assert: expect and exception
        }

        [TestMethod]
        public void EnqueueDequeue100Elements_ShouldWorkCorrectly()
        {
            // Arrange
            var queue = new LinkedQueue<int>();
            int numberOfElements = 1000;

            // Act
            for (int i = 0; i < numberOfElements; i++)
            {
                queue.Enqueue(i);
            }

            // Assert
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(numberOfElements - i, queue.Count);
                var element = queue.Dequeue();
                Assert.AreEqual(i, element);
                Assert.AreEqual(numberOfElements - i - 1, queue.Count);
            }
        }

        [TestMethod]
        public void Enqueue500Elements_ToArray_ShouldWorkCorrectly()
        {
            // Arrange
            var array = Enumerable.Range(1, 500).ToArray();
            var queue = new LinkedQueue<int>();

            // Act
            for (int i = 0; i < array.Length; i++)
            {
                queue.Enqueue(array[i]);
            }
            var arrayFromQueue = queue.ToArray();

            // Assert
            CollectionAssert.AreEqual(array, arrayFromQueue);
        }

        [TestMethod]
        public void ToArray_EmptyList_ShouldReturnEmptyArray()
        {
            // Arrange
            var list = new LinkedQueue<string>();

            // Act
            var arr = list.ToArray();

            // Assert
            CollectionAssert.AreEqual(arr, new List<string>() { });
        }

        [TestMethod]
        public void ToArray_NonEmptyList_ShouldReturnArray()
        {
            // Arrange
            var list = new LinkedQueue<string>();
            list.Enqueue("Five");
            list.Enqueue("Six");
            list.Enqueue("Seven");

            // Act
            var arr = list.ToArray();

            // Assert
            CollectionAssert.AreEqual(arr,
                new string[] { "Five", "Six", "Seven" });
        }
    }
}
