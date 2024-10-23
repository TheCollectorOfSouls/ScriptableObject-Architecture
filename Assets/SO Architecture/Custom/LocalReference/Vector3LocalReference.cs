using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class Vector3LocalReference : BaseLocalReference<Vector3, Vector3Variable>
	{
	    public Vector3LocalReference() : base() { }
	    public Vector3LocalReference(Vector3 value) : base(value) { }
	}
}