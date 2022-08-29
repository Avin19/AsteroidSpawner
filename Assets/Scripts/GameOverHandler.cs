using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverHandler : MonoBehaviour
{   [SerializeField] GameObject gameOverDisplay;
    [SerializeField] AsteroidSpwaner asteroidSpwaner;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] GameObject pauseMenu;
    


    public void EndGame()

    {    TimeController(0);
        gameOverDisplay.gameObject.SetActive(true);
        asteroidSpwaner.enabled= false;
        gameOverText.text = "Game Over \n Your Score : " + scoreSystem.EndTimer();
    }
   public void PlayGame()
   {
       TimeController(1);
       SceneManager.LoadScene(1);
   }
   public void ReturnMainMenu()
   {   TimeController(1);
       SceneManager.LoadScene(0);
   }
   void ResumeGame(){
        gameOverDisplay.gameObject.SetActive(false);
        asteroidSpwaner.enabled= true;
        scoreSystem.ResumeTimer();
        playerHealth.Alive();
        TimeController(1);

   }
   public void PauseMenuDisplay()
   {   TimeController(0);
       pauseMenu.SetActive(true);
   }
   public void PauseMenuContiune()
   {
       TimeController(1);
       pauseMenu.SetActive(false);
   }
   private void TimeController(int i)
   {
        Time.timeScale =i;
   }
}
