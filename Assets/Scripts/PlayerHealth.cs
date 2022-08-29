using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameOverHandler gameOverHandler;
    [SerializeField] private Animator mainCameraAnim;
    public  float currentHealth=100f;
    private float maxHealth=100f;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    [SerializeField] GameObject redFlash;
     private void Start() {
       
       slider.maxValue = maxHealth;
       fill.color =gradient.Evaluate(1f);
      

    }
   private void Update() {
        slider.value =currentHealth;
       
    }
    void StartRedFlash()
    {
        if( currentHealth <= 20f)
        {   redFlash.SetActive(true);
            Invoke(nameof(Flash),0.5f);
        }
    }
    public void WhenAsteroidHitPlayer()
    {
        float damage = 5f;
        currentHealth -=damage;
        mainCameraAnim.SetBool("shake",true);
        Invoke(nameof(SetBoolValueToFalse), 1f);
        fill.color = gradient.Evaluate(slider.normalizedValue);
        StartRedFlash();
        if(currentHealth <= 0f)
        {
            Crash();
        }
    }
// red flash low health 
    private void Flash()
    {
        redFlash.SetActive(false);
         Invoke(nameof(StartRedFlash),0.5f);
    }

    // Shaking of the camera screen 
    private void SetBoolValueToFalse()
    {
         mainCameraAnim.SetBool("shake",false);
    }
// Game Over 
    public void Crash()
    {   gameOverHandler.EndGame();
        gameObject.SetActive(false);
    }
    // watch ad to get to play again
    public void Alive(){
        gameObject.SetActive(true);
    }
}
