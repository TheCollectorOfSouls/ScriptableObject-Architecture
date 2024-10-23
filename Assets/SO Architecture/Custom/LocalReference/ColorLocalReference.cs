using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ColorLocalReference : BaseLocalReference<Color, ColorVariable>
	{
	    public ColorLocalReference() : base() { }
	    public ColorLocalReference(Color value) : base(value) { }
	}
}