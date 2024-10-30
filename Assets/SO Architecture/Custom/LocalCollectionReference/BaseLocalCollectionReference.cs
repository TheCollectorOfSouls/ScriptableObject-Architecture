using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [Serializable]
    public class BaseLocalCollectionReference<TBase, TVariable> : BaseCollectionReference<TBase>, IEnumerable<TBase>
        where TVariable : Collection<TBase>
    {
        public BaseLocalCollectionReference(){}
        public BaseLocalCollectionReference(List<TBase> baseValue)
        {
            _useConstant = true;
            _constantValue = new List<TBase>(baseValue);
        }

        [SerializeField] protected bool _useConstant = false;
        [SerializeField] protected List<TBase> _constantValue = new List<TBase>();
        [SerializeField] protected TVariable _variable;
        private bool _valueSet = false;

        public virtual TVariable Variable
        {
            get => _variable;
            set
            {
                _useConstant = false;
                _variable = value;
                InitializeLocalValue();
                RaiseCollectionUpdated();
            }
        }

        private void CheckInitialization()
        {
            if(!_valueSet && !_useConstant)
                InitializeLocalValue();
        }

        public void InitializeLocalValue()
        {
            _valueSet = true;
            if(_variable == null) return;

            _constantValue = new List<TBase>(_variable);
        }

        public virtual BaseCollectionReference<TBase> CreateCopy()
        {
            BaseLocalCollectionReference<TBase, TVariable> copy =
                (BaseLocalCollectionReference<TBase, TVariable>)System.Activator.CreateInstance(GetType());
            copy._useConstant = _useConstant;
            copy._constantValue = new List<TBase>(_constantValue);
            copy._variable = _variable;
            copy._valueSet = _valueSet;

            return copy;
        }

        public new virtual TBase this[int index]
        {
            get
            {
                CheckInitialization();
                return _constantValue[index];
            }
            set
            {
                CheckInitialization();

                var oldValue = _constantValue[index];
                _constantValue[index] = value;
                RaiseValueAdded(value);
                if(oldValue != null) RaiseValueRemoved(oldValue);
                RaiseCollectionUpdated();
            }
        }

        public override IList List
        {
            get
            {
                CheckInitialization();
                return _constantValue;
            }
        }

        public override Type Type => typeof(TBase);

        public override void Add(TBase obj)
        {
            CheckInitialization();

            _constantValue.Add(obj);
            RaiseValueAdded(obj);
            RaiseCollectionUpdated();
        }

        public override void Remove(TBase obj)
        {
            CheckInitialization();

            _constantValue.Remove(obj);
            RaiseValueRemoved(obj);
            RaiseCollectionUpdated();
        }

        public override void Clear()
        {
            CheckInitialization();

            _constantValue.Clear();
            RaiseCollectionUpdated();
        }

        public override bool Contains(TBase value)
        {
            CheckInitialization();

            return _constantValue.Contains(value);
        }

        public override int IndexOf(TBase value)
        {
            CheckInitialization();

            return _constantValue.IndexOf(value);
        }

        public override void RemoveAt(int index)
        {
            CheckInitialization();

            var removedObj = _constantValue[index];
            _constantValue.RemoveAt(index);
            RaiseValueRemoved(removedObj);
            RaiseCollectionUpdated();
        }

        public override void Insert(int index, TBase value)
        {
            CheckInitialization();

            var oldValue = _constantValue[index];
            _constantValue.Insert(index, value);
            RaiseValueAdded(value);
            if(oldValue != null) RaiseValueRemoved(oldValue);
            RaiseCollectionUpdated();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual IEnumerator<TBase> GetEnumerator()
        {
            CheckInitialization();

            return _constantValue.GetEnumerator();
        }

        public override string ToString()
        {
            return "Collection<" + typeof(TBase) + ">(" + Count + ")";
        }

        public virtual TBase[] ToArray() {
            CheckInitialization();

            return _constantValue.ToArray();
        }
    }
}