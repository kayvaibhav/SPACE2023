using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] private float gameTime;
    private float sliderCurrentFillAmount = 1f;

    [Header("Score Components")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Game Over Components")]
    [SerializeField] private GameObject GameOverScreen;
    [Header("High Score Components")]
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int playerScore; 

    public enum GameState
    {
        Waiting,
        Playing,
        GameOver
    }
    public static GameState currentGameStatus;

    private void Awake()
    {
        currentGameStatus = GameState.Waiting;
        
        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    private void Update()
    {
        if (currentGameStatus == GameState.Playing)
            AdjustTimer();
    }

    private void AdjustTimer()
    {
        timerImage.fillAmount = sliderCurrentFillAmount - (Time.deltaTime / gameTime);

        sliderCurrentFillAmount = timerImage.fillAmount;

        if (sliderCurrentFillAmount <= 0f)
        {
            GameOver();
        }
    }



    public void UpdatePlayerScore(int score)
    {
        if (currentGameStatus != GameState.Playing) return;
        //update the score
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }

    public void StartGame()
    {
        currentGameStatus = GameState.Playing;
    }
    private void GameOver()
    {
        currentGameStatus = GameState.GameOver;
        GameOverScreen.SetActive(true);

        if(playerScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerScore); 
            highScoreText.text = playerScore.ToString();
        }
    }
    public void ResetGame()
    {
        currentGameStatus = GameState.Waiting;
        playerScore = 0;
        scoreText.text = "0";
        sliderCurrentFillAmount = 1f;
        timerImage.fillAmount = sliderCurrentFillAmount;
        // GameOverScreen.SetActive(false); // this is not needed because the laser destroys the gameoverscreen anyways
    }
}
