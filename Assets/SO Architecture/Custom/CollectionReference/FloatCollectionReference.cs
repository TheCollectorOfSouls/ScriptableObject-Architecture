using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class FloatCollectionReference : BaseCollectionReference<float, FloatCollection>
	{
	    public FloatCollectionReference() : base() { }
	    public FloatCollectionReference(List<float> value) : base(value) { }
	}
}