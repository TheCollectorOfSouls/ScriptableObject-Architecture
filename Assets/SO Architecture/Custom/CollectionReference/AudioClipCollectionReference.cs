using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class AudioClipCollectionReference : BaseCollectionReference<AudioClip, AudioClipCollection>
	{
	    public AudioClipCollectionReference() : base() { }
	    public AudioClipCollectionReference(List<AudioClip> value) : base(value) { }
	}
}