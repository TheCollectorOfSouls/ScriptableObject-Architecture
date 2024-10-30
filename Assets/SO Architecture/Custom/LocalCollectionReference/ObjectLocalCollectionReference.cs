using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ObjectLocalCollectionReference : BaseLocalCollectionReference<Object, ObjectCollection>
	{
	    public ObjectLocalCollectionReference() : base() { }
	    public ObjectLocalCollectionReference(List<Object> value) : base(value) { }
	}
}