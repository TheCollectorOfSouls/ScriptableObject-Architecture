using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class IntLocalReference : BaseLocalReference<int, IntVariable>
	{
	    public IntLocalReference() : base() { }
	    public IntLocalReference(int value) : base(value) { }
        protected override int ClampValue(int value)
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