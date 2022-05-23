using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text gameOverText;
    public TMP_Text scoreText;
    float currentTime;
    int score;
    private bool gameOver = false;
   

    public PlayerController player;
    public Vector3 spawnPos = new Vector3 (-7f, -1.4f, -1f);

    private void Awake()
    {
        timerText.outlineWidth = 0.2f;
        timerText.outlineColor = new Color32(48, 48, 48, 255);
        scoreText.outlineWidth = 0.2f;
        scoreText.outlineColor = new Color32(48, 48, 48, 255);
        gameOverText.outlineWidth = 0.2f;
        gameOverText.outlineColor = new Color32(48, 48, 48, 255);
    }
    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
        score = 0;
        scoreText.SetText(score.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        
        //timer
        currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("F1");

       if(gameOver && Input.GetKeyDown(KeyCode.Space)) {
            Respawn();
            gameOver = false;
            Time.timeScale = 1.0f;
        }

    }//Update

    public void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0.0f;

    }//GameOver

    public void Respawn()
    {
        //reset timer, score, and player position and destroy old objs
        currentTime = 0.0f;
        score = 0;
        scoreText.SetText(score.ToString());
        player.gameObject.SetActive(true);
        player.transform.position = spawnPos;
        gameOverText.gameObject.SetActive(false);

        var bricks = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach( var brick in bricks)
        {
            Destroy(brick);
        }
        

    }//Respawn

    public void Score()
    {
        score++;
        scoreText.SetText(score.ToString());
        //track score
    }

  
}
