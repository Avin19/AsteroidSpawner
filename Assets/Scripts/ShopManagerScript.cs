using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ShopManagerScript : MonoBehaviour
{
    public int playerShipIndex;
    public int currentShipIndex = 0;

    [SerializeField] private GameObject pfShip;

    public TMP_Text startText, coinText, yourCoin;
    public ShipinformExtractor shipinform;

    void Start()
    {  
        Ship(currentShipIndex);
        yourCoin.text = "Your Coin : " + PlayerPrefs.GetInt("Coin", 0).ToString();

    }
    private void Ship(int index)
    {
        
        pfShip = Instantiate(shipinform.ShipPerfab(index), transform.position, Quaternion.Euler(-90f, 0f, 0f));
        pfShip.transform.localScale = Vector3.one * 0.6f;
        pfShip.SetActive(true);
        pfShip.AddComponent<Rotateship>();
        coinText.text = shipinform.ShipCost(index).ToString();
        if (shipinform.ShipPurchased(index))
        {
            startText.text = "Start";
        }
        else
        {
            startText.text = "Buy";
        }
    }
    
    public void ChangeNext()
    {
        currentShipIndex++;
        Destroy(pfShip);
        if (currentShipIndex >= 9)
        {
            currentShipIndex = 0;

        }
        Ship(currentShipIndex);

    }
    public void ChangePervious()
    {
        currentShipIndex--;
        Destroy(pfShip);
        if (currentShipIndex <= 0)
        {
            currentShipIndex = 8;
        }
        Ship(currentShipIndex);
    }
    public void StartingGame()
    {

        if (startText.text == "Start")
        {
            PlayerPrefs.SetInt("SelectedShip", currentShipIndex);
            SceneManager.LoadScene("Level");
        }
        else
        {
            WhenTheShipBuy();
        }
    }
   
    private void WhenTheShipBuy()
    {

        int coin = PlayerPrefs.GetInt("Coin", 0);
        coin -= shipinform.ShipCost(currentShipIndex);
        if (coin >= 0)
        {
            shipinform.SetShipPurchased(currentShipIndex);

            PlayerPrefs.SetInt("Coin", coin);
            yourCoin.text = "Your Coin : " + coin.ToString();
        }
        else
        {
            
        }
    }

}
