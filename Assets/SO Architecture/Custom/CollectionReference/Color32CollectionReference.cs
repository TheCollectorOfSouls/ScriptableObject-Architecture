using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class Color32CollectionReference : BaseCollectionReference<Color32, Color32Collection>
	{
	    public Color32CollectionReference() : base() { }
	    public Color32CollectionReference(List<Color32> value) : base(value) { }
	}
}