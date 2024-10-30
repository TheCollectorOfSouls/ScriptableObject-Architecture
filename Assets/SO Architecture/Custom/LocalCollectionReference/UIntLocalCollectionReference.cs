using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class UIntLocalCollectionReference : BaseLocalCollectionReference<uint, UIntCollection>
	{
	    public UIntLocalCollectionReference() : base() { }
	    public UIntLocalCollectionReference(List<uint> value) : base(value) { }
	}
}