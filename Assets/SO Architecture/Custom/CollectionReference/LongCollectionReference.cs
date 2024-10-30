using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class LongCollectionReference : BaseCollectionReference<long, LongCollection>
	{
	    public LongCollectionReference() : base() { }
	    public LongCollectionReference(List<long> value) : base(value) { }
	}
}