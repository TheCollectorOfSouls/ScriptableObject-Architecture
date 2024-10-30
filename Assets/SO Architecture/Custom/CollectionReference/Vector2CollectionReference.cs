using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class Vector2CollectionReference : BaseCollectionReference<Vector2, Vector2Collection>
	{
	    public Vector2CollectionReference() : base() { }
	    public Vector2CollectionReference(List<Vector2> value) : base(value) { }
	}
}