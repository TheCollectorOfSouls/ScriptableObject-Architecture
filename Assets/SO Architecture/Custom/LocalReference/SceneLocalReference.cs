using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class SceneLocalReference : BaseLocalReference<SceneInfo, SceneVariable>
	{
	    public SceneLocalReference() : base() { }
	    public SceneLocalReference(SceneInfo value) : base(value) { }

        /// <summary>
        /// Returns the <see cref="SceneInfo"/> of this instance.
        /// </summary>
        public override SceneInfo Value => _useConstant || _variable == null ? _constantValue : _variable.Value;
    }
}