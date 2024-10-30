using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableObjectArchitecture
{
    public partial class BaseReference<TBase, TVariable> : BaseReference where TVariable : BaseVariable<TBase>
    {
        protected TBase _oldConstantValue;

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

        public virtual BaseReference CreateCopy()
        {
            BaseReference<TBase, TVariable> copy = (BaseReference<TBase, TVariable>)System.Activator.CreateInstance(GetType());
            copy._useConstant = _useConstant;
            copy._constantValue = _constantValue;
            copy._variable = _variable;

            return copy;
        }

        protected virtual bool AreValuesEqual(TBase a, TBase b)
        {
            if (a != null) return a.Equals(b);

            return b == null;
        }

        public override void AddListener(IGameEventListener listener)
        {
            if (_variable != null && !_useConstant)
            {
                _variable.AddListener(listener);
            }
            else
            {
                base.AddListener(listener);
            }
        }

        public override void RemoveListener(IGameEventListener listener)
        {
            if (_variable != null && !_useConstant)
                _variable.RemoveListener(listener);
            else
            {
                base.RemoveListener(listener);
            }
        }

        public override void AddListener(Action action)
        {
            if (_variable != null && !_useConstant)
                _variable.AddListener(action);
            else
            {
                base.AddListener(action);
            }
        }

        public override void RemoveListener(Action action)
        {
            if (_variable != null && !_useConstant)
                _variable.RemoveListener(action);
            else
            {
                base.RemoveListener(action);
            }
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

        public BaseLocalReference(TBase baseValue) : base(baseValue)
        {
            _useConstant = true;
            _constantValue = baseValue;
        }

        public void InitializeLocalValue()
        {
            _valueSet = true;

            if (_variable == null)
            {
                _useConstant = true;
                return;
            }

            _constantValue = _variable.Value;
            _readOnly = _variable.ReadOnly;
            _isClamped = _variable.IsClamped;

            if (!_isClamped) return;
            _minClampValue = _variable.MinClampValue;
            _maxClampValue = _variable.MaxClampValue;
        }

        public override BaseReference CreateCopy()
        {
            BaseLocalReference<TBase, TVariable> copy =
                (BaseLocalReference<TBase, TVariable>)System.Activator.CreateInstance(GetType());
            copy._useConstant = _useConstant;
            copy._constantValue = _constantValue;
            copy._variable = _variable;

            return copy;
        }

        public override TVariable Variable
        {
            get => _variable;
            set
            {
                _useConstant = false;
                _variable = value;
                InitializeLocalValue();
            }
        }

        public override TBase Value
        {
            get
            {
                if(!_valueSet && !_useConstant)
                    InitializeLocalValue();
                return _constantValue;
            }
            set
            {
                if(!_valueSet && !_useConstant)
                    InitializeLocalValue();

                _constantValue = SetValue(value);
            }
        }

        public override TBase SetValue(TBase newValue)
        {
            if (_readOnly)
            {
                if(RaiseWarning)
                    RaiseReadonlyWarning();
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