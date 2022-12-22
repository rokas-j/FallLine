using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _timerText;
    [SerializeField]
    private GameObject _gameOverElements;
    [SerializeField]
    private Text _finalScore;
    [SerializeField]
    private Text _highScore;
    // Start is called before the first frame update
    void Start()
    {
        _gameOverElements.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(float playerScore)
    {
        _scoreText.text = "Score: " + ((int)(playerScore*10)).ToString();
    }
    public void updateTimer(float timer)
    {
        string timerText = (Mathf.Round(timer*10f)/10f).ToString("0.0");
        _timerText.text = "Timer: " + timerText + " s";
    }
    public void showGameOver(float score, float highScore)
    {
        _finalScore.text = "Score: " + ((int)(score*10)).ToString();
        _highScore.text = "Highscore: " + ((int)(highScore*10)).ToString();
        _gameOverElements.SetActive(true);
        
    }
    public void playGame() {
        SceneManager.LoadScene("PlayScene");
    }
}
