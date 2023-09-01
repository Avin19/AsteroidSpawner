using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Shipinformation", menuName = "AsteroidSpawner/Shipinformation", order = 0)]
public class Shipinformation : ScriptableObject {
    
public Transform pfship;
public int shipPurchaseCost;
 public int shipHealth;

}
