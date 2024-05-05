using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Shipinformation", menuName = "AsteroidSpawner/Shipinfo", order = 1)]
public class ShipinformExtractor : ScriptableObject
{
     public Shipinformation[] shipinforms;

     public List<Shipinformation> shipList;



     public string ShipName(int index)
     {
          return shipinforms[index].name;
     }
     public GameObject ShipPerfab(int index)
     {
          return shipinforms[index].pfship;
     }
     public int ShipHealth(int index)
     {
          return shipinforms[index].shipHealth;
     }
     public int ShipCost(int index)
     {
          return shipinforms[index].shipPurchaseCost;
     }
     public bool ShipPurchased(int index)
     {
          return shipinforms[index].isPurchased;
     }
     public void SetShipPurchased(int index)
     {
          shipinforms[index].isPurchased = true;
     }

}
