using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{   
    private void Update() {
        if(Mathf.Abs(transform.position.x) >=9f || Mathf.Abs(transform.position.y) >= 7f)
    
        {
            OnBecameInvisible();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().WhenAsteroidHitPlayer();
      
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
