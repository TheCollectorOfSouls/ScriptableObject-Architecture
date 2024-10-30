using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class LongLocalCollectionReference : BaseLocalCollectionReference<long, LongCollection>
	{
	    public LongLocalCollectionReference() : base() { }
	    public LongLocalCollectionReference(List<long> value) : base(value) { }
	}
}