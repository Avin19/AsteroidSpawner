using UnityEngine;


public class Asteroid : Spawner
{   
  
    [SerializeField] private GameObject pfParticleSystem;
    
    private void Start() {
        ObjectSpawner();
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
