using UnityEngine;

public class Coin : MonoBehaviour
{   
    private void Update() {
        if(Mathf.Abs(transform.position.x) >=9f || Mathf.Abs(transform.position.y) >= 7f)
    
        {
            OnBecameInvisible();
        }
    }
   
   private void OnCollisionEnter(Collision other) {
    if(other.gameObject.tag == "Player")
    {
        Debug.Log( "Coin Collected");
       GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().coinadd();
        Destroy(gameObject);
    }
   }
   private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
