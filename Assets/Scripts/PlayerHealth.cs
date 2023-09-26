using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private GameOverHandler gameOverHandler;
    [SerializeField] private Animator mainCameraAnim;

    public float currentHealth = 100f;
    private float maxHealth = 100f;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
   
    private void Start()
    {

        slider.maxValue = maxHealth;
        fill.color = gradient.Evaluate(1f);

    }
    private void Update()
    {
        slider.value = currentHealth;
    }
   
   
    public void WhenAsteroidHitPlayer()
    {
        float damage = 5f;
        currentHealth -= damage;
        

        mainCameraAnim.SetBool("shake", true);
        Invoke(nameof(SetBoolValueToFalse), 1f);
        fill.color = gradient.Evaluate(slider.normalizedValue);
      
        if (currentHealth <= 0f)
        {
            gameOverHandler.EndGame();
        }
    }

   
   

    // Shaking of the camera screen 
    private void SetBoolValueToFalse()
    {
        mainCameraAnim.SetBool("shake", false);
    }
    // Game Over 
  
    public float GetHealth()
    {
        return currentHealth;
    }
}
