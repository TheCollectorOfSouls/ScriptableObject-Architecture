using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class BoolLocalReference : BaseLocalReference<bool, BoolVariable>
	{
	    public BoolLocalReference() : base() { }
	    public BoolLocalReference(bool value) : base(value) { }
	}
}