using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class SByteLocalReference : BaseLocalReference<sbyte, SByteVariable>
	{
	    public SByteLocalReference() : base() { }
	    public SByteLocalReference(sbyte value) : base(value) { }
        protected override sbyte ClampValue(sbyte value)
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
	}
}