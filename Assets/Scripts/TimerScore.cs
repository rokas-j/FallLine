using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScore : MonoBehaviour
{  
    public UIManager UiManager;
    public bool isActive = true;
    float timerScore = 0f;
    float remainingTime = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // score
        if(isActive)
            timerScore += Time.deltaTime;
            UiManager.updateScore(timerScore);
        
        // timer
        remainingTime -= Time.deltaTime;            
        if (remainingTime <= 0) {
            remainingTime = 0;
            isActive = false;
            // highscore
            float highscore = PlayerPrefs.GetFloat("highscore", 0f);
            if (timerScore > highscore){
                PlayerPrefs.SetFloat("highscore", timerScore);
                highscore = timerScore;
            }

            UiManager.showGameOver(timerScore, highscore);
        }
        UiManager.updateTimer(remainingTime);
    }

    public void AddToTimer()
    {
        remainingTime += 2;
    }
}
