using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class BoolLocalCollectionReference : BaseLocalCollectionReference<bool, BoolCollection>
	{
	    public BoolLocalCollectionReference() : base() { }
	    public BoolLocalCollectionReference(List<bool> value) : base(value) { }
	}
}