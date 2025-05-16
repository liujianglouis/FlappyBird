using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager Instance;

    public SoundData soundData; // ÍÏÈëÄãµÄ ScriptableObject
    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }

    public void PlayDie() => PlaySound(soundData.dieClip);
    public void PlayHit() => PlaySound(soundData.hitClip);
    public void Playscore() => PlaySound(soundData.scoreClip);
    public void PlayJump() => PlaySound(soundData.jumpClip);
}