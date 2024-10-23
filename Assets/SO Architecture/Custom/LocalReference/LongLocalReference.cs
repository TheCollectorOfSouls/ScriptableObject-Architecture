using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class LongLocalReference : BaseLocalReference<long, LongVariable>
	{
	    public LongLocalReference() : base() { }
	    public LongLocalReference(long value) : base(value) { }
        protected override long ClampValue(long value)
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