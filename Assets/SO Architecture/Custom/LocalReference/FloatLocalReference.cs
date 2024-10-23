using System;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [Serializable]
    public sealed class FloatLocalReference : BaseLocalReference<float, FloatVariable>
    {
        public FloatLocalReference() : base() { }
        public FloatLocalReference(float value) : base(value) { }

        protected override float ClampValue(float value)
        {
            if (value.CompareTo(MinClampValue) < 0)
            {
                return MinClampValue;
            }
            else if (value.CompareTo(MaxClampValue) > 0)
            {
                return MaxClampValue;
            }
            else
            {
                return value;
            }
        }
        protected override bool AreValuesEqual(float a, float b)
        {
            return Mathf.Abs(a - b) < Mathf.Epsilon;
        }
    }
}