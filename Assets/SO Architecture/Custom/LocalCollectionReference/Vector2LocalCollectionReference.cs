using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class Vector2LocalCollectionReference : BaseLocalCollectionReference<Vector2, Vector2Collection>
	{
	    public Vector2LocalCollectionReference() : base() { }
	    public Vector2LocalCollectionReference(List<Vector2> value) : base(value) { }
	}
}