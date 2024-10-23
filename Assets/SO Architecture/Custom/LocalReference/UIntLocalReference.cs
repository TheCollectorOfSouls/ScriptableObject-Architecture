using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class UIntLocalReference : BaseLocalReference<uint, UIntVariable>
	{
	    public UIntLocalReference() : base() { }
	    public UIntLocalReference(uint value) : base(value) { }
        protected override uint ClampValue(uint value)
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