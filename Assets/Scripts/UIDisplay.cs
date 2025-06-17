using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthBar;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.maxValue = playerHealth.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("00000000");
    }
}
