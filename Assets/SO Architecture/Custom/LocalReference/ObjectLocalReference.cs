using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ObjectLocalReference : BaseLocalReference<Object, ObjectVariable>
	{
	    public ObjectLocalReference() : base() { }
	    public ObjectLocalReference(Object value) : base(value) { }
	}
}