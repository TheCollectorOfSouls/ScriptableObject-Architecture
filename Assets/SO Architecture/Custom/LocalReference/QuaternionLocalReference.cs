using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class QuaternionLocalReference : BaseLocalReference<Quaternion, QuaternionVariable>
	{
	    public QuaternionLocalReference() : base() { }
	    public QuaternionLocalReference(Quaternion value) : base(value) { }
	}
}