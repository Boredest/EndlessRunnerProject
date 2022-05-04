using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ref to text for TMPRO ui
    public TMP_Text timerText;
    float currentTime;
    int seconds;
    int score;
  
    // Update is called once per frame
    void Update()
    {
        
        //timer
        currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("F1");
    }

    private void Score()
    {
        //todo
    }
}
