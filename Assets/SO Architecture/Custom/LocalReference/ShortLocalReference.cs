using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ShortLocalReference : BaseLocalReference<short, ShortVariable>
	{
	    public ShortLocalReference() : base() { }
	    public ShortLocalReference(short value) : base(value) { }
        protected override short ClampValue(short value)
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