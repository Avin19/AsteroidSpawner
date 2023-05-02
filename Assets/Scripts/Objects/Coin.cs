using UnityEngine;

public class Coin : Asteroid
{   
  
   private void OnCollisionEnter(Collision other) {
    if(other.gameObject.tag == "Player")
    {
        Debug.Log( "Coin Collected");
       GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().coinadd();
        Destroy(gameObject);
    }
   }
   
}
