using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class Vector4CollectionReference : BaseCollectionReference<Vector4, Vector4Collection>
	{
	    public Vector4CollectionReference() : base() { }
	    public Vector4CollectionReference(List<Vector4> value) : base(value) { }
	}
}