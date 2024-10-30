using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class StringLocalCollectionReference : BaseLocalCollectionReference<string, StringCollection>
	{
	    public StringLocalCollectionReference() : base() { }
	    public StringLocalCollectionReference(List<string> value) : base(value) { }
	}
}