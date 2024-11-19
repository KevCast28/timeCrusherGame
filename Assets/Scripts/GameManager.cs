using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddPoints(int quantity)
    {
        score += quantity;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = score.ToString();
    }

    private void RestartScore()
    {
        score = 0;
        UpdateUI();
    }
}
