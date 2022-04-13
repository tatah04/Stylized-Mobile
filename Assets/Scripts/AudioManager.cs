using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioSource bgmSource;
    public List<AudioClip> audioClips = new List<AudioClip>();
    public bool isBGM;
    [Range(0.0f, 1.0f)]
    public float bgmVolume;
    public bool isSFX;
    [Range(0.0f, 1.0f)]
    public float sfxVolume;

    private void Start()
    {
        sfxSource.volume = sfxVolume;
        bgmSource.volume = bgmVolume;
    }
    public void toggleBGM()
    {
        isBGM = !isBGM;

        if (isBGM == true)
        {
            bgmSource.mute = false;
        }
        else
        {
            bgmSource.mute = true;
        }
    }

    public void toggleSFX()
    {
        isSFX = !isSFX;
        if (isSFX==true)
        {
            sfxSource.mute = false;
        }
        else
        {
            sfxSource.mute = true;
        }
    }

    public void playSFX(int caseUse)
    {
        sfxSource.Stop();
        sfxSource.clip = audioClips[caseUse];
        sfxSource.Play();
    }
}
