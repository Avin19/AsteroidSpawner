using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipList", menuName = "ShipList")]
public class ShipList : ScriptableObject
{
    public List<Ship> Ships = new List<Ship>();
}
