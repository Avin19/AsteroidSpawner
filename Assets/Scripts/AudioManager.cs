using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set;}
    private AudioSource audioSource;
   
    [SerializeField]private AudioClip[] audioClips;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void HitAsteroid()
    {
        audioSource.PlayOneShot(audioClips[0]);
    }
    public void Emergency()
    {
        audioSource.clip = audioClips[1];
    }

   
}
