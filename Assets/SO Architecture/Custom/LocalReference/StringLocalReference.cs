using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class StringLocalReference : BaseLocalReference<string, StringVariable>
	{
	    public StringLocalReference() : base() { }
	    public StringLocalReference(string value) : base(value) { }
	}
}