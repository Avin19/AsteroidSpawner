using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    
    private AudioSource audioTheme;
    [SerializeField]private AudioClip clickAudio;

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
    public void ClickMusic()
    {
        audioTheme.PlayOneShot(clickAudio,0.6f);
    }
}

