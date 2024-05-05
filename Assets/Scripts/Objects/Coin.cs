using UnityEngine;

public class Coin : AsteroidSpwaner
{   
  
   
   private void OnCollisionEnter(Collision other) {
    if(other.gameObject.tag == "Player")
    {
        
       GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().coinadd();
        AudioManager.Instance.CoinCollected();
        Destroy(gameObject);
       
    }
   }
   
  
   
}
