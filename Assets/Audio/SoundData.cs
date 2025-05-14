using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundData", menuName = "Audio/SoundData")]
public class SoundData : ScriptableObject
{
    public AudioClip dieClip;
    public AudioClip hitClip;
    public AudioClip scoreClip;
    public AudioClip jumpClip;
}
