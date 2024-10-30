using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class Vector3LocalCollectionReference : BaseLocalCollectionReference<Vector3, Vector3Collection>
	{
	    public Vector3LocalCollectionReference() : base() { }
	    public Vector3LocalCollectionReference(List<Vector3> value) : base(value) { }
	}
}