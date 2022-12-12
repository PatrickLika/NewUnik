using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Transactions;
using Unik.SqlServerContext;
using System.Data;

namespace Unik.Crosscut.TransactionHandling.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UnikContext _db;
        private IDbContextTransaction _transaction;

        public UnitOfWork(UnikContext unikContext)
        {
            _db = unikContext;
        }

        void IUnitOfWork.BeginTransaction(System.Data.IsolationLevel isolationLevel)
        {
            _transaction = _db.Database.CurrentTransaction ?? _db.Database.BeginTransaction(isolationLevel);
        }

        void IUnitOfWork.Commit()
        {
            _transaction.Commit();
            _transaction.Dispose();
        }

        void IUnitOfWork.Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
