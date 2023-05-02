
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpwaner : MonoBehaviour
{
    //Store the perfabs of the all the asteriods that can be used in the game 
    [SerializeField] private GameObject[] asteroidPrefabs;
    //Intervial between two asteriods generation
    [SerializeField] private float secondBetweenAsteroids;
    [SerializeField]private Vector2 forceRange;
    [SerializeField]private Transform ship;

    private float timer;
    private Camera mainCamera;
    private void Start() {
        mainCamera =Camera.main;
    }

    private void Update() {
        SpawnAsteroid();
        secondBetweenAsteroids =Random.Range(0.2f,0.3f);
       
    }
    //Randomly spawn asteriods in the scenes
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
