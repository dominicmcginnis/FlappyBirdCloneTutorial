using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public AudioClip dingSound;
    public AudioClip wingFlapSound;
    private AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "ding":
                audioSrc.PlayOneShot(dingSound);
                break;
            case "wingFlap":
                audioSrc.PlayOneShot(wingFlapSound);
                break;

        }
    }
}
