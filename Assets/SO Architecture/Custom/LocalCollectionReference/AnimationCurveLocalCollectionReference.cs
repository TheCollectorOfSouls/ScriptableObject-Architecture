using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class AnimationCurveLocalCollectionReference : BaseLocalCollectionReference<AnimationCurve, AnimationCurveCollection>
	{
	    public AnimationCurveLocalCollectionReference() : base() { }
	    public AnimationCurveLocalCollectionReference(List<AnimationCurve> value) : base(value) { }
	}
}