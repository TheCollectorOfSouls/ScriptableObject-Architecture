using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [Serializable]
    public class BaseCollectionReference<TBase, TVariable> : BaseCollectionReference<TBase>, IEnumerable<TBase>
        where TVariable : Collection<TBase>
    {
        public BaseCollectionReference(){}
        public BaseCollectionReference(List<TBase> baseValue)
        {
            _useConstant = true;
            _constantValue = new List<TBase>(baseValue);
        }

        [SerializeField] protected bool _useConstant = false;
        [SerializeField] protected List<TBase> _constantValue = new List<TBase>();
        [SerializeField] protected TVariable _variable;

        public virtual TVariable Variable
        {
            get => _variable;
            set
            {
                _useConstant = false;
                _variable = value;
                RaiseCollectionUpdated();
            }
        }

        public virtual BaseCollectionReference<TBase> CreateCopy()
        {
            BaseCollectionReference<TBase, TVariable> copy =
                (BaseCollectionReference<TBase, TVariable>)System.Activator.CreateInstance(GetType());
            copy._useConstant = _useConstant;
            copy._constantValue = new List<TBase>(_constantValue);
            copy._variable = _variable;

            return copy;
        }

        public new virtual TBase this[int index]
        {
            get
            {
                if(_variable != null && !_useConstant)
                    return _variable[index];
                return _constantValue[index];
            }
            set
            {
                if(_variable != null && !_useConstant)
                {
                    _variable[index] = value;
                }
                else
                {
                    var oldValue = _constantValue[index];
                    _constantValue[index] = value;
                    RaiseValueAdded(value);
                    if(oldValue != null) RaiseValueRemoved(oldValue);
                    RaiseCollectionUpdated();
                }
            }
        }

        public override IList List
        {
            get
            {
                if(_variable != null && !_useConstant)
                    return _variable.List;
                return _constantValue;
            }
        }

        public override Type Type
        {
            get
            {
                if(_variable != null && !_useConstant)
                    return _variable.Type;
                return typeof(TBase);
            }
        }

        public override void Add(TBase obj)
        {
            if(_variable != null && !_useConstant)
                _variable.Add(obj);
            else
            {
                _constantValue.Add(obj);
                RaiseValueAdded(obj);
                RaiseCollectionUpdated();
            }
        }
        public override void Remove(TBase obj)
        {
            if(_variable != null && !_useConstant)
                _variable.Remove(obj);
            else
            {
                _constantValue.Remove(obj);
                RaiseValueRemoved(obj);
                RaiseCollectionUpdated();
            }
        }
        public override void Clear()
        {
            if(_variable != null && !_useConstant)
                _variable.Clear();
            else
            {
                _constantValue.Clear();
                RaiseCollectionUpdated();
            }
        }
        public override bool Contains(TBase value)
        {
            if(_variable != null && !_useConstant)
                return _variable.Contains(value);

            return _constantValue.Contains(value);
        }
        public override int IndexOf(TBase value)
        {
            if(_variable != null && !_useConstant)
                return _variable.IndexOf(value);

            return _constantValue.IndexOf(value);
        }
        public override void RemoveAt(int index)
        {
            if(_variable != null && !_useConstant)
                _variable.RemoveAt(index);
            else
            {
                var removedObj = _constantValue[index];
                _constantValue.RemoveAt(index);
                RaiseValueRemoved(removedObj);
                RaiseCollectionUpdated();
            }
        }

        public override void Insert(int index, TBase value)
        {
            if(_variable != null && !_useConstant)
                _variable.Insert(index, value);
            else
            {
                var oldValue = _constantValue[index];
                _constantValue.Insert(index, value);
                RaiseValueAdded(value);
                if(oldValue != null) RaiseValueRemoved(oldValue);
                RaiseCollectionUpdated();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual IEnumerator<TBase> GetEnumerator()
        {
            if(_variable != null && !_useConstant)
                return _variable.GetEnumerator();

            return _constantValue.GetEnumerator();

        }
        public override string ToString()
        {
            return "Collection<" + typeof(TBase) + ">(" + Count + ")";
        }
        public virtual TBase[] ToArray() {
            if(_variable != null && !_useConstant)
                return _variable.ToArray();

            return _constantValue.ToArray();
        }

        #region Events

        public override void RaiseCollectionUpdated()
        {
            if(_variable != null && !_useConstant)
                _variable.RaiseCollectionUpdated();
            else
            {
                base.RaiseCollectionUpdated();
            }
        }

        public override void RaiseValueAdded(TBase value)
        {
            if(_variable != null && !_useConstant)
                _variable.RaiseValueAdded(value);
            else
            {
                base.RaiseValueAdded(value);
            }
        }

        public override void RaiseValueRemoved(TBase value)
        {
            if(_variable != null && !_useConstant)
                _variable.RaiseValueRemoved(value);
            else
            {
                base.RaiseValueRemoved(value);
            }
        }

        public override void AddListenerToItemAdded(IGameEventListener<TBase> listener)
        {
            if(_variable != null && !_useConstant)
                _variable.AddListenerToItemAdded(listener);
            else
                base.AddListenerToItemAdded(listener);
        }

        public override void AddListenerToItemAdded(System.Action<TBase> action)
        {
            if(_variable != null && !_useConstant)
                _variable.AddListenerToItemAdded(action);
            else
                base.AddListenerToItemAdded(action);
        }

        public override void AddListenerToItemRemoved(IGameEventListener<TBase> listener)
        {
            if(_variable != null && !_useConstant)
                _variable.AddListenerToItemRemoved(listener);
            else
                base.AddListenerToItemRemoved(listener);
        }

        public override void AddListenerToItemRemoved(System.Action<TBase> action)
        {
            if(_variable != null && !_useConstant)
                _variable.AddListenerToItemRemoved(action);
            else
                base.AddListenerToItemRemoved(action);
        }

        public override void RemoveListenerToItemAdded(IGameEventListener<TBase> listener)
        {
            if(_variable != null && !_useConstant)
                _variable.RemoveListenerToItemAdded(listener);
            else
                base.RemoveListenerToItemAdded(listener);
        }

        public override void RemoveListenerToItemAdded(System.Action<TBase> action)
        {
            if(_variable != null && !_useConstant)
                _variable.RemoveListenerToItemAdded(action);
            else
                base.RemoveListenerToItemAdded(action);
        }

        public override void RemoveListenerToItemRemoved(IGameEventListener<TBase> listener)
        {
            if(_variable != null && !_useConstant)
                _variable.RemoveListenerToItemRemoved(listener);
            else
                base.RemoveListenerToItemRemoved(listener);
        }

        public override void RemoveListenerToItemRemoved(System.Action<TBase> action)
        {
            if(_variable != null && !_useConstant)
                _variable.RemoveListenerToItemRemoved(action);
            else
                base.RemoveListenerToItemRemoved(action);
        }

        public override void AddListenerToCollectionUpdated(IGameEventListener listener)
        {
            if(_variable != null && !_useConstant)
                _variable.AddListenerToCollectionUpdated(listener);
            else
                base.AddListenerToCollectionUpdated(listener);
        }

        public override void AddListenerToCollectionUpdated(System.Action action)
        {
            if(_variable != null && !_useConstant)
                _variable.AddListenerToCollectionUpdated(action);
            else
                base.AddListenerToCollectionUpdated(action);
        }

        public override void RemoveListenerToCollectionUpdated(IGameEventListener listener)
        {
            if(_variable != null && !_useConstant)
                _variable.RemoveListenerToCollectionUpdated(listener);
            else
                base.RemoveListenerToCollectionUpdated(listener);
        }

        public override void RemoveListenerToCollectionUpdated(System.Action action)
        {
            if(_variable != null && !_useConstant)
                _variable.RemoveListenerToCollectionUpdated(action);
            else
                base.RemoveListenerToCollectionUpdated(action);
        }

        public override void RemoveAllListeners()
        {
            if(_variable != null && !_useConstant)
                _variable.RemoveAllListeners();
            else
                base.RemoveAllListeners();
        }

        #endregion
    }
    public abstract class BaseCollectionReference<T> : CollectionEventCustom<T>, IEnumerable
    {
        public object this[int index]
        {
            get
            {
                return List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        public int Count { get { return List.Count; } }

        public abstract IList List { get; }
        public abstract Type Type { get; }
        public abstract void Add(T obj);
        public abstract void Remove(T obj);
        public abstract void Clear();
        public abstract bool Contains(T value);
        public abstract int IndexOf(T value);
        public abstract void RemoveAt(int index);
        public abstract void Insert(int index, T value);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }

        public bool Contains(object obj)
        {
            return List.Contains(obj);
        }
    }
}