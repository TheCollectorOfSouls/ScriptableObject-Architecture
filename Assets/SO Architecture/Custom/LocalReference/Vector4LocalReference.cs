using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class Vector4LocalReference : BaseLocalReference<Vector4, Vector4Variable>
	{
	    public Vector4LocalReference() : base() { }
	    public Vector4LocalReference(Vector4 value) : base(value) { }
	}
}