using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text gameOverText;
    float currentTime;
    int score;
    private bool gameOver = false;
   

    public PlayerController player;
    private Vector3 spawnPos = new Vector3 (-7f, -3.5f, -1f);
    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
        score = 0;
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

        //display game over text and p


    }//GameOver

    public void Respawn()
    {
        //reset timer, score, and player position and destroy old objs
        currentTime = 0.0f;
        score = 0;
        player.gameObject.SetActive(true);
        player.transform.position = spawnPos;
        gameOverText.gameObject.SetActive(false);

        var bricks = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach( var brick in bricks)
        {
            Destroy(brick);
        }
        
        
        
        


    }//Respawn

    private void Score()
    {
        //track score
    }

  
}
