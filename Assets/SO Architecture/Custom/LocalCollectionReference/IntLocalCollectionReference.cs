using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class IntLocalCollectionReference : BaseLocalCollectionReference<int, IntCollection>
	{
	    public IntLocalCollectionReference() : base() { }
	    public IntLocalCollectionReference(List<int> value) : base(value) { }
	}
}