using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private ShipinformExtractor shipinform;

    [Header("UI Object")]
    [SerializeField] private TextMeshProUGUI playerCoin;

    private void Start()
    {
        foreach (Shipinformation ship in shipinform.shipList)
        {
            Debug.Log(ship.name);
        }
    }
}
