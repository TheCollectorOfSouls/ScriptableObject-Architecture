using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    public sealed class AnimationCurveLocalReference : BaseLocalReference<AnimationCurve, AnimationCurveVariable>
    {
        public AnimationCurveLocalReference() : base() { }
        public AnimationCurveLocalReference(AnimationCurve value) : base(value) { }
    }
}