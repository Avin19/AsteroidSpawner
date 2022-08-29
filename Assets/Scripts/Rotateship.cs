using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateship : MonoBehaviour
{
    public float zangle=50f;
    
    void Update()
    {
        transform.Rotate(0f,zangle* Time.deltaTime,0f);
    }
}
