using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class SceneCollectionReference : BaseCollectionReference<SceneInfo, SceneCollection>
	{
	    public SceneCollectionReference() : base() { }
	    public SceneCollectionReference(List<SceneInfo> value) : base(value) { }
	}
}