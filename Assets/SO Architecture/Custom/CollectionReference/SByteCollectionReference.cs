using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class SByteCollectionReference : BaseCollectionReference<sbyte, SByteCollection>
	{
	    public SByteCollectionReference() : base() { }
	    public SByteCollectionReference(List<sbyte> value) : base(value) { }
	}
}