using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameOverHandler gameOverHandler;
    public  float currentHealth=100f;
    private float maxHealth=100f;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
     private void Start() {
       
       slider.maxValue = maxHealth;
       fill.color =gradient.Evaluate(1f);
       

    }
   private void Update() {
        slider.value =currentHealth;
       
    }
    public void WhenAsteroidHitPlayer()
    {
        float damage = 20f;
        currentHealth -=damage;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if(currentHealth < 0f)
        {
            Crash();
        }
    }
    public void Crash()
    {   gameOverHandler.EndGame();
        gameObject.SetActive(false);
    }
    public void Alive(){
        gameObject.SetActive(true);
    }
}
