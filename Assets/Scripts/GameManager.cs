using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    private float health;
    [SerializeField] private GameObject redFlash;
    private bool check = true;
    private void Update()
    {
        health = playerHealth.GetHealth();
        if(health <= 20f)
        {
            redFlash.SetActive(true);
            Invoke(nameof(Flash), 0.5f);
            if (check)
            {
                check = false;
                AudioManager.Instance.Emergency();
            }
        }
    }
     private void Flash()
    {
        redFlash.SetActive(false);
      
    }
}
