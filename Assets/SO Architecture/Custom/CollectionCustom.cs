using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
    public partial class Collection<T> : BaseCollection, IEnumerable<T>
    {
        public new T this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                var oldValue = _list[index];
                _list[index] = value;
                RaiseValueAdded(value);
                if(oldValue != null) RaiseValueRemoved(oldValue);
                RaiseCollectionUpdated();
            }
        }

        public void Add(T obj)
        {
            _list.Add(obj);
            RaiseValueAdded(obj);
            RaiseCollectionUpdated();
        }

        public void Remove(T obj)
        {
            if (!_list.Contains(obj)) return;
            _list.Remove(obj);
            RaiseValueRemoved(obj);
            RaiseCollectionUpdated();
        }

        public void Clear()
        {
            _list.Clear();
            RaiseCollectionUpdated();
        }

        public void RemoveAt(int index)
        {
            var item = _list[index];
            _list.RemoveAt(index);
            RaiseValueRemoved(item);
            RaiseCollectionUpdated();
        }

        public void Insert(int index, T value)
        {
            _list.Insert(index, value);
            RaiseValueAdded(value);
            RaiseCollectionUpdated();
        }

        #region Events

        //Collection Event Custom replicated here to not mess with the base class hierarchy and editor code
        protected readonly List<IGameEventListener<T>> _itemAddedListeners = new List<IGameEventListener<T>>();
        protected readonly List<System.Action<T>> _itemAddedActions = new List<System.Action<T>>();
        protected readonly List<IGameEventListener<T>> _itemRemovedListeners = new List<IGameEventListener<T>>();
        protected readonly List<System.Action<T>> _itemRemovedActions = new List<System.Action<T>>();
        protected readonly List<IGameEventListener> _collectionUpdatedListeners = new List<IGameEventListener>();
        protected readonly List<System.Action> _collectionUpdatedActions = new List<System.Action>();

        public virtual void RaiseCollectionUpdated()
        {
            for (int i = _collectionUpdatedListeners.Count - 1; i >= 0; i--)
                _collectionUpdatedListeners[i].OnEventRaised();

            for (int i = _collectionUpdatedActions.Count - 1; i >= 0; i--)
                _collectionUpdatedActions[i]();
        }

        public virtual void RaiseValueAdded(T value)
        {
            for (int i = _itemAddedListeners.Count - 1; i >= 0; i--)
                _itemAddedListeners[i].OnEventRaised(value);

            for (int i = _itemAddedActions.Count - 1; i >= 0; i--)
                _itemAddedActions[i](value);
        }
        public virtual void RaiseValueRemoved(T value)
        {
            for (int i = _itemAddedListeners.Count - 1; i >= 0; i--)
                _itemRemovedListeners[i].OnEventRaised(value);

            for (int i = _itemAddedActions.Count - 1; i >= 0; i--)
                _itemRemovedActions[i](value);
        }

        public virtual void AddListenerToCollectionUpdated(IGameEventListener listener)
        {
            if (!_collectionUpdatedListeners.Contains(listener))
                _collectionUpdatedListeners.Add(listener);
        }
        public virtual void AddListenerToCollectionUpdated(System.Action action)
        {
            if (!_collectionUpdatedActions.Contains(action))
                _collectionUpdatedActions.Add(action);
        }

        public virtual void RemoveListenerToCollectionUpdated(IGameEventListener listener)
        {
            if (_collectionUpdatedListeners.Contains(listener))
                _collectionUpdatedListeners.Remove(listener);
        }
        public virtual void RemoveListenerToCollectionUpdated(System.Action action)
        {
            if (_collectionUpdatedActions.Contains(action))
                _collectionUpdatedActions.Remove(action);
        }
        public virtual void AddListenerToItemAdded(IGameEventListener<T> listener)
        {
            if (!_itemAddedListeners.Contains(listener))
                _itemAddedListeners.Add(listener);
        }
        public virtual void AddListenerToItemAdded(System.Action<T> action)
        {
            if (!_itemAddedActions.Contains(action))
                _itemAddedActions.Add(action);
        }
        public virtual void RemoveListenerToItemAdded(IGameEventListener<T> listener)
        {
            if (_itemAddedListeners.Contains(listener))
                _itemAddedListeners.Remove(listener);
        }

        public virtual void RemoveListenerToItemAdded(System.Action<T> action)
        {
            if (_itemAddedActions.Contains(action))
                _itemAddedActions.Remove(action);
        }
        public virtual void RemoveListenerToItemRemoved(IGameEventListener<T> listener)
        {
            if (_itemRemovedListeners.Contains(listener))
                _itemRemovedListeners.Remove(listener);
        }
        public virtual void AddListenerToItemRemoved(IGameEventListener<T> listener)
        {
            if (!_itemRemovedListeners.Contains(listener))
                _itemRemovedListeners.Add(listener);
        }

        public virtual void AddListenerToItemRemoved(System.Action<T> action)
        {
            if (!_itemRemovedActions.Contains(action))
                _itemRemovedActions.Add(action);
        }
        public virtual void RemoveListenerToItemRemoved(System.Action<T> action)
        {
            if (_itemRemovedActions.Contains(action))
                _itemRemovedActions.Remove(action);
        }

        public virtual void RemoveAllListeners()
        {
            _itemAddedListeners.RemoveRange(0, _itemAddedListeners.Count);
            _itemAddedActions.RemoveRange(0, _itemAddedActions.Count);
            _itemRemovedListeners.RemoveRange(0, _itemRemovedListeners.Count);
            _itemRemovedActions.RemoveRange(0, _itemRemovedActions.Count);
            _collectionUpdatedListeners.RemoveRange(0, _collectionUpdatedListeners.Count);
            _collectionUpdatedActions.RemoveRange(0, _collectionUpdatedActions.Count);
        }

        #endregion
    }
}