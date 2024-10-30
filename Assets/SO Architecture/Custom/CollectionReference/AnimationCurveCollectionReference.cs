using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class AnimationCurveCollectionReference : BaseCollectionReference<AnimationCurve, AnimationCurveCollection>
	{
	    public AnimationCurveCollectionReference() : base() { }
	    public AnimationCurveCollectionReference(List<AnimationCurve> value) : base(value) { }
	}
}