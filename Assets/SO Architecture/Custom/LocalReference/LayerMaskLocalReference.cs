using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class LayerMaskLocalReference : BaseLocalReference<LayerMask, LayerMaskVariable>
	{
	    public LayerMaskLocalReference() : base() { }
	    public LayerMaskLocalReference(LayerMask value) : base(value) { }
	}
}