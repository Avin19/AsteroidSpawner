using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private Transform Ship;
    [SerializeField] private GameObject trail;
    

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
       
        if(Input.GetMouseButton(0))
        {
             Vector3 dir = (mainCamera.ScreenToWorldPoint(Input.mousePosition) - Ship.position).normalized;
            Transform  bullet = Instantiate(trail,Ship.position,Quaternion.identity).transform;
            bullet.position += dir*20f*Time.deltaTime;

        }
    }
}
