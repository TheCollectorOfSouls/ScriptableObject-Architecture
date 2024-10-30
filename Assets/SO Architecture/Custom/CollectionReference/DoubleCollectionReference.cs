using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class DoubleCollectionReference : BaseCollectionReference<double, DoubleCollection>
	{
	    public DoubleCollectionReference() : base() { }
	    public DoubleCollectionReference(List<double> value) : base(value) { }
	}
}