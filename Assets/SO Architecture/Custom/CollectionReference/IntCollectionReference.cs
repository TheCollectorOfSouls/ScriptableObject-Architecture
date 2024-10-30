using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class IntCollectionReference : BaseCollectionReference<int, IntCollection>
	{
	    public IntCollectionReference() : base() { }
	    public IntCollectionReference(List<int> value) : base(value) { }
	}
}