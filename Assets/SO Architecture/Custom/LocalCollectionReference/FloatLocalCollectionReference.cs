using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class FloatLocalCollectionReference : BaseLocalCollectionReference<float, FloatCollection>
	{
	    public FloatLocalCollectionReference() : base() { }
	    public FloatLocalCollectionReference(List<float> value) : base(value) { }
	}
}