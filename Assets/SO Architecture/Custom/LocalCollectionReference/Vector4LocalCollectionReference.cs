using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class Vector4LocalCollectionReference : BaseLocalCollectionReference<Vector4, Vector4Collection>
	{
	    public Vector4LocalCollectionReference() : base() { }
	    public Vector4LocalCollectionReference(List<Vector4> value) : base(value) { }
	}
}