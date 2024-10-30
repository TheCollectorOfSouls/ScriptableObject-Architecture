using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class AudioClipLocalCollectionReference : BaseLocalCollectionReference<AudioClip, AudioClipCollection>
	{
	    public AudioClipLocalCollectionReference() : base() { }
	    public AudioClipLocalCollectionReference(List<AudioClip> value) : base(value) { }
	}
}