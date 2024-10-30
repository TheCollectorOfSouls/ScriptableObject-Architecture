using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class UShortLocalCollectionReference : BaseLocalCollectionReference<ushort, UShortCollection>
	{
	    public UShortLocalCollectionReference() : base() { }
	    public UShortLocalCollectionReference(List<ushort> value) : base(value) { }
	}
}