using UnityEngine;

public class Coin : Asteroid
{   
  
   private void OnCollisionEnter(Collision other) {
    if(other.gameObject.tag == "Player")
    {
        
       GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().coinadd();
        Destroy(gameObject);
        AudioManager.Instance.CoinCollected();
    }
   }
   
}
