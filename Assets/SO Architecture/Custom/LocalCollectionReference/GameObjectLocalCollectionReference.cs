using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class GameObjectLocalCollectionReference : BaseLocalCollectionReference<GameObject, GameObjectCollection>
	{
	    public GameObjectLocalCollectionReference() : base() { }
	    public GameObjectLocalCollectionReference(List<GameObject> value) : base(value) { }
	}
}