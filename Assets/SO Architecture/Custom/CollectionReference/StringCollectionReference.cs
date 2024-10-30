using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class StringCollectionReference : BaseCollectionReference<string, StringCollection>
	{
	    public StringCollectionReference() : base() { }
	    public StringCollectionReference(List<string> value) : base(value) { }
	}
}