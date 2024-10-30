using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class UShortCollectionReference : BaseCollectionReference<ushort, UShortCollection>
	{
	    public UShortCollectionReference() : base() { }
	    public UShortCollectionReference(List<ushort> value) : base(value) { }
	}
}