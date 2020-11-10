using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LaserSound : MonoBehaviour
{
    public AudioSource LaserReadySource;
    public AudioSource LaserSource;

    float ReadyTime = 2f;
    float AttackTime = 7f;

    float PlayTime = 0f;

    void Start()
    {
        PlayTime = 0f;
        Invoke("ReadySound", 0f);
        Invoke("PlaySound", 2f);
    }

    void ReadySound()
    {
        LaserReadySource.Play();
        if(PlayTime >= ReadyTime)
        {
            ReadySound_Stop();
        }
        PlayTime += Time.deltaTime;
    }

    void ReadySound_Stop()
    {
        LaserReadySource.Stop();
    }
    
    void PlaySound()
    {
        if(PlayTime <= 7f && PlayTime >= 2f)
        {
            LaserSource.Play();
        }

        PlayTime += Time.deltaTime;

        if(PlayTime > 7f)
        {
            LaserSource.Stop();
        }
    }
}
