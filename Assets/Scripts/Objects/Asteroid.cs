using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{   
    //When the asteroid is out of screen then OnBecameInvisibler Function is called .
    private void Update() {
        if(Mathf.Abs(transform.position.x) >=9f || Mathf.Abs(transform.position.y) >= 7f)
    
        {
            OnBecameInvisible();
        }
    }
    //When the Asteriod hits Player 
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().WhenAsteroidHitPlayer();
            
            OnBecameInvisible();
        }
    }
    private void OnBecameInvisible() {
        //visible effects can be implemented such as particle

        Destroy(gameObject);

    }
}
