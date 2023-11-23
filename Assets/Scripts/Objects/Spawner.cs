using System.Runtime.CompilerServices;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;

    }
    protected void ObjectSpawner()
    {   
        int side = Random.Range(0,4);
        Vector2 spwanPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;
         switch(side)
             {
                 case 0:
                    //left
                        spwanPoint.x=-7f;
                        spwanPoint.y = Random.value;
                        direction = new Vector2 (1f, Random.Range(-0.5f,.5f));
                        break;
                    case 1:
                    //right
                    spwanPoint.x=5f;
                        spwanPoint.y=Random.value;
                       direction = new Vector2(-1f , Random.Range(-10f,10f));
                        
                        break;
                    case 2:
                    //bottom
                        spwanPoint.x= Random.value;
                        spwanPoint.y =0f;
                       direction =new Vector2(Random.Range(-2f,2f),2f);

                        break;
                    case 3:
                    //top
                        spwanPoint.x =Random.value;
                        spwanPoint.y =1f;
                       direction = new Vector2(Random.Range(-2f,2f), -2f);
                        break;

                    }
            Vector3 worldSpawn =mainCamera.ViewportToWorldPoint(spwanPoint);
            worldSpawn.z =0;

    }
    private void OutOfScreen()
    {
        
        if(Mathf.Abs(transform.position.x) >=9f || Mathf.Abs(transform.position.y) >= 7f)
    
        {
             Destroy(gameObject);
        }
    }
}