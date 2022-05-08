using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using StartApp;

public class GameOverHandler : MonoBehaviour
{   [SerializeField] GameObject gameOverDisplay;
    [SerializeField] AsteroidSpwaner asteroidSpwaner;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] GameObject pauseMenu;


    public void EndGame()
    {   gameOverDisplay.gameObject.SetActive(true);
        asteroidSpwaner.enabled= false;
        gameOverText.text = "Game Over /n Your Score : " + scoreSystem.EndTimer();
    }
   public void PlayGame()
   {
       SceneManager.LoadScene(1);
   }
   public void ReturnMainMenu()
   {
       SceneManager.LoadScene(0);
   }
   public void WatchAdsToContinue(){
       var ad = AdSdk.Instance.CreateInterstitial();
       ad.RaiseAdLoaded += (sender, e) => ad.ShowAd();
        ad.RaiseAdVideoCompleted += (sender, e) => { ResumeGame(); };
        ad.LoadAd(InterstitialAd.AdType.Rewarded);

   }
   void ResumeGame(){
        gameOverDisplay.gameObject.SetActive(false);
        asteroidSpwaner.enabled= true;
        scoreSystem.ResumeTimer();
        playerHealth.Alive();

   }
   public void PauseMenuDisplay()
   {   Time.timeScale =0;
       pauseMenu.SetActive(true);
   }
   public void PauseMenuContiune()
   {
       Time.timeScale =1;
       pauseMenu.SetActive(false);
   }
}
