using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class __ScoreManager : MonoBehaviour
{
    float timer=180;
    public float totalScore;
    DiceRoll dice;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;

    private void Start()
    {
        dice = FindObjectOfType<DiceRoll>();
    }


    public void Update()
    {
        timer -= Time.deltaTime;

        if (timer<0 && timer >-1)
        {
            dice.SpawnBoss();
            timeText.gameObject.SetActive(false);
        }

        scoreText.text = "Score: "+totalScore;

        if (timer % 60 > 10)
        {
            timeText.text = "" + ((int)(timer / 60)) + ":" + Math.Round(timer % 60);
        }
        else
        {
            timeText.text = "" + ((int)(timer / 60)) + ":0" + Math.Round(timer % 60);
        }



    }

    public void AddScore(int scoreToAdd)
    {
        totalScore += scoreToAdd;
    }
}
