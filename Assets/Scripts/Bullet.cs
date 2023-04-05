using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject Player ;
 
    void Update()
    {
        Debug.Log(Player.transform.position);
        
        
    }
}
