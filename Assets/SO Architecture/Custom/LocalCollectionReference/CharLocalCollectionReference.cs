using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class CharLocalCollectionReference : BaseLocalCollectionReference<char, CharCollection>
	{
	    public CharLocalCollectionReference() : base() { }
	    public CharLocalCollectionReference(List<char> value) : base(value) { }
	}
}