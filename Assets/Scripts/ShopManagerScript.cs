using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ShopManagerScript : MonoBehaviour
{
    public int currentShipIndex ;
    public GameObject[] shipModels;
    public shipblueprint[] ships;
    public TMP_Text startText ,coinText, yourCoin;
    

    void Start()
    {  
        yourCoin.text= "Your Coin : "+ PlayerPrefs.GetInt("Coin",0).ToString();
        foreach(shipblueprint ship in ships)
        {
            if( ship.price == 0 )
            {
                ship.isUnlocked =true;
            }
            else
            {
                ship.isUnlocked =false;
            }
        }
       
        currentShipIndex = PlayerPrefs.GetInt("SelectedShip",0);
        foreach (GameObject ship in shipModels)
        {
            ship.SetActive(false);
        }
        shipModels[currentShipIndex].SetActive(true);
       
        
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
        //buy new ship code
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
