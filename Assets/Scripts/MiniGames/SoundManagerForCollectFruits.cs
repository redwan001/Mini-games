using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerForCollectFruits : MonoBehaviour
{
    public static SoundManagerForCollectFruits instance;
    public AudioClip fruitDropSound;
    public AudioClip FruitCollectSound;
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

    public static SoundManagerForCollectFruits sharedManager()
    {
        return instance;
    }

    // Update is called once per frame
    public void PlayFruitDropFX()
    {
        audio.clip = fruitDropSound;
        audio.Play();
    }

    public void PlayFruitCollectFX()
    {
        audio.clip = FruitCollectSound;
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
