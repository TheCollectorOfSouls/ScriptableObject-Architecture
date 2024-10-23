using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class CharLocalReference : BaseLocalReference<char, CharVariable>
	{
	    public CharLocalReference() : base() { }
	    public CharLocalReference(char value) : base(value) { }
	}
}