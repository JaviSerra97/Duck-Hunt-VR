using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {
    private int score = 0;
    public float timeLeft = 100f;
    private float timeNewGame;
    public Text scoreText;
    public Text finalScore;
    public Text timeText;
    public Text nextGameTime;
    public GameObject gameOverPanel;
    public GameObject gun;
    private Audio_Manager audioManager;

	// Use this for initialization
	void Start ()
    {
        gameOverPanel.SetActive(false);
        audioManager = Audio_Manager.instance;
    }
	
	// Update is called once per frame
	void Update () {
        Timer();
        Score();
        GameOver();
        NextGame();
	}

    public void Timer()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = Mathf.Round(timeLeft).ToString();
        nextGameTime.text = Mathf.Round(timeNewGame).ToString();
    }

    public void Score()
    {
        scoreText.text = score.ToString();
        finalScore.text = score.ToString();
    }

    public void GameOver()
    {
        if(timeLeft <= 0f)
        {
            timeText.text = 0.ToString();
            audioManager.PlaySound("Finish");
            gun.SetActive(false);
            gameOverPanel.SetActive(true);
        }
    }

    public void NextGame()
    {
        timeNewGame = timeLeft + 15f;
        if (timeNewGame <= 0)
        {
            SceneManager.LoadScene("Game");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("BlackDuck"))
        {
            audioManager.PlaySound("BadScore");
            timeLeft--;
            Destroy(other.gameObject);
        }
        if (other.tag.Equals("GreenDuck"))
        {
            audioManager.PlaySound("Score");
            timeLeft +=3;
            Destroy(other.gameObject);
        }
        if (other.tag.Equals("YellowDuck"))
        {
            audioManager.PlaySound("Score");
            score += 20;
            Destroy(other.gameObject);
        }
        if (other.tag.Equals("RedDuck"))
        {
            audioManager.PlaySound("Score");
            score += 50;
            Destroy(other.gameObject);
        }
    }
}
