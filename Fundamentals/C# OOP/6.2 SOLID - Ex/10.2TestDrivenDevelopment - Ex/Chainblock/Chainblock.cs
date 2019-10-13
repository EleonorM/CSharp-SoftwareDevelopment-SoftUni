using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private List<ITransaction> transactions;

        public Chainblock()
        {
            transactions = new List<ITransaction>();
        }

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (!this.transactions.Any(x => x.Id == tx.Id))
            {
                this.transactions.Add(tx);
            }
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            var transaction = this.transactions.FirstOrDefault(x => x.Id == id);
            if (transaction == null)
            {
                throw new ArgumentException();
            }

            transaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            return this.transactions.Any(x => x.Id == tx.Id);
        }

        public bool Contains(int id)
        {
            return this.transactions.Any(x => x.Id == id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return this.transactions.Where(x => x.Amount > lo && x.Amount < hi).ToList();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var collection = this.transactions
             .Where(x => x.Status == status)
             .OrderByDescending(x => x.Amount)
             .Select(x => x.To)
             .ToList();
            if (collection.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return collection;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var collection = this.transactions
            .Where(x => x.Status == status)
            .OrderByDescending(x => x.Amount)
            .Select(x => x.From)
            .ToList();
            if (collection.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return collection;
        }

        public ITransaction GetById(int id)
        {
            var transaction = this.transactions.FirstOrDefault(x => x.Id == id);
            if (transaction == null)
            {
                throw new InvalidOperationException();
            }

            return transaction;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var collection = this.transactions
                .Where(x => x.To == receiver)
                .Where(x => x.Amount > lo && x.Amount <= hi)
                .ToList();

            if (collection.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return collection.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var collection = this.transactions.Where(x => x.To == receiver).ToList();

            if (collection.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return collection.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var collection = this.transactions.Where(x => x.From == sender).Where(x => x.Amount > amount).ToList();
            if (collection.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return collection.OrderByDescending(x => x.Amount).ToList();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var collection = this.transactions.Where(x => x.From == sender).ToList();

            if (collection.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return collection.OrderByDescending(x => x.Amount).ToList();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> collection = this.transactions.Where(x => x.Status == status).ToList();

            if (collection.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return collection.OrderByDescending(x => x.Amount).ToList();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this.transactions.Where(x => x.Status == status).Where(x => x.Amount <= amount).ToList();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var item in this.transactions)
            {
                yield return item;
            }
        }

        public void RemoveTransactionById(int id)
        {
            var transaction = this.transactions.FirstOrDefault(x => x.Id == id);
            if (transaction == null)
            {
                throw new InvalidOperationException();
            }

            this.transactions.Remove(transaction);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
