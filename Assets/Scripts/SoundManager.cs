using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip backgroundSound, meteorCursorHitSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        backgroundSound = Resources.Load<AudioClip>("backgroundSound");
        meteorCursorHitSound = Resources.Load<AudioClip>("meteorCursorHitSound");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "background":
                audioSrc.PlayOneShot(backgroundSound);
                break;
            case "meteorCursorHit":
                audioSrc.PlayOneShot(meteorCursorHitSound);
                break;
            //other sounds goes here
            default:
                break;
        }
    }
}
