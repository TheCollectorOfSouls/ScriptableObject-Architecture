using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ByteCollectionReference : BaseCollectionReference<byte, ByteCollection>
	{
	    public ByteCollectionReference() : base() { }
	    public ByteCollectionReference(List<byte> value) : base(value) { }
	}
}