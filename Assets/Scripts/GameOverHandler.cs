using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    [SerializeField] GameObject redFlash;
   
    
    private float health;
    private bool check =true;
    private AudioSource audioPlayer;
    private float timer=1f;
    private void Start() {
        audioPlayer = GameObject.Find("Audio").GetComponent<AudioSource>();
    }
    public void EndGame()
    {    
        gameOverDisplay.gameObject.SetActive(true);
        asteroidSpwaner.enabled= false;
        gameOverText.text = "Game Over \n Your Score : " + scoreSystem.EndTimer();
        audioPlayer.Stop();
        TimeController(0);
    }
    private void Update()
    {

        health = playerHealth.GetHealth();
        if (health <= 20f)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                redFlash.SetActive(!redFlash.activeSelf);
                timer =1f;
            }
    
            if (check)
            {
                check = false;
                AudioManager.Instance.Emergency();
            }
        }
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

        TimeController(1);
   }
   public void PauseMenuDisplay()
   {   
        TimeController(0);
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
