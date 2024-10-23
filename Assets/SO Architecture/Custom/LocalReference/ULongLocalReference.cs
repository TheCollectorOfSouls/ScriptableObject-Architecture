using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ULongLocalReference : BaseLocalReference<ulong, ULongVariable>
	{
	    public ULongLocalReference() : base() { }
	    public ULongLocalReference(ulong value) : base(value) { }
        protected override ulong ClampValue(ulong value)
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