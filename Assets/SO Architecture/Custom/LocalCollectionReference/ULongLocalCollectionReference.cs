using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ULongLocalCollectionReference : BaseLocalCollectionReference<ulong, ULongCollection>
	{
	    public ULongLocalCollectionReference() : base() { }
	    public ULongLocalCollectionReference(List<ulong> value) : base(value) { }
	}
}