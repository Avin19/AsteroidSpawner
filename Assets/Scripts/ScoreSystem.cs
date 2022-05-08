using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;
    private bool stopScore= true;
    private float score;
    void Update()
    
    {
        if(!stopScore){return;}
        score += Time.deltaTime * scoreMultiplier;

        scoreText.text = Mathf.FloorToInt(score).ToString();
        
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
