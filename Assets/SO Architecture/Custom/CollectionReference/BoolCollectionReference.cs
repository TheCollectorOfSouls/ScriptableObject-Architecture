using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class BoolCollectionReference : BaseCollectionReference<bool, BoolCollection>
	{
	    public BoolCollectionReference() : base() { }
	    public BoolCollectionReference(List<bool> value) : base(value) { }
	}
}