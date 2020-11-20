using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerForSort : MonoBehaviour
{

    public static SoundManagerForSort instance;
    public AudioClip perfectDropSound;
    public AudioClip imperfectDropSound;
    public AudioClip winFXSound;
    public AudioClip LoseFXSound;
    AudioSource audio;

    // Start is called before the first frame update

    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    void Start()
    {
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    public static SoundManagerForSort sharedManager()
    {
        return instance;
    }

    // Update is called once per frame
    public void PlayPerfectDropFX()
    {
        audio.clip = perfectDropSound;
        audio.Play();
    }

    public void PlayImperfectDropFX()
    {
        audio.clip = imperfectDropSound;
        audio.Play();
    }

    public void PlayWinFX()
    {
        audio.clip = winFXSound;
        audio.Play();
    }

    public void PlayLoseFX()
    {
        audio.clip = LoseFXSound;
        audio.Play();
    }
}
