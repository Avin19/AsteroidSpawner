using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private bool stopScore= true;
    private int score;
    private void Start() {
        score= PlayerPrefs.GetInt("Coin",0);
    }
    void Update()
    {
        if(!stopScore){return;}

        scoreText.text =score.ToString();

        
    }
    public void coinadd(){
        score += 1;
        PlayerPrefs.SetInt("Coin",score);
    }
    public int EndTimer(){
        stopScore =false;
        
        scoreText.text = string.Empty;
        return Mathf.FloorToInt(score);
    }
    public void ResumeTimer(){
        stopScore=true;
        
    }
}
