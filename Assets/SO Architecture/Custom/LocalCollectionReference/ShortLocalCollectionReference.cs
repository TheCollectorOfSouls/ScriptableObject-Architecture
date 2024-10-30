using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ShortLocalCollectionReference : BaseLocalCollectionReference<short, ShortCollection>
	{
	    public ShortLocalCollectionReference() : base() { }
	    public ShortLocalCollectionReference(List<short> value) : base(value) { }
	}
}