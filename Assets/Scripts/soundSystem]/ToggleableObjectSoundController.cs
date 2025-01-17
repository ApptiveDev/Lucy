using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableObjectSoundController : SoundController
{
    private AudioClip[] audioClips = new AudioClip[2];

    protected override void Awake()
    {
        base.Awake();
    }

    public void SetType(string type)
    {
        audioClips[0] = SoundManager.Instance.soundSources.GetByName(type + "Close").Value.sound;
        audioClips[1] = SoundManager.Instance.soundSources.GetByName(type + "Open").Value.sound;
    }

    public void PlaySound(bool isOpen)
    {
        int i = isOpen ? 1 : 0;
        audioSource.clip = audioClips[i];
        audioSource.Play();
    }

}
