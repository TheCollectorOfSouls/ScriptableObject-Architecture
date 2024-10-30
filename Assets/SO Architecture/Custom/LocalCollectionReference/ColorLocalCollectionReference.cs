using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ColorLocalCollectionReference : BaseLocalCollectionReference<Color, ColorCollection>
	{
	    public ColorLocalCollectionReference() : base() { }
	    public ColorLocalCollectionReference(List<Color> value) : base(value) { }
	}
}