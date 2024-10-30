using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ULongCollectionReference : BaseCollectionReference<ulong, ULongCollection>
	{
	    public ULongCollectionReference() : base() { }
	    public ULongCollectionReference(List<ulong> value) : base(value) { }
	}
}