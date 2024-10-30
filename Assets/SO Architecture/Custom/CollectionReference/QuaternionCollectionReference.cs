using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class QuaternionCollectionReference : BaseCollectionReference<Quaternion, QuaternionCollection>
	{
	    public QuaternionCollectionReference() : base() { }
	    public QuaternionCollectionReference(List<Quaternion> value) : base(value) { }
	}
}