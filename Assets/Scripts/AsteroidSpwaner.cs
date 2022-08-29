
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpwaner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
   
    [SerializeField] private float secondBetweenAsteroids = 1f;
    [SerializeField]private Vector2 forceRange;
    [SerializeField]private Transform ship;

    private float timer;
    private Camera mainCamera;
    private void Start() {
        mainCamera =Camera.main;
    }

    private void Update() {
        SpawnAsteroid();
       
    }

    private void SpawnAsteroid()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            int side =Random.Range(0,4);   

            Vector2 spwanPoint = Vector2.zero;
            Vector2 direction = Vector2.zero;

            switch(side)
             {
                 case 0:
                    //left
                        spwanPoint.x=0f;
                        spwanPoint.y = Random.value;
                        direction = new Vector2 (1f, Random.Range(-1f,1f));
                        break;
                    case 1:
                    //right
                    spwanPoint.x=1f;
                        spwanPoint.y=Random.value;
                       direction = new Vector2(-1f , Random.Range(-1f,1f));
                        
                        break;
                    case 2:
                    //bottom
                        spwanPoint.x= Random.value;
                        spwanPoint.y =0f;
                       direction =new Vector2(Random.Range(-1f,1f),1f);

                        break;
                    case 3:
                    //top
                        spwanPoint.x =Random.value;
                        spwanPoint.y =1f;
                       direction = new Vector2(Random.Range(-1f,1f), -1f);
                        break;

                    }
            Vector3 worldSpawn =mainCamera.ViewportToWorldPoint(spwanPoint);
            
            worldSpawn.z =0;
            GameObject asteroidInstance=Instantiate(
            asteroidPrefabs[Random.Range(0,asteroidPrefabs.Length)], 
            worldSpawn , 
            Quaternion.Euler(0f,0f,Random.Range(0f,360f)) );
            Rigidbody rb = asteroidInstance.GetComponent<Rigidbody>();
            rb.velocity = direction.normalized*Random.Range(forceRange.x,forceRange.y);
    
            timer += secondBetweenAsteroids;
        }

    }
}
