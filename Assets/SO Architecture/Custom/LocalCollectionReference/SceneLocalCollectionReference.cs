using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class SceneLocalCollectionReference : BaseLocalCollectionReference<SceneInfo, SceneCollection>
	{
	    public SceneLocalCollectionReference() : base() { }
	    public SceneLocalCollectionReference(List<SceneInfo> value) : base(value) { }
	}
}