using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoresController : MonoBehaviour
{
    [Header("Win condition")]
    public static int numberOfMoney = 0;
    public int scoresToWin = 10;
    private bool isWin = false;

    public TextMeshProUGUI scorePointsText;
    public GameObject winGameText;

    
    // Update is called once per frame
    void Update()
    {
        DisplayScores();
        CheckProgress();
        EndGame();
    }

    public void DisplayScores() 
    {
        scorePointsText.text = "Scores: " + numberOfMoney;
    }

    public void CheckProgress() 
    {
        if (numberOfMoney >= scoresToWin)
            isWin = true;
    }

    public void EndGame() 
    {
        if (isWin)
            winGameText.SetActive(true);   
    }
}
