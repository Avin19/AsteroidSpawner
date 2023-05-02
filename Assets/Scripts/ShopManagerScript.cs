using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ShopManagerScript : MonoBehaviour
{
    public int playerShipIndex  ; // Setting the first ship available
    public int currentShipIndex;
    public GameObject[] shipModels;
    public shipblueprint[] ships;
    public TMP_Text startText ,coinText, yourCoin;
    
void Awake()
  {
    for (int i =0 ; i< 9 ; i++)
        {
            //Debug.Log(i);
            shipModels[i]= GameObject.Find("ShipHolder/StarSparrow"+(i+1).ToString());
            
        }
        //Checking which one the player has unclock , if player not unclock any then default first ship will be unclocked 
        playerShipIndex = PlayerPrefs.GetInt("SelectedShip",0);
        //all ship model set to false visible
        foreach (GameObject ship in shipModels)
        {
            ship.SetActive(false);
        }
        //unclock the ship at currentshipindex
        shipModels[playerShipIndex].SetActive(true);
        
  }
void Start()
    {  //getting the player coin
        yourCoin.text= "Your Coin : "+ PlayerPrefs.GetInt("Coin",0).ToString();
        //
        // foreach(shipblueprint ship in ships)
        // {
        //     if( ship.price == 0 )
        //     {
        //         ship.isUnlocked =true;
        //     }
        //     else if(PlayerPrefs.GetInt(ship.name,0)==1)
        //     {
        //         ship.isUnlocked =true;
        //     }
        //     else
        //     {
        //         ship.isUnlocked =false;
        //     }
        // }
       
       
        
    }
    private void Update() {
     UIUpdate();
    }
   public void ChangeNext()
   {   
        shipModels[currentShipIndex].SetActive(false);
        
        currentShipIndex++;
       
        if( currentShipIndex == shipModels.Length)
        {
            currentShipIndex =0;
        }
      
        shipModels[currentShipIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedShip",currentShipIndex);
       
       
   }
   public void ChangePervious()
   {    
        shipModels[currentShipIndex].SetActive(false);    
        if( currentShipIndex <= 0)
        {
            currentShipIndex =shipModels.Length-1;
        }
        else
        {  
            currentShipIndex--;
        }
        
        shipModels[currentShipIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedShip",currentShipIndex);
        
   }
   public void StartingGame()
   {
        
        if(startText.text =="Start"){
            PlayerPrefs.SetInt("SelectedShip",currentShipIndex);
            SceneManager.LoadScene("Level");
        }
        else{
            int coin = PlayerPrefs.GetInt("Coin",0);
            if(coin>=ships[currentShipIndex].price)
            {   // reducing the coin amount     
                coin =coin-ships[currentShipIndex].price;
                // saving the coin update amount
                PlayerPrefs.SetInt("Coin",coin);
                // storing the unlocked ships
                PlayerPrefs.SetInt(ships[currentShipIndex].name,1);
                //unlocked ships 
                ships[currentShipIndex].isUnlocked = true;
                ships[currentShipIndex].price =0;
            }
        }
   }
  public void UIUpdate()
  {
    shipblueprint s = ships[currentShipIndex];
    if(s.isUnlocked)
    {
        startText.text = "Start";
    }
    else
    { 
        startText.text ="Buy"; 
        
    }
    coinText.text =  s.price.ToString();
    
  }
  
}
