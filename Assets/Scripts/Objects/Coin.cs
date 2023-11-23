using UnityEngine;

public class Coin : Spawner
{   
  
   
   private void OnCollisionEnter(Collision other) {
    if(other.gameObject.tag == "Player")
    {
        
       GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().coinadd();
        AudioManager.Instance.CoinCollected();
        Destroy(gameObject);
       
    }
   }
   private void Start() {
      ObjectSpawner();
   }
   private void Update() {
      
   }
   
}
