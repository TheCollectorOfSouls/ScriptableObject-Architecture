using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class Color32LocalCollectionReference : BaseLocalCollectionReference<Color32, Color32Collection>
	{
	    public Color32LocalCollectionReference() : base() { }
	    public Color32LocalCollectionReference(List<Color32> value) : base(value) { }
	}
}