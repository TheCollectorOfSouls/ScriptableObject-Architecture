using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ColorCollectionReference : BaseCollectionReference<Color, ColorCollection>
	{
	    public ColorCollectionReference() : base() { }
	    public ColorCollectionReference(List<Color> value) : base(value) { }
	}
}