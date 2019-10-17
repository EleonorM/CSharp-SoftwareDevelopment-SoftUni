namespace Chainblock.Tests
{
    using Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ChainblockTests
    {
        [Test]
        public void Constructor_ShouldInitalizeCollection()
        {
            var chainblock = new Chainblock();

            var expected = 0;
            Assert.AreEqual(expected, chainblock.Count);
        }

        [Test]
        public void Add_ShouldAddCorrectly()
        {
            var id = 123;
            var transaction = new Transaction();
            transaction.Id = id;
            var chainblock = new Chainblock();

            chainblock.Add(transaction);

            Assert.That(chainblock.Contains(transaction));
        }

        [Test]
        public void Add_ShouldNotAddTransactionIfAlreadyExists()
        {
            var id1 = 123;
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.From = "1";
            var id2 = 123;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.From = "2";

            var chainblock = new Chainblock();
            chainblock.Add(transaction1);

            chainblock.Add(transaction2);

            Assert.That(!(chainblock.First(x => x.Id == transaction2.Id).From == "2"));
        }

        [Test]
        public void Contains_ShouldReturnProperValue_WhenGivenTransaction()
        {
            var id1 = 123;
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.From = "1";
            var chainblock = new Chainblock();

            chainblock.Add(transaction1);

            Assert.That(chainblock.Contains(transaction1));
        }

        [Test]
        public void Contains_ShouldReturnProperValue_WhenGivenId()
        {
            var id1 = 123;
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            var chainblock = new Chainblock();

            chainblock.Add(transaction1);

            Assert.That(chainblock.Contains(id1));
        }

        [Test]
        public void ChangeTransactionStatus_ShouldChangeStatusOfTheTransactionWithGivenId()
        {
            var id1 = 123;
            var status1 = TransactionStatus.Aborted;
            var status2 = TransactionStatus.Successfull;
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Status = status1;
            var chainblock = new Chainblock();

            chainblock.Add(transaction1);
            chainblock.ChangeTransactionStatus(id1, status2);

            Assert.AreEqual(status2, chainblock.GetById(id1).Status);
        }

        [Test]
        public void ChangeTransactionStatus_ShouldThrowArgumentException_WhenTransactionDoesnotExist()
        {
            var id1 = 123;
            var id2 = 122;
            var status1 = TransactionStatus.Aborted;
            var status2 = TransactionStatus.Successfull;
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Status = status1;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);

            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(id2, status2));
        }

        [Test]
        public void RemoveTransactionById_ShouldRemoveSuccsesfully()
        {
            var id1 = 123;
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);

            chainblock.RemoveTransactionById(id1);

            Assert.That(!chainblock.Contains(id1));
        }

        [Test]
        public void RemoveTransactionById_ShouldThrowInvalidOperationException_WhenTransactionDoesnotExist()
        {
            var id1 = 123;
            var id2 = 122;
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);

            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(id2));
        }

        [Test]
        public void GetById_ShouldReturnTransactionWithGivenId()
        {
            var id1 = 123;
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);

            var actual = chainblock.GetById(id1);
            Assert.AreEqual(transaction1, actual);
        }

        [Test]
        public void GetById_ShouldThrowInvalidOperationException_WhenTransactionWithGivenIdDoesNotExist()
        {
            var id1 = 123;
            var id2 = 122;
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(id2));
        }

        [Test]
        public void GetByTransactionStatus_ShouldReturnOrderedTransactionsWithGivenStatus()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);


            var expected = (new List<Contracts.ITransaction>() { transaction1, transaction2 }).OrderByDescending(x => x.Amount);
            CollectionAssert.AreEqual(expected, chainblock.GetByTransactionStatus(status));
        }

        [Test]
        public void GetByTransactionStatus_ShouldThrowInvalidOperationException_WhenNoTransactionsWithgivenStatus()
        {
            var status = TransactionStatus.Successfull;
            var statusSearched = TransactionStatus.Aborted;
            var id1 = 123;
            var amount1 = 10;
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);


            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(statusSearched));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ShouldReturnOrderedCollection()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);


            var expected = (new List<Contracts.ITransaction>() { transaction1, transaction2 }).OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
            CollectionAssert.AreEqual(expected, chainblock.GetAllOrderedByAmountDescendingThenById());
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldReturnOrderedCollection()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var sender1 = "Sender1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.From = sender1;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.From = sender1;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);


            var expected = (new List<Contracts.ITransaction>() { transaction1, transaction2 }).OrderByDescending(x => x.Amount);
            CollectionAssert.AreEqual(expected, chainblock.GetBySenderOrderedByAmountDescending(sender1));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldThrowInvalidOperationException_WhenGivenFalseSender()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var sender1 = "Sender1";
            var sender2 = "Sender2";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.From = sender1;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.From = sender1;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending(sender2));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldReturnOrderedCollection()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var reciever1 = "Reciever1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.To = reciever1;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.To = reciever1;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);


            var expected = (new List<Contracts.ITransaction>() { transaction1, transaction2 }).OrderByDescending(x => x.Amount).ThenBy(x => x.Id);

            CollectionAssert.AreEqual(expected, chainblock.GetByReceiverOrderedByAmountThenById(reciever1));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldThrowInvalidOperationException_WhenGivenFalseReciever()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var reciever1 = "Reciever1";
            var reciever2 = "Reciever2";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.To = reciever1;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.To = reciever1;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById(reciever2));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnOrderedCollection()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var reciever1 = "Reciever1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.To = reciever1;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.To = reciever1;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var maxAmount = 10.30;
            IEnumerable<ITransaction> expected = (new List<Contracts.ITransaction>() { transaction1, transaction2 }).OrderByDescending(x => x.Amount).ToList();

            CollectionAssert.AreEquivalent(expected, chainblock.GetByTransactionStatusAndMaximumAmount(status, maxAmount));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnEmptyCollection_WhenStatusdoesNotExist()
        {
            var status = TransactionStatus.Successfull;
            var status2 = TransactionStatus.Aborted;
            var id1 = 123;
            var amount1 = 10;
            var reciever1 = "Reciever1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.To = reciever1;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.To = reciever1;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var maxAmount = 10.30;
            IEnumerable<ITransaction> expected = new List<ITransaction>();

            CollectionAssert.AreEquivalent(expected, chainblock.GetByTransactionStatusAndMaximumAmount(status2, maxAmount));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnEmptyCollection_WhenAmountIsBigger()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var reciever1 = "Reciever1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.To = reciever1;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.To = reciever1;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var maxAmount = 9;
            IEnumerable<ITransaction> expected = new List<ITransaction>();

            CollectionAssert.AreEquivalent(expected, chainblock.GetByTransactionStatusAndMaximumAmount(status, maxAmount));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldReturnOrderedCollection()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var sender = "Sender1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.From = sender;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.From = sender;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            IEnumerable<string> expected = (new List<Contracts.ITransaction>() { transaction1, transaction2 }).OrderByDescending(x => x.Amount).Select(x=>x.From).ToList();

            CollectionAssert.AreEquivalent(expected, chainblock.GetAllSendersWithTransactionStatus(status));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldThrowInvalidOperationException_WhenStatusDoesNotExist()
        {
            var status = TransactionStatus.Successfull;
            var status2 = TransactionStatus.Aborted;
            var id1 = 123;
            var amount1 = 10;
            var sender = "Sender1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.From = sender;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.From = sender;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            Assert.Throws< InvalidOperationException>(()=> chainblock.GetAllSendersWithTransactionStatus(status2));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldReturnOrderedCollection()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var reciever1 = "Reciever1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.To = reciever1;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.To = reciever1;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            IEnumerable<string> expected = (new List<Contracts.ITransaction>() { transaction1, transaction2 }).OrderByDescending(x => x.Amount).Select(x => x.To).ToList();

            CollectionAssert.AreEquivalent(expected, chainblock.GetAllReceiversWithTransactionStatus(status));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldThrowInvalidOperationException_WhenStatusDoesNotExist()
        {
            var status = TransactionStatus.Successfull;
            var status2 = TransactionStatus.Aborted;
            var id1 = 123;
            var amount1 = 10;
            var reciever1 = "Reciever1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.To = reciever1;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.To = reciever1;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllReceiversWithTransactionStatus(status2));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldReturnOrderedCollection()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var sender = "Sender1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.From = sender;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.From = sender;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var minAmount = 9;
            IEnumerable<ITransaction> expected = (new List<Contracts.ITransaction>() { transaction1, transaction2 }).OrderByDescending(x => x.Amount).ToList();

            CollectionAssert.AreEquivalent(expected, chainblock.GetBySenderAndMinimumAmountDescending(sender, minAmount));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldThrowInvalidOperationException_WhenSenderDoesNotExist()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var sender = "Sender1";
            var sender2 = "Sender2";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.From = sender;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.From = sender;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var minAmount = 9;
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending(sender2, minAmount));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldThrowInvalidOperationException_WhenAmountIsSmaller()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var sender = "Sender1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.From = sender;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.From = sender;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var minAmount = 10.3;
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending(sender, minAmount));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldReturnOrderedCollection()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var reciever = "Reciever1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.To = reciever;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.To = reciever;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var minAmount = 9;
            var maxAmount = 11;
            IEnumerable<ITransaction> expected = (new List<ITransaction>() { transaction1, transaction2 }).OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();

            CollectionAssert.AreEquivalent(expected, chainblock.GetByReceiverAndAmountRange(reciever, minAmount, maxAmount));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldThrowInvalidOperationException_WhenThereIsNoAmountBetween()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var reciever = "Reciever1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.To = reciever;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.To = reciever;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var minAmount = 11;
            var maxAmount = 13;
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange(reciever, minAmount, maxAmount));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldThrowInvalidOperationException_WhenRecieverDoesNotExist()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var reciever = "Reciever1";
            var reciever2 = "Reciever2";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.To = reciever;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.To = reciever;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var minAmount = 9;
            var maxAmount = 13;
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange(reciever2, minAmount, maxAmount));
        }

        [Test]
        public void GetAllInAmountRange_ShouldReturnOrderedCollection()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var reciever = "Reciever1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.To = reciever;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.To = reciever;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var minAmount = 9;
            var maxAmount = 11;
            IEnumerable<ITransaction> expected = new List<ITransaction>() { transaction1, transaction2 };

            CollectionAssert.AreEquivalent(expected, chainblock.GetAllInAmountRange(minAmount, maxAmount));
        }

        [Test]
        public void GetAllInAmountRange_ShouldReturnEmptyCollection_WhenNoInRange()
        {
            var status = TransactionStatus.Successfull;
            var id1 = 123;
            var amount1 = 10;
            var reciever = "Reciever1";
            var transaction1 = new Transaction();
            transaction1.Id = id1;
            transaction1.Amount = amount1;
            transaction1.Status = status;
            transaction1.To = reciever;
            var id2 = 124;
            var amount2 = 10.2;
            var transaction2 = new Transaction();
            transaction2.Id = id2;
            transaction2.Amount = amount2;
            transaction2.Status = status;
            transaction2.To = reciever;
            var chainblock = new Chainblock();
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var minAmount = 15;
            var maxAmount = 16;
            IEnumerable<ITransaction> expected = new List<ITransaction>();

            CollectionAssert.AreEquivalent(expected, chainblock.GetAllInAmountRange(minAmount, maxAmount));
        }
    }
}
