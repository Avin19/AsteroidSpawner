using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGO : MonoBehaviour
{   private float rotateSpeed =200;
   
   
    // Update is called once per frame
    void Update()
    {
       transform.Rotate(0f,rotateSpeed* Time.deltaTime,0f,Space.Self);
    }
}
