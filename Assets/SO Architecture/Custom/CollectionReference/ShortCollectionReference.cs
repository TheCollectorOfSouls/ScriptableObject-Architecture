using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ShortCollectionReference : BaseCollectionReference<short, ShortCollection>
	{
	    public ShortCollectionReference() : base() { }
	    public ShortCollectionReference(List<short> value) : base(value) { }
	}
}