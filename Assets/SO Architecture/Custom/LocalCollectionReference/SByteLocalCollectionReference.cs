using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class SByteLocalCollectionReference : BaseLocalCollectionReference<sbyte, SByteCollection>
	{
	    public SByteLocalCollectionReference() : base() { }
	    public SByteLocalCollectionReference(List<sbyte> value) : base(value) { }
	}
}