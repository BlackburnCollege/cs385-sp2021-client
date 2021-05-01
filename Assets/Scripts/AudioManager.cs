using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static private AudioSource audioManager;
    // Start is called before the first frame update
    void Start()
    {
        if(audioManager == null)
        {
            audioManager = this.GetComponent<AudioSource>();
        }
    }

    public static void PlaySong(AudioClip clip)
    {
        if(audioManager.clip == null)
        {
            audioManager.clip = clip;
            audioManager.Play();
            return;
        }
        if (audioManager.clip != clip)
        {
            audioManager.clip = clip;
            audioManager.Play();
        }
    }
}
