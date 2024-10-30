using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class CharCollectionReference : BaseCollectionReference<char, CharCollection>
	{
	    public CharCollectionReference() : base() { }
	    public CharCollectionReference(List<char> value) : base(value) { }
	}
}