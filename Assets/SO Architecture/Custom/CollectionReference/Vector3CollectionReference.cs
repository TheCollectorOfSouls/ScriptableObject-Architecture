using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class Vector3CollectionReference : BaseCollectionReference<Vector3, Vector3Collection>
	{
	    public Vector3CollectionReference() : base() { }
	    public Vector3CollectionReference(List<Vector3> value) : base(value) { }
	}
}