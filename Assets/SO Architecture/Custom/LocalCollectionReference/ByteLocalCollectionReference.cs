using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ByteLocalCollectionReference : BaseLocalCollectionReference<byte, ByteCollection>
	{
	    public ByteLocalCollectionReference() : base() { }
	    public ByteLocalCollectionReference(List<byte> value) : base(value) { }
	}
}