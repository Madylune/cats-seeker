using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
            }
            return instance;
        }
    }

    [SerializeField] private AudioSource soundFX;
    [SerializeField] private AudioClip meowClip;

    public void MeowSound()
    {
        soundFX.clip = meowClip;
        soundFX.Play();
    }
}
