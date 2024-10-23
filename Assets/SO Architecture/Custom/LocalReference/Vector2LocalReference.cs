using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class Vector2LocalReference : BaseLocalReference<Vector2, Vector2Variable>
	{
	    public Vector2LocalReference() : base() { }
	    public Vector2LocalReference(Vector2 value) : base(value) { }
	}
}