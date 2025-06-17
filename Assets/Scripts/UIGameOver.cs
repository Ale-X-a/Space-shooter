using System;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = $"FINAL SCORE: \n {scoreKeeper.GetScore()}";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
