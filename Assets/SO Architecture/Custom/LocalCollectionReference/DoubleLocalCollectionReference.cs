using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class DoubleLocalCollectionReference : BaseLocalCollectionReference<double, DoubleCollection>
	{
	    public DoubleLocalCollectionReference() : base() { }
	    public DoubleLocalCollectionReference(List<double> value) : base(value) { }
	}
}