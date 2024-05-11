using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ShipSO", menuName = "AsteroidSpawner/ShipSO", order = 0)]
public class Ship : ScriptableObject
{
    public string shipName;
    public GameObject pfship;
    public int shipPurchaseCost;
    public int shipHealth;
    public bool isPurchased = false;


}
