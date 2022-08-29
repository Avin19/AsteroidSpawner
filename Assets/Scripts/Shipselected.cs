using UnityEngine;

public class Shipselected : MonoBehaviour
{
    public GameObject[] Shipholder ;
    int currentplayerShip;
    void Start()
    {
        currentplayerShip = PlayerPrefs.GetInt("SelectedShip",0);
        foreach(GameObject ship in Shipholder)
        {
            ship.SetActive(false);
        }
        Shipholder[currentplayerShip].SetActive(true);
    }

  
}
