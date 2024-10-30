using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ObjectCollectionReference : BaseCollectionReference<Object, ObjectCollection>
	{
	    public ObjectCollectionReference() : base() { }
	    public ObjectCollectionReference(List<Object> value) : base(value) { }
	}
}