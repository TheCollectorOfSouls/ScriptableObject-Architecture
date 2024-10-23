using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class UShortLocalReference : BaseLocalReference<ushort, UShortVariable>
	{
	    public UShortLocalReference() : base() { }
	    public UShortLocalReference(ushort value) : base(value) { }
        protected override ushort ClampValue(ushort value)
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