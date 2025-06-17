using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health: MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 100;
    [SerializeField] int score = 50;
    
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    public int GetHealth()
    {
        return health;
    }

    void Awake()
    {
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null) 
        {
            TakeDamage(damageDealer.GetDamage()); 
            audioPlayer.PlayDamageClip();
            damageDealer.Hit();                   
        }
    }

    void TakeDamage(int damage) 
    {
        health -= damage; 
        
        if (health <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
        else
        {
            levelManager.LoadGameOver();
        }
        
        Destroy(gameObject);
    }
}