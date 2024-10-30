using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class UIntCollectionReference : BaseCollectionReference<uint, UIntCollection>
	{
	    public UIntCollectionReference() : base() { }
	    public UIntCollectionReference(List<uint> value) : base(value) { }
	}
}