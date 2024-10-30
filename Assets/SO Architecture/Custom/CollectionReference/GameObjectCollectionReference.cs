using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class GameObjectCollectionReference : BaseCollectionReference<GameObject, GameObjectCollection>
	{
	    public GameObjectCollectionReference() : base() { }
	    public GameObjectCollectionReference(List<GameObject> value) : base(value) { }
	}
}