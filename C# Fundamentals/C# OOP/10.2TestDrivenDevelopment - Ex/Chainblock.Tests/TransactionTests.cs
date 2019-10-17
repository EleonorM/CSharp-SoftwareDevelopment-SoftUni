using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainBlockTests
    {

        [Test]
        public void Transaction_ShouldSetProperId()
        {
            var id = 123;
            var transaction = new Transaction();
            transaction.Id = id;

            Assert.AreEqual(id, transaction.Id);
        }

        [Test]
        public void Transaction_ShouldSetProperTransactionStatus()
        {
            var status = TransactionStatus.Aborted;
            var transaction = new Transaction();
            transaction.Status = status;

            Assert.AreEqual(status, transaction.Status);
        }

        [Test]
        public void Transaction_ShouldSetProperFrom()
        {
            var from = "TestSender";
            var transaction = new Transaction();
            transaction.From = from;

            Assert.AreEqual(from, transaction.From);
        }

        [Test]
        public void Transaction_ShouldSetProperTo()
        {
            var to = "TestReciever";
            var transaction = new Transaction();
            transaction.To = to;

            Assert.AreEqual(to, transaction.To);
        }

        [Test]
        public void Transaction_ShouldSetProperAmount()
        {
            var amount = 10.2;
            var transaction = new Transaction();
            transaction.Amount = amount;

            Assert.AreEqual(amount, transaction.Amount);
        }


        [Test]
        public void Transaction_ShouldCompareProperly()
        {
            var id1 = 123;
            var transaction1 = new Transaction();
            transaction1.Id = id1;

            var id2 = 124;
            var transaction2 = new Transaction();
            transaction2.Id = id2;

            var expected = -1;
            Assert.AreEqual(expected, transaction1.CompareTo(transaction2));
        }
    }
}
