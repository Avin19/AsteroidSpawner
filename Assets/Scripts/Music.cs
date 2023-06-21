using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioTheme;

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        audioTheme = GetComponent<AudioSource>();
    }
    public void PlayMusic()
    {
        if(audioTheme.isPlaying) return ;
        audioTheme.Play();
    }
    public void StopMusic()
    {
        audioTheme.Stop();
    }
}

