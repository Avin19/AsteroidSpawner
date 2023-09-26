using UnityEngine;


public class Asteroid : MonoBehaviour
{   
  
    [SerializeField] private GameObject pfParticleSystem;
    
    //When the asteroid is out of screen then OnBecameInvisibler Function is called .
    private void Update() {
        

        if(Mathf.Abs(transform.position.x) >=9f || Mathf.Abs(transform.position.y) >= 7f)
    
        {
             Destroy(gameObject);
        }
    }
    //When the Asteriod hits Player 
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Player")
        {
            AudioManager.Instance.HitAsteroid();
            Transform partice = Instantiate(pfParticleSystem,transform.position,Quaternion.identity).transform;
            partice.GetComponent<ParticleSystem>().Play();
             Destroy(gameObject);
        }
        if(other.gameObject.tag == "Bullet")
        {
            
        }
        
    }
    
    
}
