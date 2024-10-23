using UnityEngine;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class AudioClipLocalReference : BaseLocalReference<AudioClip, AudioClipVariable>
	{
	    public AudioClipLocalReference() : base() { }
	    public AudioClipLocalReference(AudioClip value) : base(value) { }
	}
}