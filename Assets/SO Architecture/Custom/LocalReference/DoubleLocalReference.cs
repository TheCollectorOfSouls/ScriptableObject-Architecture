using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class DoubleLocalReference : BaseLocalReference<double, DoubleVariable>
	{
	    public DoubleLocalReference() : base() { }
	    public DoubleLocalReference(double value) : base(value) { }

        protected override double ClampValue(double value)
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