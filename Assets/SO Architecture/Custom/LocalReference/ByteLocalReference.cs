using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ByteLocalReference : BaseLocalReference<byte, ByteVariable>
	{
	    public ByteLocalReference() : base() { }
	    public ByteLocalReference(byte value) : base(value) { }

        protected override byte ClampValue(byte value)
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