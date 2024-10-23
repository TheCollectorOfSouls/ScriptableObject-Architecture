using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class GameObjectLocalReference : BaseLocalReference<GameObject, GameObjectVariable>
	{
	    public GameObjectLocalReference() : base() { }
	    public GameObjectLocalReference(GameObject value) : base(value) { }
	}
}