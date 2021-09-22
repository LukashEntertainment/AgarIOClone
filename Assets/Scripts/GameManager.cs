using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel, losePanel;

    [SerializeField] private Text mainScoreText, panelScoreText, highScoreText;

    private int _highScore;
    private int _scoreTemp;
    private bool _isPlayerWin;

    List<Enemy> players = new List<Enemy>();
    public void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void Update()
    {
        if (_isPlayerWin)
        {
            Win();
        }
    }

    public void UpdateScore(int score, string name)
    {
        if (score > _highScore)
        {
            _highScore = score;
            PlayerPrefs.SetInt("HighScore", _highScore);
        }

        _scoreTemp = score;
        mainScoreText.text = name + " " + _scoreTemp.ToString();
    }

    private void Win()
    {
        Destroy(FindObjectOfType<Player>());
        winPanel.SetActive(true);
        panelScoreText.text = "Score: " + _scoreTemp.ToString();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void CheckEnemies()
    {
        var enemies =
        FindObjectsOfType<Enemy>();

        if (enemies.Length == 0)
        {
            _isPlayerWin = true;
        }
        else
        {
            _isPlayerWin = false;
        }
    }
    
    public void Lose()
    {
        losePanel.SetActive(true);
    }
}
