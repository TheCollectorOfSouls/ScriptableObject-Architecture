using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class QuaternionLocalCollectionReference : BaseLocalCollectionReference<Quaternion, QuaternionCollection>
	{
	    public QuaternionLocalCollectionReference() : base() { }
	    public QuaternionLocalCollectionReference(List<Quaternion> value) : base(value) { }
	}
}