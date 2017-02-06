using System;
using System.Collections.Generic;
using System.Threading;

namespace Mall.Infrastructure.DomainCore
{
    public abstract class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Private Fields
        private readonly ThreadLocal<Dictionary<string, AggregateRoot>> _localNewCollection = new ThreadLocal<Dictionary<string, AggregateRoot>>(() => new Dictionary<string, AggregateRoot>());

        private readonly ThreadLocal<Dictionary<string, AggregateRoot>> _localModifiedCollection = new ThreadLocal<Dictionary<string, AggregateRoot>>(() => new Dictionary<string, AggregateRoot>());

        private readonly ThreadLocal<Dictionary<string, AggregateRoot>> _localDeletedCollection = new ThreadLocal<Dictionary<string, AggregateRoot>>(() => new Dictionary<string, AggregateRoot>());

        private readonly ThreadLocal<bool> _localCommitted = new ThreadLocal<bool>(() => false);
        #endregion

        #region Protected Methods
        protected void ClearRegistrations()
        {
            _localNewCollection.Value.Clear();
            _localModifiedCollection.Value.Clear();
            _localDeletedCollection.Value.Clear();
        }
        #endregion

        #region Protected Properties
        protected IEnumerable<KeyValuePair<string, AggregateRoot>> ModifiedCollection
        {
            get { return _localModifiedCollection.Value; }
        }

        protected IEnumerable<KeyValuePair<string, AggregateRoot>> DeletedCollection
        {
            get { return _localDeletedCollection.Value; }
        }
        #endregion

        public abstract TRepositoryItem LockObject<TRepositoryItem>(TRepositoryItem obj)
            where TRepositoryItem : AggregateRoot;

        public virtual void RegisterSaved<TRepositoryItem>(TRepositoryItem obj)
            where TRepositoryItem : AggregateRoot
        {
            var objId = obj.ID;
            if (string.IsNullOrEmpty(objId))
                throw new ArgumentException("The UniqueIdentifier of the object is empty.", "obj");

            if (_localDeletedCollection.Value.ContainsKey(objId))
                throw new InvalidOperationException("The object cannot be registered as a modified object since it was marked as deleted.");

            if (!_localModifiedCollection.Value.ContainsKey(objId) && !_localNewCollection.Value.ContainsKey(objId))
                _localModifiedCollection.Value.Add(objId, obj);

            _localCommitted.Value = false;
        }

        /// <summary>
        /// Registers a deleted object to the repository context.
        /// </summary>
        /// <typeparam name="TRepositoryItem">The type of the aggregate root.</typeparam>
        /// <param name="obj">The object to be registered.</param>
        public virtual void RegisterRemoved<TRepositoryItem>(TRepositoryItem obj)
            where TRepositoryItem : AggregateRoot
        {
            var objId = obj.ID;
            if (objId.Equals(string.Empty))
                throw new ArgumentException("The UniqueIdentifier of the object is empty.", "obj");

            if (_localNewCollection.Value.ContainsKey(objId))
            {
                if (_localNewCollection.Value.Remove(objId))
                    return;
            }

            bool removedFromModified = _localModifiedCollection.Value.Remove(objId);
            bool addedToDeleted = false;
            if (!_localDeletedCollection.Value.ContainsKey(objId))
            {
                _localDeletedCollection.Value.Add(objId, obj);
                addedToDeleted = true;
            }

            _localCommitted.Value = !(removedFromModified || addedToDeleted);
        }

        /// <summary>
        /// Gets a <see cref="System.Boolean"/> value which indicates whether the UnitOfWork
        /// was committed.
        /// </summary>
        public bool Committed
        {
            get { return _localCommitted.Value; }
            protected set { _localCommitted.Value = value; }
        }

        /// <summary>
        /// Commits the UnitOfWork.
        /// </summary>
        public abstract bool Commit();

        /// <summary>
        /// Rolls-back the UnitOfWork.
        /// </summary>
        public abstract void Rollback();

        public void Dispose()
        {
            _localCommitted.Dispose();
            _localDeletedCollection.Dispose();
            _localModifiedCollection.Dispose();
            _localNewCollection.Dispose();
        }
    }
}
