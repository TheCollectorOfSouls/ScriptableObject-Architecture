using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class Color32LocalReference : BaseLocalReference<Color32, Color32Variable>
	{
	    public Color32LocalReference() : base() { }
	    public Color32LocalReference(Color32 value) : base(value) { }
	}
}