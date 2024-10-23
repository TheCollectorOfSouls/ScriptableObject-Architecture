using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableObjectArchitecture
{
    public partial class BaseReference<TBase, TVariable> : BaseReference where TVariable : BaseVariable<TBase>
    {
        protected TBase _oldConstantValue;
        protected readonly List<Action> _actions = new List<Action>();
        protected readonly List<IGameEventListener> _listeners = new List<IGameEventListener>();

        public virtual TBase Value
        {
            get => _useConstant || _variable == null ? _constantValue : _variable.Value;
            set
            {
                if (!_useConstant && _variable != null)
                {
                    _variable.Value = value;
                }
                else
                {
                    _useConstant = true;
                    _constantValue = SetValue(value);
                }
            }
        }

        public virtual TBase SetValue(BaseVariable<TBase> value)
        {
            return SetValue(value.Value);
        }

        public virtual TBase SetValue(TBase newValue)
        {
            _oldConstantValue = _constantValue;

            _constantValue = newValue;

            if (!AreValuesEqual(newValue, _oldConstantValue))
                Raise();

            return newValue;
        }

        protected virtual bool AreValuesEqual(TBase a, TBase b)
        {
            if (a != null) return a.Equals(b);

            return b == null;
        }

        public virtual void Raise()
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventRaised();

            for (int i = _actions.Count - 1; i >= 0; i--)
                _actions[i]();
        }

        public virtual void AddListener(IGameEventListener listener)
        {
            if (_variable != null && !_useConstant)
                _variable.AddListener(listener);
            else
            {
                if (!_listeners.Contains(listener))
                    _listeners.Add(listener);
            }
        }

        public virtual void RemoveListener(IGameEventListener listener)
        {
            if (_variable != null && !_useConstant)
                _variable.RemoveListener(listener);
            else
            {
                if (_listeners.Contains(listener))
                    _listeners.Remove(listener);
            }
        }

        public virtual void AddListener(Action action)
        {
            if (_variable != null && !_useConstant)
                _variable.AddListener(action);
            else
            {
                if(!_actions.Contains(action))
                    _actions.Add(action);
            }
        }

        public virtual void RemoveListener(Action action)
        {
            if (_variable != null && !_useConstant)
                _variable.RemoveListener(action);
            else
            {
                if(_actions.Contains(action))
                    _actions.Remove(action);
            }
        }

        public virtual void RemoveAll()
        {
            _listeners.RemoveRange(0, _listeners.Count);
            _actions.RemoveRange(0, _actions.Count);
        }
    }

    public class BaseLocalReference<TBase, TVariable> : BaseReference<TBase, TVariable> where TVariable : BaseVariable<TBase>
    {
        private bool _valueSet = false;
        private bool _readOnly = false;
        private bool _isClamped;
        private TBase _minClampValue;
        private TBase _maxClampValue;

        protected virtual TBase MinClampValue => _minClampValue;
        protected virtual TBase MaxClampValue => _maxClampValue;
        public bool RaiseWarning { get; set; } = false;

        public BaseLocalReference() : base() {}
        public BaseLocalReference(TBase baseValue) : base(baseValue) { }

        public void InitializeLocalValue()
        {
            _valueSet = true;

            if (_variable == null) return;

            _constantValue = _variable.Value;
            _readOnly = _variable.ReadOnly;
            _isClamped = _variable.IsClamped;

            if (!_isClamped) return;
            _minClampValue = _variable.MinClampValue;
            _maxClampValue = _variable.MaxClampValue;
        }


        public override TBase Value
        {
            get
            {
                if(!_valueSet)
                    InitializeLocalValue();
                return _constantValue;
            }
            set
            {
                if(!_valueSet)
                    InitializeLocalValue();

                _constantValue = SetValue(value);
            }
        }

        public override TBase SetValue(TBase newValue)
        {
            if (_readOnly)
            {
                return _constantValue;
            }

            if(_isClamped)
            {
                newValue = ClampValue(newValue);
            }

            _constantValue = newValue;

            if (!AreValuesEqual(newValue, _oldConstantValue))
                Raise();

            _oldConstantValue = _constantValue;

            return newValue;
        }

        protected virtual TBase ClampValue(TBase value)
        {
            return value;
        }

        private void RaiseReadonlyWarning()
        {
            if (!_readOnly || !RaiseWarning)
                return;

            Debug.LogWarning("Tried to set value on local reference of " + typeof(TVariable) +
                             ", but value is readonly!");
        }

        public override void AddListener(IGameEventListener listener)
        {
            if(!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        public override void RemoveListener(IGameEventListener listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }

        public override void AddListener(Action action)
        {
            if(!_actions.Contains(action))
                _actions.Add(action);
        }

        public override void RemoveListener(Action action)
        {
                if(_actions.Contains(action))
                    _actions.Remove(action);
        }
    }
}